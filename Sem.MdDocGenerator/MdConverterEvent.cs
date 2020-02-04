namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterEvent : MarkdownBase
    {
        public MdConverterEvent(XElement el) : base(el) { }

        public override string ToString()
        {
            return base.ToString("### {0} (#{0})\n\n{1}\n\n---\n");
        }
    }
}