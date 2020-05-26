// <copyright file="MdConverterSeePage.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    /// <summary>
    /// Converts a reference to another method/type.
    /// </summary>
    public class MdConverterSeePage : MarkdownBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MdConverterSeePage"/> class.
        /// </summary>
        /// <param name="element">The element to be converted.</param>
        /// <param name="context">The current execution context.</param>
        public MdConverterSeePage(XElement element, AssemblyContext context)
            : base(element, context)
        {
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var parts = this.DefaultConvert("cref", this.Node);
            var className = string.Empty;
            var ns = this.Context.NameSpace;
            var anchor = string.Empty;
            var part = parts[0];
            if (part[0] == 'T')
            {
                className = part.Substring(2);
                ns = part.Contains("<", StringComparison.Ordinal)
                    ? part.Substring(0, part.IndexOf('<', StringComparison.Ordinal) - 1)
                    : part;
                ns = ns[2..ns.LastIndexOf('.')];
                anchor = "type-" + Anchor(className);
            }
            else if (part[0] == 'M')
            {
                ns = part.Contains("(", StringComparison.Ordinal)
                    ? part.Substring(0, part.IndexOf('(', StringComparison.Ordinal) - 1)
                    : part;
                ns = ns[2..ns.LastIndexOf('.')];

                className = this.FixMethodName(part);
                anchor = "method-" + Anchor(className);
            }

            var file = this.Context.Files
                .Where(x => ns.StartsWith(x, StringComparison.Ordinal))
                .OrderByDescending(x => x.Length)
                .FirstOrDefault();

            return string.IsNullOrEmpty(file) ? $"```{className}```" : $"[{className}]({file}.md#{anchor})";
        }

        /// <summary>
        /// Creates an anchor md-string.
        /// </summary>
        /// <param name="name">The name of the referenced element.</param>
        /// <returns>The expected anchor name.</returns>
        private static string Anchor(string name) =>
            Regex.Replace(
                name
                    .Replace(" ", "-", StringComparison.Ordinal)
                    .ToLowerInvariant(),
                "[^a-z-]",
                string.Empty);
    }
}