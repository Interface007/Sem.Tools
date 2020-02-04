namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterReturns : MarkdownBase
    {
        public MdConverterReturns(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            return $"\n#### Returns:\n{this.ToMarkDown(this.Node.Nodes())}\n\n";
        }
    }
}