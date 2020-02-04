using Sem.Tools;

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterSeePage : MarkdownBase
    {
        public MdConverterSeePage(XElement el) : base(el) { }

        public override string ToString()
        {
            var parts = d("cref", this.Node, this.NameSpace);
            var className = string.Empty;
            var ns = this.NameSpace;

            var part = parts[0];
            if (part[0] == 'T')
            {
                className = part.Substring(2);
                ns = part.Contains("<") ? part.Substring(0, part.IndexOf('<') - 1) : part;
                ns = ns.Substring(0, ns.LastIndexOf('.'));
            }
            else if (part[0] == 'M')
            {
                className = this.FixMethodName(part);
            }

            return $"[{className}]({ns}.md#Ref{part.Hash()})";
        }
    }
}