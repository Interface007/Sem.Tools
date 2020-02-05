// <copyright file="MdConverterType.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converts a type documentation.
    /// </summary>
    internal class MdConverterType : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterType"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterType(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var name = this.Node.Attribute("name")?.Value.Substring(2);
            var content = this.ToMarkDown(this.Node.Nodes());

            return $"---\n## Type: {name?.Trim()}\n\n{content}\n\n";
        }
    }
}