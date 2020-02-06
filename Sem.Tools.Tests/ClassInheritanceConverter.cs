// <copyright file="ClassInheritanceConverter.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the class <see cref="InheritanceConverter{TType}"/>.
    /// </summary>
    public static class ClassInheritanceConverter
    {
        /// <summary>
        /// Tests the serialization.
        /// </summary>
        [TestClass]
        public class Serialize
        {
            /// <summary>
            /// Serialized value should contain the inherited property.
            /// </summary>
            [TestMethod]
            public void SerializesInheritedProperties()
            {
                var target = new TestClass
                {
                    Source = new ItemSource
                    {
                        InBaseClass = "ok",
                        InInheritingClass = "also ok",
                    },
                };

                var actual = target.ToJson();
                const string expected = "\"InBaseClass\": \"ok\"";
                Assert.IsTrue(actual.Contains(expected, StringComparison.Ordinal));
            }

            /// <summary>
            /// Tests whether inherited properties are being deserializes properly.
            /// </summary>
            [TestMethod]
            public void DeSerializesInheritedProperties()
            {
                const string serialized = "{\"Source\": {\"$type\": \"Sem.Tools.Tests.ItemSource, Sem.Tools.Tests\",\"Data\": {\"InInheritingClass\": \"also ok\",\"InBaseClass\": \"ok\"}}}";

                var actual = serialized.FromJson<TestClass>();
                var actualSource = (ItemSource)actual.Source;
                Assert.AreEqual("ok", actualSource.InBaseClass);
                Assert.AreEqual("also ok", actualSource.InInheritingClass);
            }
        }
    }
}