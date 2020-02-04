namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterProperty : MarkdownBase
    {
        public MdConverterProperty(XElement el, AssemblyContext context) : base(el, context) { }

        public override string ToString()
        {
            var x = d("name", this.Node);
            return $"### Property: {x[0].Substring(2)}\n\n{x[1]}\n";
        }
    }
}