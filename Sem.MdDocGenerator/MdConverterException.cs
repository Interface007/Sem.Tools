namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterException : MarkdownBase
    {
        public MdConverterException(XElement el) : base(el) { }

        public override string ToString()
        {
            var parts = d("cref", this.Node, this.NameSpace);
            return base.ToString("[[{0}|{0}]]: {1}\n\n", parts);
        }
    }
}