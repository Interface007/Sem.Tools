using Sem.Tools;

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    internal class MdConverterMethod : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterType"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
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