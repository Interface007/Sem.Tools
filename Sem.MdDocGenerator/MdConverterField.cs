namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    internal class MdConverterField : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterType"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterField(XElement el,AssemblyContext context) : base(el,context) { }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}