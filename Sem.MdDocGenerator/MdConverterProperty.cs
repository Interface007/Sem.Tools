namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterProperty : MarkdownBase
    {
        public MdConverterProperty(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            return base.ToString("### {0} (#{0})\n\n{1}\n\n---\n");
        }
    }
}