using System.Xml.Linq;

namespace Sem.MdDocGenerator
{
    public class MdConverterSummary : MarkdownBase
    {
        public MdConverterSummary(XElement el, AssemblyContext context)
            : base(el, context)
        {
        }

        public override string ToString()
        {
            return this.ToMarkDown(this.Node.Nodes()) + "\n\n";
        }
    }
}