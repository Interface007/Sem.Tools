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

        public string NameSpace { set; get; }

        protected MarkdownBase(XElement node, string nameSpace = "")
        {
            this.Node = node;
            this.NameSpace = nameSpace;
        }

        public string ToMarkDown(IEnumerable<XNode> es)
        {
            return es.Aggregate("", (current, x) => current + ToMarkDown(x));
        }

        public string ToMarkDown(XNode e)
        {
            if (e is XElement el)
            {
                var name = GetName(el);
                var converter = GetConverter(name, el);
                return converter.ToString();
            }

            return e.NodeType == XmlNodeType.Text
                ? Regex.Replace(((XText)e).Value.Replace('\n', ' '), @"\s+", " ")
                : string.Empty;
        }

        protected string[] d(string att, XElement node, string currentNameSpace) => new[]
        {
            node.Attribute(att)?.Value,
            this.ToMarkDown(node.Nodes()),
        };


        private static string GetName(XElement el)
        {
            var name = el.Name.LocalName;
            switch (name)
            {
                case "member":
                    return el.Attribute("name")?.Value[0] switch
                    {
                        'F' => "field",
                        'P' => "property",
                        'T' => "type",
                        'E' => "event",
                        'M' => "method",
                        _ => "none"
                    };

                case "see":
                    return el.Attribute("cref")?.Value.StartsWith("!:#", StringComparison.Ordinal) ?? false ? "seeAnchor" : "seePage";

                case "param":
                case "typeparam":
                case "summary":
                case "returns":
                case "paramref":
                case "typeparamref":
                case "example":
                    return name;

                default:
                    return name;
            }
        }

        private MarkdownBase GetConverter(string name, XElement el)
        {
            return name switch
            {
                "doc" => (MarkdownBase)new MdConverterDoc(el),
                "type" => new MdConverterType(el),
                "field" => new MdConverterField(el),
                "property" => new MdConverterProperty(el),
                "method" => new MdConverterMethod(el, this.NameSpace),
                "event" => new MdConverterEvent(el),
                "summary" => new MdConverterSummary(el),
                "remarks" => new MdConverterRemarks(el),
                "example" => new MdConverterExample(el),
                "seePage" => new MdConverterSeePage(el),
                "seeAnchor" => new MdConverterSeeAnchor(el),
                "typeparam" => new MdConverterTypeparam(el),
                "param" => new MdConverterParam(el),
                "exception" => new MdConverterException(el),
                "returns" => new MdConverterReturns(el),
                "paramref" => new MdConverterParamref(el),
                "typeparamref" => new MdConverterParamref(el),
                "none" => new MdConverterNone(el),
                _ => new MdConverterNone(el)
            };
        }

        public override string ToString()
        {
            return this.ToString("{0}\n");
        }

        public string ToString(string pattern)
        {
            var parts = d("name", this.Node, this.NameSpace);
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

            if (!string.IsNullOrEmpty(this.NameSpace))
            {
                name = name?.Replace(this.NameSpace + ".", string.Empty, StringComparison.Ordinal);
            }

            return name;
        }
    }
}