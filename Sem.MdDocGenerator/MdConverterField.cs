namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    internal class MdConverterField : MarkdownBase
    {
        public MdConverterField(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}