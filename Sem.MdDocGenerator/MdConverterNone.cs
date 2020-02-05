// <copyright file="MdConverterNone.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Simply returns nothing when converting.
    /// </summary>
    public class MdConverterNone : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterNone"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterNone(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}