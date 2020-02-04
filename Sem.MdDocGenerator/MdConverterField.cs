namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    internal class MdConverterField : MarkdownBase
    {
        public MdConverterField(XElement el) : base(el) { }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}