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
            var templates = new Dictionary<string, string>
            {
                {"doc", "## {0} ##\n\n{1}\n\n"},
                {"type", "# Type: {0}\n\n{1}\n\n---\n"},
                {"field", "##### {0}\n\n{1}\n\n---\n"},
                {"property", "##### {0}\n\n{1}\n\n---\n"},
                {"method", "##### Method: {0}\n\n{1}\n\n---\n"},
                {"event", "##### {0}\n\n{1}\n\n---\n"},
                {"summary", "{0}\n\n"},
                {"remarks", "\n\n>{0}\n\n"},
                {"example", "_C# code_\n\n```c#\n{0}\n```\n\n"},
                {"seePage", "[[{1}|{0}]]"},
                {"seeAnchor", "[{1}]({0})"},
                {"typeparam", "|Name | Description |\n|-----|------|\n|{0}: |{1}|\n" },
                {"param", "|Name | Description |\n|-----|------|\n|{0}: |{1}|\n" },
                {"exception", "[[{0}|{0}]]: {1}\n\n" },
                {"returns", "Returns: {0}\n\n"},
                {"none", ""}
            };

            var d = new Func<string, XElement, string[]>((att, node) => new[]
            {
                node.Attribute(att)?.Value,
                node.Nodes().ToMarkDown(currentNameSpace)
            });

            var methods = new Dictionary<string, Func<XElement, IEnumerable<string>>>
            {
                {"doc", x => new[] 
                    {
                        x.Element("assembly")?.Element("name")?.Value,
                        x.Element("members")?.Elements("member").ToMarkDown(x.Element("assembly")?.Element("name")?.Value),
                    }
                },
                {"type", x=> d("name", x)},
                {"field", x=> d("name", x)},
                {"property", x => d("name", x)},
                {"method", x => Method(x, currentNameSpace)},
                {"event", x => d("name", x)},
                {"summary", x => new[]{ x.Nodes().ToMarkDown(currentNameSpace) }},
                {"remarks", x => new[]{x.Nodes().ToMarkDown(currentNameSpace)}},
                {"example", x => new[]{x.Value.ToCodeBlock()}},
                {"seePage", x => d("cref", x) },
                {"seeAnchor", x => { var xx = d("cref", x); xx[0] = xx[0].ToLower(); return xx; }},
                {"typeparam", x => d("name", x) },
                {"param", x => d("name", x) },
                {"exception", x => d("cref", x) },
                {"returns", x => new[]{x.Nodes().ToMarkDown(currentNameSpace)}},
                {"none", x => new string[0]}
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
                return values.Length switch
                {
                    1 => string.Format(templates[name], values[0]),
                    2 => string.Format(templates[name], values[0], values[1]),
                    3 => string.Format(templates[name], values[0], values[1], values[2]),
                    4 => string.Format(templates[name], values[0], values[1], values[2], values[3]),
                    _ => " !! UNSUPPORTED: " + name + " !! ",
                };
            }

            if (e.NodeType == XmlNodeType.Text)
                return Regex.Replace(((XText)e).Value.Replace('\n', ' '), @"\s+", " ");

            return "";
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