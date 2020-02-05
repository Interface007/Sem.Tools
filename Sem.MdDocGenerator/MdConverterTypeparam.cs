// <copyright file="MdConverterTypeparam.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converter fpr type parameters.
    /// </summary>
    public class MdConverterTypeparam : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterTypeparam"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterTypeparam(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var sameAsPrevious = (this.Node.PreviousNode as XElement)?.Name.LocalName != this.Node?.Name.LocalName;
            return this.ToString(sameAsPrevious ? "#### Type parameters:\n|Name | Description |\n|-----|------|\n|{0}|{1}|\n" : "|{0}: |{1}|\n");
        }
    }
}