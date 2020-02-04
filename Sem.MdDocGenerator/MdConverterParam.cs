namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterParam : MarkdownBase
    {
        public MdConverterParam(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            var i = ((this.Node.PreviousNode as XElement)?.Name.LocalName != this.Node?.Name.LocalName);
            return base.ToString(i ? "#### Parameters:\n|Name | Description |\n|-----|------|\n|{0}|{1}|\n" : "|{0}: |{1}|\n");
        }
    }
}