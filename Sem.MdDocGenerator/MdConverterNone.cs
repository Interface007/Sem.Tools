using System.Xml.Linq;

namespace Sem.MdDocGenerator
{
    public class MdConverterNone : MarkdownBase
    {
        public MdConverterNone(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}