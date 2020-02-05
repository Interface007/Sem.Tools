// <copyright file="MdConverterReturns.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converter for a "returns" element.
    /// </summary>
    public class MdConverterReturns : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterReturns"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterReturns(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"\n#### Returns:\n{this.ToMarkDown(this.Node.Nodes())}\n\n";
        }
    }
}