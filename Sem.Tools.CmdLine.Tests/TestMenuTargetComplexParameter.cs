// <copyright file="TestMenuTargetComplexParameter.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Just a simple complex class used as a parameter for test.
    /// </summary>
    public class TestMenuTargetComplexParameter
    {
        /// <summary>
        /// Gets or sets a simple property.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public string Sample1 { get; set; }
    }
}