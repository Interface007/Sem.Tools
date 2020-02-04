namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterParamref : MarkdownBase
    {
        public MdConverterParamref(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            return base.ToString(" {0} ");
        }
    }
}