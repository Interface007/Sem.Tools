using System.Xml.Linq;

namespace Sem.MdDocGenerator
{
    public class MdConverterNone : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterType"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterNone(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}