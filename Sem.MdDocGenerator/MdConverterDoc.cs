// <copyright file="MdConverterDoc.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    /// <summary>
    /// Converts a "doc" node.
    /// </summary>
    public class MdConverterDoc : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterDoc"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterDoc(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var nodes = this.Node.Element("members")?.Elements("member");
            var content = this.ToMarkDown(nodes);
            return $"# [{this.Context.NameSpace.Trim()}](#{this.Context.NameSpace})\n\n{content}\n\n---\n";
        }
    }
}