namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterDoc : MarkdownBase
    {
        public MdConverterDoc(XElement node) : base(node)
        {
            this.NameSpace = this.Node.Element("assembly")?.Element("name")?.Value;
        }

        public override string ToString()
        {
            var nodes = this.Node.Element("members")?.Elements("member");
            var content = ToMarkDown(nodes);
            return $"# {this.NameSpace} (#{this.NameSpace})\n\n{content}\n\n---\n";
        }
    }
}