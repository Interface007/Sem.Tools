namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterException : MarkdownBase
    {
        public MdConverterException(XElement el, AssemblyContext context)
            : base(el, context)
        {
        }

        public override string ToString()
        {
            var parts = d("cref", this.Node);
            return base.ToString("[[{0}|{0}]]: {1}\n\n", parts);
        }
    }
}