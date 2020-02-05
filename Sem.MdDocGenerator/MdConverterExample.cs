namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterExample : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterType"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterExample(XElement el, AssemblyContext context)
            : base(el, context)
        {
        }

        public override string ToString()
        {
            return $"_C# code_\n\n```c#\n{ToCodeBlock(this.Node.Value)}\n```\n\n";
        }
    }
}