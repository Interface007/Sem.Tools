using Sem.Tools;

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    internal class MdConverterMethod : MarkdownBase
    {
        public MdConverterMethod(XElement el, string nameSpace) : base(el, nameSpace) { }

        public override string ToString()
        {
            var content = this.ToMarkDown(Node.Nodes());

            var value = Node
                .Attribute("name")?
                .Value;

            var name = this.FixMethodName(value);

            return $"### [Method: {name}](#Ref{value.Hash()})\n\n{content}\n\n---\n";
        }
    }
}