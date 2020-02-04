namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterSeeAnchor : MarkdownBase
    {
        public MdConverterSeeAnchor(XElement el, AssemblyContext context)
            : base(el, context)
        {
        }

        public override string ToString()
        {
            var parts = d("cref", this.Node);
            parts[0] = parts[0].ToLower();
            return base.ToString("[{1}]({0}#{2})", parts);
        }
    }
}