// <copyright file="MdConverterException.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converts the exception description.
    /// </summary>
    public class MdConverterException : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterException"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterException(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var parts = this.DefaultConvert("cref", this.Node);
            return ToString("[[{0}|{0}]]: {1}\n\n", parts);
        }
    }
}