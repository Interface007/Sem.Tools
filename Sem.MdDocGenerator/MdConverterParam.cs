// <copyright file="MdConverterParam.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converter for method parameter documentation.
    /// </summary>
    public class MdConverterParam : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterParam"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterParam(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var i = (this.Node.PreviousNode as XElement)?.Name.LocalName != this.Node?.Name.LocalName;
            return this.ToString(i ? "#### Parameters:\n|Name | Description |\n|-----|------|\n|{0}|{1}|\n" : "|{0}: |{1}|\n");
        }
    }
}