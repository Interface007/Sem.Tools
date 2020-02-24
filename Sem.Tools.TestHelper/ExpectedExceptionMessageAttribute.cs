// <copyright file="ExpectedExceptionMessageAttribute.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

// ReSharper disable MemberCanBePrivate.Global
namespace Sem.Tools.TestHelper
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Replaces the <see cref="ExpectedExceptionAttribute"/> and provides a <see cref="Regex"/> expression to check
    /// whether the correct exception message has been thrown in addition to the expected exception type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ExpectedExceptionMessageAttribute : ExpectedExceptionBaseAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectedExceptionMessageAttribute"/> class.
        /// </summary>
        /// <param name="exceptionType">The expected type of exception thrown by the code under test.</param>
        /// <param name="messageRegexPattern">RegEx to test for the message of the exception thrown by the code under test.</param>
        public ExpectedExceptionMessageAttribute(Type exceptionType, string messageRegexPattern)
        {
            if (exceptionType == null)
            {
                throw new ArgumentNullException(nameof(exceptionType));
            }

            if (!typeof(Exception).GetTypeInfo().IsAssignableFrom(exceptionType.GetTypeInfo()))
            {
                throw new ArgumentException("Expected exception type must derive from exception", nameof(exceptionType));
            }

            this.ExceptionType = exceptionType;
            this.MessageRegexPattern = messageRegexPattern;
        }

        /// <summary>
        /// Gets or sets the expected RegEx pattern for the exception message that should be thrown by the code under test.
        /// </summary>
        public string MessageRegexPattern { get; set; }

        /// <summary>
        /// Gets or sets the expected type of the exception that should be thrown by the code under test.
        /// </summary>
        public Type ExceptionType { get; set; }

        /// <summary>
        /// Determines whether the exception is expected. If the method returns, then it is
        /// understood that the exception was expected. If the method throws an exception, then it
        /// is understood that the exception was not expected, and the thrown exception's message
        /// is included in the test result. The <see cref="Assert" /> class can be used for
        /// convenience. If <see cref="Assert.Inconclusive()" /> is used and the assertion fails,
        /// then the test outcome is set to Inconclusive.
        /// </summary>
        /// <param name="exception">The exception thrown by the unit test.</param>
        protected override void Verify(Exception exception)
        {
            var type = exception.MustNotBeNull(nameof(exception)).GetType();
            if (!this.ExceptionType.GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
            {
                this.RethrowIfAssertException(exception);
                var message = string.Format(
                    CultureInfo.CurrentCulture,
                    "Wrong exception of type {0}; expected exception type should derive from: {1}; exception message: {2}",
                    type.FullName,
                    this.ExceptionType.FullName,
                    GetExceptionMsg(exception));
                throw new Exception(message);
            }

            if (!Regex.IsMatch(exception.Message, this.MessageRegexPattern))
            {
                this.RethrowIfAssertException(exception);
                var message = string.Format(
                    CultureInfo.CurrentCulture,
                    "Wrong exception message. Expected RegEx pattern: '{0}'; actual message '{1}'; full exception messages: {2}",
                    this.MessageRegexPattern,
                    exception.Message,
                    GetExceptionMsg(exception));
                throw new Exception(message);
            }
        }

        [ExcludeFromCodeCoverage]
        private static string GetExceptionMsg(Exception ex)
        {
            var stringBuilder = new StringBuilder();
            var flag = true;
            for (var exception = ex; exception != null; exception = exception.InnerException)
            {
                string str;
                try
                {
                    str = exception.Message;
                }
                catch
                {
                    // searching for a way to test this ...
                    str = string.Format(CultureInfo.CurrentCulture, "Failed to get exception message for type {0}", exception.GetType());
                }

                stringBuilder.Append(string.Format(CultureInfo.CurrentCulture, "{0}{1}: {2}", flag ? string.Empty : " ---> ", exception.GetType(), str));
                flag = false;
            }

            return stringBuilder.ToString();
        }
    }
}
