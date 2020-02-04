using Sem.Tools;

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    internal class MdConverterMethod : MarkdownBase
    {
        public MdConverterMethod(XElement el, AssemblyContext context)
            : base(el, context)
        {
        }

        public override string ToString()
        {
            var content = this.ToMarkDown(Node.Nodes());

            var value = Node
                .Attribute("name")?
                .Value;

            var name = this.FixMethodName(value);

            return $"### Method: {name}\n\n{content}\n";
        }
    }
}