namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterSeeAnchor : MarkdownBase
    {
        public MdConverterSeeAnchor(XElement el) : base(el) { }

        public override string ToString()
        {
            var parts = d("cref", this.Node, this.NameSpace);
            parts[0] = parts[0].ToLower();
            return base.ToString("[{1}]({0}#{2})", parts);
        }
    }
}