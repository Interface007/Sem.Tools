using System.Linq;

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

            var part = parts[0];
            if (part[0] == 'T')
            {
                className = part.Substring(2);
                ns = part.Contains("<", StringComparison.Ordinal)
                    ? part.Substring(0, part.IndexOf('<', StringComparison.Ordinal) - 1)
                    : part;
                ns = ns.Substring(2, ns.LastIndexOf('.') - 2);
            }
            else if (part[0] == 'M')
            {
                ns = part.Contains("(", StringComparison.Ordinal)
                    ? part.Substring(0, part.IndexOf('(', StringComparison.Ordinal) - 1)
                    : part;
                ns = ns.Substring(2, ns.LastIndexOf('.') - 2);

                className = this.FixMethodName(part);
            }

            var file = this.Context.Files
                .Where(x => ns.StartsWith(x, StringComparison.Ordinal))
                .OrderByDescending(x => x.Length)
                .FirstOrDefault();

            return string.IsNullOrEmpty(file) ? $"```c# {className}```" : $"[{className}]({file}.md#Ref{part.Hash()})";
        }
    }
}