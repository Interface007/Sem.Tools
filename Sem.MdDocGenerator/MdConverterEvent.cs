// <copyright file="MdConverterEvent.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converts event descriptions.
    /// </summary>
    public class MdConverterEvent : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterEvent"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterEvent(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.ToString("### {0} (#{0})\n\n{1}\n");
        }
    }
}