// <copyright file="MdConverterSeeAnchor.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converter for an anchor reference.
    /// </summary>
    public class MdConverterSeeAnchor : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterSeeAnchor"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterSeeAnchor(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var parts = this.DefaultConvert("cref", this.Node);
            parts[0] = parts[0].ToLowerInvariant();
            return base.ToString("[{1}]({0}#{2})", parts);
        }
    }
}