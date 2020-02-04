using System.Xml.Linq;

namespace Sem.MdDocGenerator
{
    public class MdConverterNone : MarkdownBase
    {
        public MdConverterNone(XElement el) : base(el) { }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}