namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterRemarks : MarkdownBase
    {
        public MdConverterRemarks(XElement el) : base(el) { }

        public override string ToString()
        {
            return this.ToMarkDown(this.Node.Nodes()) + "\n\n";
        }
    }
}