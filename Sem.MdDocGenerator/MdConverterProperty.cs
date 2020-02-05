// <copyright file="MdConverterProperty.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converter for a code property.
    /// </summary>
    public class MdConverterProperty : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterProperty"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterProperty(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var x = this.DefaultConvert("name", this.Node);
            return $"### Property: {x[0].Substring(2)}\n\n{x[1]}\n";
        }
    }
}