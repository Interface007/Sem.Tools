// <copyright file="MdConverterParamref.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converter for a parameter reference.
    /// </summary>
    public class MdConverterParamref : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterParamref"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterParamref(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.ToString(" {0} ");
        }
    }
}