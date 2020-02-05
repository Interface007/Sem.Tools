// <copyright file="MdConverterSummary.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converts a summary.
    /// </summary>
    public class MdConverterSummary : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterSummary"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterSummary(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.ToMarkDown(this.Node.Nodes()) + "\n\n";
        }
    }
}