// <copyright file="MarkdownBase.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;

    using Sem.Tools;

    /// <summary>
    /// Base class for translating C# XML comments into markdown.
    /// </summary>
    public abstract class MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownBase"/> class.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="context">The current execution context.</param>
        protected MarkdownBase(XElement node, AssemblyContext context)
        {
            this.Node = node;
            this.Context = context;
        }

        /// <summary>
        /// Gets the context of the current XML documentation file.
        /// </summary>
        public AssemblyContext Context { get; }

        /// <summary>
        /// Gets the XML node representing the current element.
        /// </summary>
        protected XElement Node { get; }

        /// <summary>
        /// Converts the node to markdown.
        /// </summary>
        /// <returns>The markdown representing the documentation node.</returns>
        public override string ToString() => this.ToString("{0}\n");

        /// <summary>
        /// Converts the node to markdown.
        /// </summary>
        /// <param name="pattern">The template for the markdown.</param>
        /// <param name="parts">The parts extracted from the node.</param>
        /// <returns>The markdown representing the documentation node.</returns>
        protected static string ToString(string pattern, string[] parts) =>
            string.Format(CultureInfo.InvariantCulture, pattern, parts.Cast<object>().ToArray());

        /// <summary>
        /// Converts the value into a code block.
        /// </summary>
        /// <param name="value">The value to be wrapped into a code block.</param>
        /// <returns>The markdown for the code block containing the value.</returns>
        protected static string ToCodeBlock(string value)
        {
            var lines = value.MustNotBeNull(nameof(value)).Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var blank = lines[0].TakeWhile(x => x == ' ').Count() - 4;
            return string.Join("\n", lines.Select(x => new string(x.SkipWhile((_, i) => i < blank).ToArray())));
        }

        /// <summary>
        /// Converts a collection of XML nodes to markdown.
        /// </summary>
        /// <param name="nodes">The nodes to be converted.</param>
        /// <returns>The generated markdown.</returns>
        protected string ToMarkDown(IEnumerable<XNode> nodes) => nodes.Aggregate(string.Empty, (current, x) => current + this.ToMarkDown(x));

        /// <summary>
        /// The default converter gets the name and the conversion of the child nodes.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to get the text from.</param>
        /// <param name="node">The XML node to parse.</param>
        /// <returns>An array with value and generated markup.</returns>
        protected string[] DefaultConvert(string attributeName, XElement node) => new[]
        {
            node?.Attribute(attributeName)?.Value,
            this.ToMarkDown(node?.Nodes()),
        };

        /// <summary>
        /// Converts the node to markdown.
        /// </summary>
        /// <param name="pattern">The template for the markdown.</param>
        /// <returns>The markdown representing the documentation node.</returns>
        protected string ToString(string pattern)
        {
            var parts = this.DefaultConvert("name", this.Node);
            return ToString(pattern, parts);
        }

        /// <summary>
        /// Performs various replacements to generate a user friendly method name.
        /// </summary>
        /// <param name="value">The original method name from the documentation file.</param>
        /// <returns>The user friendly name.</returns>
        protected string FixMethodName(string value)
        {
            var name = value?.Substring(2)
                .Replace("System.Threading.Tasks.Task", "Task", StringComparison.Ordinal)
                .Replace("System.Collections.Generic.", string.Empty, StringComparison.Ordinal)
                .Replace("System.Object", "Object", StringComparison.Ordinal)
                .Replace("System.", string.Empty, StringComparison.Ordinal)
                .Replace("Linq.Expressions.", string.Empty, StringComparison.Ordinal)
                .Replace("{``0,``1,``2,``3,``4}", "\\<T1, T2, T3, T4, T5>", StringComparison.Ordinal)
                .Replace("{``0,``1,``2,``3}", "\\<T1, T2, T3, T4>", StringComparison.Ordinal)
                .Replace("{``0,``1,``2}", "\\<T1, T2, T3>", StringComparison.Ordinal)
                .Replace("{``0,``1}", "\\<T1, T2>", StringComparison.Ordinal)
                .Replace("{``0}", "\\<T1>", StringComparison.Ordinal)
                .Replace("``1(", "\\<T1>(", StringComparison.Ordinal)
                .Replace("``2(", "\\<T1, T2>(", StringComparison.Ordinal)
                .Replace("``3(", "\\<T1, T2, T3>(", StringComparison.Ordinal)
                .Replace("``4(", "\\<T1, T2, T3, T4>(", StringComparison.Ordinal)
                .Replace("``5(", "\\<T1, T2, T3, T4, T5>(", StringComparison.Ordinal)
                .Replace("{", "\\<", StringComparison.Ordinal)
                .Replace("}", ">", StringComparison.Ordinal)
                .Replace(",", ", ", StringComparison.Ordinal);

            name = Replace(name, "String", "string");
            name = Replace(name, "Object", "object");
            name = Replace(name, "Int32", "int");
            name = Replace(name, "Boolean", "bool");
            name = Replace(name, "Byte", "byte");
            name = Replace(name, "Char", "char");
            name = Replace(name, "Int64", "long");
            name = Replace(name, "Int16", "short");

            if (!string.IsNullOrEmpty(this.Context.NameSpace))
            {
                name = name?.Replace(this.Context.NameSpace + ".", string.Empty, StringComparison.Ordinal);
            }

            return name;
        }

        private static string Replace(string name, string fromString, string toString) => Regex.Replace(name, "([, (<])" + fromString + "([, >)\\]\\[])", x => x.Groups[1] + toString + x.Groups[2]);

        /// <summary>
        /// Translates some of the names into more specific names.
        /// </summary>
        /// <param name="node">The node to get the name for.</param>
        /// <returns>The name of the node.</returns>
        private static string GetName(XElement node)
        {
            var name = node.Name.LocalName;
            return name switch
            {
                "member" => node.Attribute("name")?.Value[0] switch
                {
                    'F' => "field",
                    'P' => "property",
                    'T' => "type",
                    'E' => "event",
                    'M' => "method",
                    _ => "none"
                },
                "see" => node.Attribute("cref")?.Value.StartsWith("!:#", StringComparison.Ordinal) ?? false ? "seeAnchor" : "seePage",
                "param" => name,
                "typeparam" => name,
                "summary" => name,
                "returns" => name,
                "paramref" => name,
                "typeparamref" => name,
                "example" => name,
                _ => name
            };
        }

        /// <summary>
        /// Converts an XML node to markdown.
        /// </summary>
        /// <param name="node">The node to be converted.</param>
        /// <returns>The generated markdown.</returns>
        private string ToMarkDown(XNode node)
        {
            if (node is XElement el)
            {
                var name = GetName(el);
                var converter = this.GetConverter(name, el);
                return converter.ToString();
            }

            return node?.NodeType == XmlNodeType.Text
                ? Regex.Replace(((XText)node).Value.Replace('\n', ' '), @"\s+", " ")
                : string.Empty;
        }

        /// <summary>
        /// Gets the name specific converter instance.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="element">The element to get the converter for.</param>
        /// <returns>The converter instance.</returns>
        private MarkdownBase GetConverter(string name, XElement element) =>
            name switch
            {
                "doc" => new MdConverterDoc(element, this.Context),
                "type" => new MdConverterType(element, this.Context),
                "field" => new MdConverterField(element, this.Context),
                "property" => new MdConverterProperty(element, this.Context),
                "method" => new MdConverterMethod(element, this.Context),
                "event" => new MdConverterEvent(element, this.Context),
                "summary" => new MdConverterSummary(element, this.Context),
                "remarks" => new MdConverterRemarks(element, this.Context),
                "example" => new MdConverterExample(element, this.Context),
                "seePage" => new MdConverterSeePage(element, this.Context),
                "seeAnchor" => new MdConverterSeeAnchor(element, this.Context),
                "typeparam" => new MdConverterTypeparam(element, this.Context),
                "param" => new MdConverterParam(element, this.Context),
                "exception" => new MdConverterException(element, this.Context),
                "returns" => new MdConverterReturns(element, this.Context),
                "paramref" => new MdConverterParamref(element, this.Context),
                "typeparamref" => new MdConverterParamref(element, this.Context),
                "none" => new MdConverterNone(element, this.Context),
                _ => new MdConverterNone(element, this.Context)
            };
    }
}