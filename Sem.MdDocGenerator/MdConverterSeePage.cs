using System.Linq;
using System.Text.RegularExpressions;

namespace Sem.MdDocGenerator
{
    using System;
    using System.Xml.Linq;

    using Sem.Tools;

    public class MdConverterSeePage : MarkdownBase
    {
        public MdConverterSeePage(XElement el, AssemblyContext context)
            : base(el, context)
        {
        }

        public override string ToString()
        {
            var parts = d("cref", this.Node);
            var className = string.Empty;
            var ns = this.Context.NameSpace;
            var anchor =string.Empty;
            var part = parts[0];
            if (part[0] == 'T')
            {
                className = part.Substring(2);
                ns = part.Contains("<", StringComparison.Ordinal)
                    ? part.Substring(0, part.IndexOf('<', StringComparison.Ordinal) - 1)
                    : part;
                ns = ns.Substring(2, ns.LastIndexOf('.') - 2);
                anchor = "type-" + Anchor(className);
            }
            else if (part[0] == 'M')
            {
                ns = part.Contains("(", StringComparison.Ordinal)
                    ? part.Substring(0, part.IndexOf('(', StringComparison.Ordinal) - 1)
                    : part;
                ns = ns.Substring(2, ns.LastIndexOf('.') - 2);

                className = this.FixMethodName(part);
                anchor = "method-" + Anchor(className);
            }

            var file = this.Context.Files
                .Where(x => ns.StartsWith(x, StringComparison.Ordinal))
                .OrderByDescending(x => x.Length)
                .FirstOrDefault();

            return string.IsNullOrEmpty(file) ? $"```{className}```" : $"[{className}]({file}.md#{anchor})";
        }

        private static string Anchor(string className)
        {
            return Regex.Replace(className
                .Replace(" ", "-")
                .ToLowerInvariant(),
                "[^a-z-]",
                "");
        }
    }
}