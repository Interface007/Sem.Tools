using System.Xml.Linq;

namespace Sem.MdDocGenerator
{
    public class MdConverterSummary : MarkdownBase
    {
        public MdConverterSummary(XElement el) : base(el) { }

        public override string ToString()
        {
            return this.ToMarkDown(this.Node.Nodes()) + "\n\n";
        }
    }
}