// <copyright file="AssemblyContext.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    /// <summary>
    /// Contains some additions context information about the current assembly.
    /// </summary>
    public class AssemblyContext
    {
        /// <summary>
        /// Gets or sets the namespace of the current assembly.
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// Gets or sets the files to be processed in this conversion.
        /// </summary>
        public string[] Files { get; set; }
    }
}