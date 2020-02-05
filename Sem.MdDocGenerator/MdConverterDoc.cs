namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterDoc : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterType"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterDoc(XElement node, AssemblyContext context)
            : base(node, context)
        {
        }

        public override string ToString()
        {
            var nodes = this.Node.Element("members")?.Elements("member");
            var content = ToMarkDown(nodes);
            return $"# [{this.Context.NameSpace.Trim()}](#{this.Context.NameSpace})\n\n{content}\n\n---\n";
        }
    }
}