namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterEvent : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterType"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterEvent(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            return base.ToString("### {0} (#{0})\n\n{1}\n");
        }
    }
}