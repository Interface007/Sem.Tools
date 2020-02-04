namespace Sem.MdDocGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;

    public abstract class MarkdownBase
    {
        protected readonly XElement Node;

        public AssemblyContext Context { get; }

        protected MarkdownBase(XElement node, AssemblyContext context)
        {
            this.Node = node;
            this.Context = context;
        }

        public string ToMarkDown(IEnumerable<XNode> es)
        {
            return es.Aggregate(string.Empty, (current, x) => current + this.ToMarkDown(x));
        }

        public string ToMarkDown(XNode e)
        {
            if (e is XElement el)
            {
                var name = GetName(el);
                var converter = this.GetConverter(name, el);
                return converter.ToString();
            }

            return e.NodeType == XmlNodeType.Text
                ? Regex.Replace(((XText)e).Value.Replace('\n', ' '), @"\s+", " ")
                : string.Empty;
        }

        protected string[] d(string att, XElement node) => new[]
        {
            node.Attribute(att)?.Value,
            this.ToMarkDown(node.Nodes()),
        };


        private static string GetName(XElement el)
        {
            var name = el.Name.LocalName;
            return name switch
            {
                "member" => el.Attribute("name")?.Value[0] switch
                {
                    'F' => "field",
                    'P' => "property",
                    'T' => "type",
                    'E' => "event",
                    'M' => "method",
                    _ => "none"
                },
                "see" => el.Attribute("cref")?.Value.StartsWith("!:#", StringComparison.Ordinal) ?? false ? "seeAnchor" : "seePage",
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

        private MarkdownBase GetConverter(string name, XElement element)
        {
            return name switch
            {
                "doc" => (MarkdownBase)new MdConverterDoc(element, this.Context),
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

        public override string ToString()
        {
            return this.ToString("{0}\n");
        }

        public string ToString(string pattern)
        {
            var parts = d("name", this.Node);
            return this.ToString(pattern, parts);
        }

        public string ToString(string patter, string[] parts)
        {
            return string.Format(CultureInfo.InvariantCulture, patter, parts);
        }


        public static string ToCodeBlock(string s)
        {
            var lines = s.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var blank = lines[0].TakeWhile(x => x == ' ').Count() - 4;
            return string.Join("\n", lines.Select(x => new string(x.SkipWhile((y, i) => i < blank).ToArray())));
        }


        public string FixMethodName(string value)
        {
            var name = value?.Substring(2)
                .Replace("System.Threading.Tasks.Task", "Task", StringComparison.Ordinal)
                .Replace("System.Collections.Generic.", string.Empty, StringComparison.Ordinal)
                .Replace("System.Object", "Object", StringComparison.Ordinal)
                .Replace("System.", string.Empty, StringComparison.Ordinal)
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

            if (!string.IsNullOrEmpty(this.Context.NameSpace))
            {
                name = name?.Replace(this.Context.NameSpace + ".", string.Empty, StringComparison.Ordinal);
            }

            return name;
        }
    }

    public class AssemblyContext
    {
        public string NameSpace { get; set; }
        public string[] Files { get; set; }
    }
}