// <copyright file="ClassExtensions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Sem.Tools;

    /// <summary>
    /// Tests the class <see cref="ClassExtensions"/>.
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// Tests the method <see cref="ClassExtensions.Hash"/>.
        /// </summary>
        [TestClass]
        public class Hash
        {
            /// <summary>
            /// Tests whether an empty string is accepted and returns the correct hash value.
            /// </summary>
            [TestMethod]
            public void CorrectHashForEmptyString()
            {
                var expected = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
                var result = string.Empty.Hash();
                Assert.AreEqual(expected, result);
            }

            /// <summary>
            /// Tests whether a null string is accepted and returns the correct hash value.
            /// </summary>
            [TestMethod]
            public void CorrectHashForNull()
            {
                var expected = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
                var result = ((string)null).Hash();
                Assert.AreEqual(expected, result);
            }

            /// <summary>
            /// Tests whether a known string returns a defined value.
            /// </summary>
            [TestMethod]
            public void CorrectHashForKnownString()
            {
                var expected = "d32b568cd1b96d459e7291ebf4b25d007f275c9f13149beeb782fac0716613f8";
                var result = "Franz jagt im komplett verwahrlosten Taxi quer durch Bayern".Hash();
                Assert.AreEqual(expected, result);
            }
        }

        /// <summary>
        /// Tests the method <see cref="ClassExtensions.MustNotBeNull"/>.
        /// </summary>
        [TestClass]
        public class MustNotBeNull
        {
            /// <summary>
            /// Tests whether the method throws an exception for NULL-values.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            [ExcludeFromCodeCoverage]
            public void ThrowsExceptionForNullValue()
            {
                var x = (object)null;

                // ReSharper disable once AssignNullToNotNullAttribute
                x.MustNotBeNull("value");
            }

            /// <summary>
            /// Tests whether the method accepts non-null values and returns them.
            /// </summary>
            [TestMethod]
            public void DoesNotThrowExceptionForNonNullValue()
            {
                var result = ((object)"Hello").MustNotBeNull("value");
                Assert.AreEqual("Hello", result);
            }
        }

        /// <summary>
        /// Tests the method <see cref="ClassExtensions.MustNotBeNullOrEmpty"/>.
        /// </summary>
        [TestClass]
        public class MustNotBeNullOrEmpty
        {
            /// <summary>
            /// Tests whether the method throws an exception for NULL-values.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            [ExcludeFromCodeCoverage]
            public void ThrowsExceptionForNullValue()
            {
                var x = (string)null;

                // ReSharper disable once AssignNullToNotNullAttribute
                x.MustNotBeNullOrEmpty("value");
            }

            /// <summary>
            /// Tests whether the method throws an exception for <see cref="string.Empty"/>.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            [ExcludeFromCodeCoverage]
            public void ThrowsExceptionForEmptyValue()
            {
                string.Empty.MustNotBeNullOrEmpty("value");
            }

            /// <summary>
            /// Tests whether the method accepts non-null values and returns them.
            /// </summary>
            [TestMethod]
            public void DoesNotThrowExceptionForNonNullValue()
            {
                var result = "Hello".MustNotBeNull("value");
                Assert.AreEqual("Hello", result);
            }
        }

        /// <summary>
        /// Tests the method <see cref="Extensions.ToJson{T}"/>.
        /// </summary>
        [TestClass]
        public class ToJson
        {
            /// <summary>
            /// Tests whether a known structure is still serialized the same.
            /// </summary>
            [TestMethod]
            public void SerializesKnownStructure()
            {
                var target = new List<KeyValuePair<string, int>>
                {
                    new KeyValuePair<string, int>("hello", 1),
                    new KeyValuePair<string, int>("you", 2),
                };

                var result = target.ToJson();
                var expected = "[\r\n  {\r\n    \"Key\": \"hello\",\r\n    \"Value\": 1\r\n  },\r\n  {\r\n    \"Key\": \"you\",\r\n    \"Value\": 2\r\n  }\r\n]";
                Assert.AreEqual(expected, result);
            }
        }
    }
}