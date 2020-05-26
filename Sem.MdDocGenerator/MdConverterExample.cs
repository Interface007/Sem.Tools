// <copyright file="MdConverterExample.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converts the description of an example.
    /// </summary>
    public class MdConverterExample : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterExample"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterExample(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString() => $"_C# code_\n\n```c#\n{ToCodeBlock(this.Node.Value)}\n```\n\n";
    }
}