namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    using Sem.Tools;

    internal class MdConverterType : MarkdownBase
    {
        public MdConverterType(XElement el) : base(el) { }

        public override string ToString()
        {
            var name = this.Node.Attribute("name")?.Value.Substring(2);
            var content = this.ToMarkDown(this.Node.Nodes());

            return $"## [Type: {name}](#Ref{name.Hash()})\n\n{content}\n\n---\n";
        }
    }
}