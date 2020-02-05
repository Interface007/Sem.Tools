// <copyright file="MdConverterMethod.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converter for method descriptions.
    /// </summary>
    internal class MdConverterMethod : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterMethod"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterMethod(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var content = this.ToMarkDown(this.Node.Nodes());

            var value = this.Node
                .Attribute("name")?
                .Value;

            var name = this.FixMethodName(value);
            return $"### Method: {name}\n\n{content}\n";
        }
    }
}