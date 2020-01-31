using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace Sem.MdDocGenerator
{
    public static class XmlToMarkdown
    {
        internal static string ToMarkDown(this XNode e, string currentNameSpace)
        {
            var templates = new Dictionary<string, string[]>
            {
                { "doc      ".Trim(), new [] {"# {0} ##\n\n{1}\n\n"}},
                { "type     ".Trim(), new [] {"## Type: {0}\n\n{1}\n\n---\n"}},
                { "field    ".Trim(), new [] {"### {0}\n\n{1}\n\n---\n"}},
                { "property ".Trim(), new [] {"### {0}\n\n{1}\n\n---\n"}},
                { "method   ".Trim(), new [] {"### Method: {0}\n\n{1}\n\n---\n"}},
                { "event    ".Trim(), new [] {"### {0}\n\n{1}\n\n---\n"}},
                { "summary  ".Trim(), new [] {"{0}\n\n"}},
                { "remarks  ".Trim(), new [] {"\n\n>{0}\n\n"}},
                { "example  ".Trim(), new [] {"_C# code_\n\n```c#\n{0}\n```\n\n"}},
                { "seePage  ".Trim(), new [] {"[[{1}|{0}]]"}},
                { "seeAnchor".Trim(), new [] {"[{1}]({0})"}},
                { "typeparam".Trim(), new [] {"#### Type parameters:\n|Name | Description |\n|-----|------|\n|{0}|{1}|\n", "|{0}: |{1}|\n" }},
                { "param    ".Trim(), new [] {"#### Parameters:\n|Name | Description |\n|-----|------|\n|{0}|{1}|\n", "|{0}: |{1}|\n" }},
                { "exception".Trim(), new [] {"[[{0}|{0}]]: {1}\n\n" }},
                { "returns  ".Trim(), new [] {"\n#### Returns:\n{0}\n\n"}},
                { "paramref ".Trim(), new [] {" {0} "}},
                { "none     ".Trim(), new [] {""}}
            };

            var d = new Func<string, XElement, string[]>((att, node) => new[]
            {
                node.Attribute(att)?.Value,
                node.Nodes().ToMarkDown(currentNameSpace)
            });

            var methods = new Dictionary<string, Func<XElement, IEnumerable<string>>>
            {
                { "doc", x => new[]
                    {
                        x.Element("assembly")?.Element("name")?.Value,
                        x.Element("members")?.Elements("member").ToMarkDown(x.Element("assembly")?.Element("name")?.Value),
                    }
                },
                { "type     ".Trim(), x => TypeInfo(x, currentNameSpace) },
                { "field    ".Trim(), x => d("name", x) },
                { "property ".Trim(), x => d("name", x) },
                { "method   ".Trim(), x => Method(x, currentNameSpace) },
                { "event    ".Trim(), x => d("name", x) },
                { "summary  ".Trim(), x => new[] { x.Nodes().ToMarkDown(currentNameSpace) } },
                { "remarks  ".Trim(), x => new[] { x.Nodes().ToMarkDown(currentNameSpace) } },
                { "example  ".Trim(), x => new[] { x.Value.ToCodeBlock() }},
                { "seePage  ".Trim(), x => d("cref", x) },
                { "seeAnchor".Trim(), x => { var xx = d("cref", x); xx[0] = xx[0].ToLower(); return xx; }},
                { "typeparam".Trim(), x => d("name", x) },
                { "param    ".Trim(), x => d("name", x) },
                { "exception".Trim(), x => d("cref", x) },
                { "returns  ".Trim(), x => new[] { x.Nodes().ToMarkDown(currentNameSpace) } },
                { "paramref ".Trim(), x => d("name", x)},
                { "none     ".Trim(), x => new string[0]},
            };

            if (e.NodeType == XmlNodeType.Element)
            {
                var el = (XElement)e;
                var name = el.Name.LocalName;
                if (name == "member")
                {
                    switch (el.Attribute("name")?.Value[0])
                    {
                        case 'F': name = "field"; break;
                        case 'P': name = "property"; break;
                        case 'T': name = "type"; break;
                        case 'E': name = "event"; break;
                        case 'M': name = "method"; break;
                        default: name = "none"; break;
                    }
                }

                if (name == "see")
                {
                    var anchor = el.Attribute("cref")?.Value.StartsWith("!:#") ?? false;
                    name = anchor ? "seeAnchor" : "seePage";
                }


                if (!methods.ContainsKey(name))
                {
                    return " !! UNSUPPORTED: " + name + " !! ";
                }

                var values = methods[name](el).ToArray();
                var i = ((el.PreviousNode as XElement)?.Name.LocalName == name && templates[name].Length > 1) ? 1 : 0;
                return values.Length switch
                {
                    1 => string.Format(templates[name][i], values[0]),
                    2 => string.Format(templates[name][i], values[0], values[1]),
                    3 => string.Format(templates[name][i], values[0], values[1], values[2]),
                    4 => string.Format(templates[name][i], values[0], values[1], values[2], values[3]),
                    _ => " !! UNSUPPORTED: " + name + " !! ",
                };
            }

            if (e.NodeType == XmlNodeType.Text)
                return Regex.Replace(((XText)e).Value.Replace('\n', ' '), @"\s+", " ");

            return "";
        }

        private static IEnumerable<string> TypeInfo(XElement node, string currentNameSpace)
        {
            var name = node
                .Attribute("name")?
                .Value
                .Substring(2);
            var content = node.Nodes().ToMarkDown(currentNameSpace);
            return new[] { name, content };
        }

        private static IEnumerable<string> Method(XElement node, string currentNameSpace)
        {
            var content = node.Nodes().ToMarkDown(currentNameSpace);
            var name = node
                .Attribute("name")?
                .Value
                .Substring(2)
                .Replace("System.String", "string")
                .Replace("System.Func", "Func")
                .Replace("System.Threading.Tasks.Task", "Task")
                .Replace("System.Collections.Generic.KeyValuePair", "KeyValuePair")
                .Replace("System.Object", "Object")
                .Replace("{``0}", "\\<T>")
                .Replace("{", "\\<")
                .Replace("}", ">")
                .Replace("``0", "\\<T1>")
                .Replace("``1", "\\<T1, T2>")
                .Replace("``2", "\\<T1, T2, T3>")
                .Replace("``3", "\\<T1, T2, T3, T4>")
                .Replace("``4", "\\<T1, T2, T3, T4, T5>")
                .Replace("``1", "\\<T>")
                .Replace(",", ", ");

            if (!string.IsNullOrEmpty(currentNameSpace))
            {
                name = name?.Replace(currentNameSpace + ".", string.Empty);
            }

            return new[] { name, content };
        }

        internal static string ToMarkDown(this IEnumerable<XNode> es, string currentNameSpace)
        {
            return es.Aggregate("", (current, x) => current + x.ToMarkDown(currentNameSpace));
        }

        static string ToCodeBlock(this string s)
        {
            var lines = s.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var blank = lines[0].TakeWhile(x => x == ' ').Count() - 4;
            return string.Join("\n", lines.Select(x => new string(x.SkipWhile((y, i) => i < blank).ToArray())));
        }
    }
}