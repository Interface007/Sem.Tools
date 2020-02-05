// <copyright file="MdConverterField.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converter for field descriptions.
    /// </summary>
    internal class MdConverterField : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterField"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterField(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            // we don't describe fields, because they represent internal state.
            return string.Empty;
        }
    }
}