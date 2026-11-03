// <copyright file="ClassExceptionAssert.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.TestHelper.Tests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the class <see cref="ExceptionAssert"/>.
    /// </summary>
    public static class ClassExceptionAssert
    {
        /// <summary>
        /// Tests the method <see cref="ExceptionAssert.ThrowsExactly{TException}"/>.
        /// </summary>
        [TestClass]
        public class ThrowsExactly
        {
            /// <summary>
            /// Correct exception type and message is accepted.
            /// </summary>
            [TestMethod]
            public void CorrectExceptionIsAccepted()
            {
                var result = ExceptionAssert.ThrowsExactly<ArgumentException>(() => throw new ArgumentException("matching string"), "matching string");
                Assert.AreEqual("matching string", result.Message);
            }

            /// <summary>
            /// Wrong exception type fails the assertion.
            /// </summary>
            [TestMethod]
            public void FailsWithWrongType() =>
                Assert.ThrowsExactly<AssertFailedException>(
                    () => ExceptionAssert.ThrowsExactly<ArgumentException>(() => throw new AccessViolationException(), "matching string"));

            /// <summary>
            /// Wrong exception message fails the assertion with a descriptive message.
            /// </summary>
            [TestMethod]
            public void FailsWithWrongMessage()
            {
                var result = Assert.ThrowsExactly<AssertFailedException>(
                    () => ExceptionAssert.ThrowsExactly<ArgumentException>(() => throw new ArgumentException("something went wrong"), "matching string"));
                StringAssert.Matches(result.Message, new System.Text.RegularExpressions.Regex("Wrong exception message. Expected RegEx pattern: '.*'; actual message '.*'; full exception messages: .*"));
            }

            /// <summary>
            /// Failure message includes inner exceptions.
            /// </summary>
            [TestMethod]
            public void IncludesInnerExceptions()
            {
                var result = Assert.ThrowsExactly<AssertFailedException>(
                    () => ExceptionAssert.ThrowsExactly<ArgumentException>(() => throw new ArgumentException("something went wrong", new InvalidOperationException("from inner exception")), "matching string"));
                StringAssert.Contains(result.Message, "from inner exception");
            }
        }

        /// <summary>
        /// Tests the method <see cref="ExceptionAssert.ThrowsExactlyAsync{TException}"/>.
        /// </summary>
        [TestClass]
        public class ThrowsExactlyAsync
        {
            /// <summary>
            /// Correct exception type and message is accepted.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task CorrectExceptionIsAccepted()
            {
                var result = await ExceptionAssert.ThrowsExactlyAsync<InvalidOperationException>(() => Task.FromException(new InvalidOperationException("matching string")), "matching").ConfigureAwait(false);
                Assert.AreEqual("matching string", result.Message);
            }

            /// <summary>
            /// Wrong exception message fails the assertion.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task FailsWithWrongMessage() =>
                await Assert.ThrowsExactlyAsync<AssertFailedException>(
                    () => ExceptionAssert.ThrowsExactlyAsync<InvalidOperationException>(() => Task.FromException(new InvalidOperationException("other")), "matching"))
                    .ConfigureAwait(false);
        }
    }
}