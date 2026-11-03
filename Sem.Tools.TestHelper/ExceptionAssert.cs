// <copyright file="ExceptionAssert.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.TestHelper
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Replacement for the former <c>ExpectedExceptionMessageAttribute</c>: builds on top of
    /// <see cref="Assert.ThrowsExactly{TException}(Action, string, object[])"/> and additionally checks
    /// the exception message against a <see cref="Regex"/> pattern.
    /// </summary>
    public static class ExceptionAssert
    {
        /// <summary>
        /// Asserts that <paramref name="action"/> throws exactly <typeparamref name="TException"/>
        /// with a message matching <paramref name="messageRegexPattern"/>.
        /// </summary>
        /// <typeparam name="TException">The exact expected exception type.</typeparam>
        /// <param name="action">The code under test.</param>
        /// <param name="messageRegexPattern">RegEx pattern the exception message must match.</param>
        /// <returns>The thrown exception.</returns>
        public static TException ThrowsExactly<TException>(Action action, string messageRegexPattern)
            where TException : Exception
        {
            var exception = Assert.ThrowsExactly<TException>(action);
            VerifyMessage(exception, messageRegexPattern);
            return exception;
        }

        /// <summary>
        /// Asserts that <paramref name="action"/> throws exactly <typeparamref name="TException"/>
        /// with a message matching <paramref name="messageRegexPattern"/>.
        /// </summary>
        /// <typeparam name="TException">The exact expected exception type.</typeparam>
        /// <param name="action">The asynchronous code under test.</param>
        /// <param name="messageRegexPattern">RegEx pattern the exception message must match.</param>
        /// <returns>The thrown exception.</returns>
        public static async Task<TException> ThrowsExactlyAsync<TException>(Func<Task> action, string messageRegexPattern)
            where TException : Exception
        {
            var exception = await Assert.ThrowsExactlyAsync<TException>(action).ConfigureAwait(false);
            VerifyMessage(exception, messageRegexPattern);
            return exception;
        }

        private static void VerifyMessage(Exception exception, string messageRegexPattern)
        {
            if (!Regex.IsMatch(exception.Message, messageRegexPattern ?? string.Empty))
            {
                Assert.Fail(string.Format(
                    CultureInfo.CurrentCulture,
                    "Wrong exception message. Expected RegEx pattern: '{0}'; actual message '{1}'; full exception messages: {2}",
                    messageRegexPattern,
                    exception.Message,
                    GetExceptionMsg(exception)));
            }
        }

        private static string GetExceptionMsg(Exception ex)
        {
            var stringBuilder = new StringBuilder();
            var first = true;
            for (var exception = ex; exception != null; exception = exception.InnerException)
            {
                _ = stringBuilder
                    .Append(first ? string.Empty : " ---> ")
                    .Append(exception.GetType())
                    .Append(": ")
                    .Append(exception.Message);
                first = false;
            }

            return stringBuilder.ToString();
        }
    }
}
