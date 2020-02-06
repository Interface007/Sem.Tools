// <copyright file="TestClass.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Tests
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Simple test class for serialization.
    /// </summary>
    public class TestClass
    {
        /// <summary>
        /// Gets or sets a string that will be encrypted while serialization.
        /// </summary>
        [JsonConverter(typeof(EncryptionConverter))]
        public string EncryptedString { get; set; }

        /// <summary>
        /// Gets or sets a property with a base class declaration.
        /// </summary>
        [JsonConverter(typeof(InheritanceConverter<SourceBase>))]
        public SourceBase Source { get; set; }
    }
}