// <copyright file="ClassInheritanceConverter.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the class <see cref="EncryptionConverter"/>.
    /// </summary>
    public static class ClassEncryptionConverter
    {
        /// <summary>
        /// Tests the serialization.
        /// </summary>
        [TestClass]
        public class Serialize
        {
            /// <summary>
            /// Serialized value should encrypt the property with the <see cref="EncryptionConverter"/> attribute.
            /// </summary>
            [TestMethod]
            public void SerializesInheritedProperties()
            {
                var target = new TestClass
                {
                    EncryptedString = "A15A3685-55CC-4634-972D-436DA6BE9268",
                };

                var actual = target.ToJson();
                const string expected = "\"EncryptedString\": \"";
                const string notExpected = "A15A3685-55CC-4634-972D-436DA6BE9268";
                Assert.IsTrue(actual.Contains(expected, StringComparison.Ordinal));
                Assert.IsFalse(actual.Contains(notExpected, StringComparison.OrdinalIgnoreCase));
            }

            /// <summary>
            /// Previously encrypted value can be restored.
            /// </summary>
            [TestMethod]
            public void DeSerializesInheritedProperties()
            {
                var target = new TestClass
                {
                    EncryptedString = "A15A3685-55CC-4634-972D-436DA6BE9268",
                };

                var actual = target.ToJson().FromJson<TestClass>();
                const string expected = "A15A3685-55CC-4634-972D-436DA6BE9268";

                Assert.AreEqual(expected, actual.EncryptedString);

            }
        }
    }
}