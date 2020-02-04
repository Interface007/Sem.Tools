namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterTypeparam : MarkdownBase
    {
        public MdConverterTypeparam(XElement el) : base(el) { }

        public override string ToString()
        {
            var i = ((this.Node.PreviousNode as XElement)?.Name.LocalName != this.Node?.Name.LocalName);
            return base.ToString(i ? "#### Type parameters:\n|Name | Description |\n|-----|------|\n|{0}|{1}|\n" : "|{0}: |{1}|\n");
        }
    }
}