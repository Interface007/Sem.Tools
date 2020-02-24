// <copyright file="ClassLogScope.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

// ReSharper disable UnusedVariable
namespace Sem.Tools.Logging.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the class <see cref="LogScope"/>.
    /// </summary>
    public static class ClassLogScope
    {
        /// <summary>
        /// Tests the constructor(s) for <see cref="LogScope"/>.
        /// </summary>
        [TestClass]
        public class LogScopeConstructor : LoggerTestBase
        {
            /// <summary>
            /// Tests whether the ctor log line is formatted correctly.
            /// </summary>
            [TestMethod]
            public void LogsScopeStart()
            {
                using var logScope = LogScope.Create("NewScope", this.LogMethod);

                var expected = "Technical, Trace, /0004, NewScope - Starting scope NewScope in member LogsScopeStart of ClassLogScope.cs.";

                Assert.AreEqual(1, this.LogMessages.Count);
                Assert.AreEqual(expected, this.LogMessages[0]);
            }
        }

        /// <summary>
        /// Tests the method for <see cref="LogScope.Dispose"/>.
        /// </summary>
        [TestClass]
        public class Dispose : LoggerTestBase
        {
            /// <summary>
            /// Tests whether the destructor log line is formatted correctly.
            /// </summary>
            [TestMethod]
            public void LogsScopeEnd()
            {
                using (var logScope = LogScope.Create("NewScope", this.LogMethod))
                {
                    this.LogMessages.Clear();
                }

                var expected = "Technical, Trace, /0004, NewScope - Finished scope - Data: \\{\"scopeName\":\"NewScope\",\"ms\":\\d+\\.\\d+\\}";

                Assert.AreEqual(1, this.LogMessages.Count);
                Assert.IsTrue(Regex.IsMatch(this.LogMessages[0], expected));
            }

            /// <summary>
            /// Tests whether the indentation of logs is correct.
            /// </summary>
            [TestMethod]
            public void LogsScopeStart()
            {
                using (var logScopeLevel1 = LogScope.Create("NewScope", this.LogMethod))
                {
                    Assert.IsTrue(Regex.IsMatch(this.LogMessages.Last(), "Trace, /\\d{4}, NewScope"));
                    using (var logScopeLevel2 = logScopeLevel1.Child("ChildScope"))
                    {
                        Assert.IsTrue(Regex.IsMatch(this.LogMessages.Last(), "Trace, /\\d{4}/\\d{4}, ChildScope"));
                    }

                    Assert.IsTrue(Regex.IsMatch(this.LogMessages.Last(), "Trace, /\\d{4}/\\d{4}, ChildScope"));
                }

                Assert.IsTrue(Regex.IsMatch(this.LogMessages.Last(), "Trace, /\\d{4}, NewScope"));
            }
        }

        /// <summary>
        /// Tests the method <see cref="LogScope.Child"/>.
        /// </summary>
        [TestClass]
        public class Child : LoggerTestBase
        {
            /// <summary>
            /// Tests whether the ctor log line is formatted correctly.
            /// </summary>
            [TestMethod]
            public void StartingChildScopeAddsIdToHierarchy()
            {
                using var logScope = LogScope.Create("NewScope", this.LogMethod);
                this.LogMessages.Clear();

                using var target = logScope.Child("the child");
                var expected = "Technical, Trace, /0004/0005, the child - Starting scope the child in member StartingChildScopeAddsIdToHierarchy of ClassLogScope.cs.";

                Assert.AreEqual(1, this.LogMessages.Count);
                Assert.AreEqual(expected, this.LogMessages[0]);
            }
        }

        /// <summary>
        /// Tests the method <see cref="LogScope.DisposeAsync"/>.
        /// </summary>
        [TestClass]
        public class AsyncDispose : LoggerTestBase
        {
            /// <summary>
            /// Tests whether the method <see cref="LogScope.DisposeAsync"/> logs correctly.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task AsyncDisposeCorrectlyLogsEndOfScope()
            {
                await using (var logScope = LogScope.Create("NewScope", this.LogMethod))
                {
                    this.LogMessages.Clear();
                }

                const string expected = "Technical, Trace, /0004, NewScope - Finished scope - Data: {\"scopeName\":\"NewScope\",\"ms\":";
                Assert.IsTrue(this.LogMessages[0].StartsWith(expected, StringComparison.Ordinal));
            }
        }

        /// <summary>
        /// Tests the static property <see cref="LogScope.LogMethod"/>.
        /// </summary>
        [TestClass]
        public class LogMethod : LoggerTestBase
        {
            /// <summary>
            /// Uses the default log method when no log method has been provided.
            /// </summary>
            [TestMethod]
            public void DefaultMethodWillBeUsed()
            {
                var logs = new List<string>();
                LogScope.LogMethod = (categories, level, scope, message) => logs.Add(message);
                using var target = LogScope.Create("test");
                Assert.AreEqual("test - Starting scope test in member DefaultMethodWillBeUsed of ClassLogScope.cs.", logs[0]);
            }

            /// <summary>
            /// Explicit method overrides default method.
            /// </summary>
            [TestMethod]
            public void ExplicitOverridesDefaultMethod()
            {
                var logs1 = new List<string>();
                var logs2 = new List<string>();
                void Log2(LogCategories categories, LogLevel level, LogScope scope, string message) => logs2.Add(message);
                LogScope.LogMethod = this.Log1;
                using var target = LogScope.Create("test", Log2);
                Assert.AreEqual("test - Starting scope test in member ExplicitOverridesDefaultMethod of ClassLogScope.cs.", logs2[0]);
            }

            /// <summary>
            /// Explicit method overrides default method.
            /// </summary>
            [TestMethod]
            public void NullLogMethodDoesNotThrowExceptions()
            {
                LogScope.LogMethod = null;
                using var target = LogScope.Create("test");
            }

            /// <summary>
            /// Test log method that throws an exception (should not be called).
            /// </summary>
            /// <param name="categories">The categories of the log entry.</param>
            /// <param name="level">The log level.</param>
            /// <param name="scope">The scope logging the message.</param>
            /// <param name="message">The message to be logged.</param>
            [ExcludeFromCodeCoverage]
            private void Log1(LogCategories categories, LogLevel level, LogScope scope, string message)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Tests the method <see cref="LogScope.BasePath"/>.
        /// </summary>
        [TestClass]
        public class BasePath : LoggerTestBase
        {
            /// <summary>
            /// Non-determined base path does not create problems.
            /// </summary>
            [TestMethod]
            public void ExplicitNullBasePathIsAccepted()
            {
                var basePath = LogScope.BasePath;
                LogScope.BasePath = null;
                using var target = LogScope.Create("test");
                LogScope.BasePath = basePath;
            }
        }

        /// <summary>
        /// Tests the method <see cref="LogScope.MethodStart"/>.
        /// </summary>
        [TestClass]
        public class MethodStart : LoggerTestBase
        {
            /// <summary>
            /// Tests whether the method <see cref="LogScope.MethodStart"/> logs correctly the parameters.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task ParametersAreCorrectlyLogged()
            {
                await using (var logScope = LogScope.Create("NewScope", this.LogMethod))
                {
                    this.LogMessages.Clear();
                    await using var subScope = logScope.MethodStart(new { this.LogMessages.Count, test = "true" });
                }

                Assert.AreEqual("Technical, Trace, /0004/0005, MethodScope - Starting scope MethodScope in member ParametersAreCorrectlyLogged of ClassLogScope.cs.", this.LogMessages[0]);
                Assert.AreEqual("Technical, Information, /0004/0005, MethodScope - scope value:  - Data: {\"Count\":0,\"test\":\"true\"}", this.LogMessages[1]);
            }
        }

        /// <summary>
        /// Tests the method <see cref="LogScope.DefaultCategory"/>.
        /// </summary>
        [TestClass]
        public class DefaultCategory : LoggerTestBase
        {
            /// <summary>
            /// Tests whether the property <see cref="LogScope.DefaultCategory"/> sets the default logging category.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task OnlyMatchingLogMessagesAreLogged()
            {
                var category = LogScope.DefaultCategory;
                try
                {
                    LogScope.DefaultCategory = LogCategories.Business;
                    await using (var logScope = LogScope.Create("NewScope", this.LogMethod))
                    {
                        this.LogMessages.Clear();
                        logScope.Log(LogCategories.Business, LogLevel.Information, "test1");
                        logScope.Log(LogCategories.Technical, LogLevel.Information, "test2");
                        Assert.AreEqual(1, this.LogMessages.Count);
                        Assert.AreEqual("Business, Information, /0004, NewScope - test1", this.LogMessages[0]);
                    }

                    LogScope.DefaultCategory = LogCategories.Technical;
                    await using (var logScope = LogScope.Create("NewScope", this.LogMethod))
                    {
                        this.LogMessages.Clear();
                        logScope.Log(LogCategories.Business, LogLevel.Information, "test1");
                        logScope.Log(LogCategories.Technical, LogLevel.Information, "test2");
                        Assert.AreEqual(1, this.LogMessages.Count);
                        Assert.AreEqual("Technical, Information, /0004, NewScope - test2", this.LogMessages[0]);
                    }
                }
                finally
                {
                    LogScope.DefaultCategory = category;
                }
            }
        }

        /// <summary>
        /// Tests the method <see cref="LogScope.DefaultLevel"/>.
        /// </summary>
        [TestClass]
        public class DefaultLevel : LoggerTestBase
        {
            /// <summary>
            /// Tests whether the property <see cref="LogScope.DefaultLevel"/> sets the default logging level.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task OnlyMatchingLogMessagesAreLogged()
            {
                var level = LogScope.DefaultLevel;
                try
                {
                    LogScope.DefaultLevel = LogLevel.Information;
                    await using (var logScope = LogScope.Create("NewScope", this.LogMethod))
                    {
                        this.LogMessages.Clear();
                        logScope.Log(LogCategories.Business, LogLevel.Information, "test1");
                        logScope.Log(LogCategories.Technical, LogLevel.Trace, "test2");
                        Assert.AreEqual(1, this.LogMessages.Count);
                        Assert.AreEqual("Business, Information, /0004, NewScope - test1", this.LogMessages[0]);
                    }

                    LogScope.DefaultLevel = LogLevel.Trace;
                    await using (var logScope = LogScope.Create("NewScope", this.LogMethod))
                    {
                        this.LogMessages.Clear();
                        logScope.Log(LogCategories.Business, LogLevel.Information, "test1");
                        logScope.Log(LogCategories.Technical, LogLevel.Trace, "test2");
                        Assert.AreEqual(2, this.LogMessages.Count);
                        Assert.AreEqual("Business, Information, /0004, NewScope - test1", this.LogMessages[0]);
                        Assert.AreEqual("Technical, Trace, /0004, NewScope - test2", this.LogMessages[1]);
                    }
                }
                finally
                {
                    LogScope.DefaultLevel = level;
                }
            }
        }

        /// <summary>
        /// Tests the method <see cref="LogScope.Log(string,object)"/>.
        /// </summary>
        [TestClass]
        public class Log : LoggerTestBase
        {
            /// <summary>
            /// Tests whether <see cref="LogScope.Log(string,object)"/> logs using the correct category and level.
            /// </summary>
            [TestMethod]
            public void DefaultsToCorrectLevelAndCategory()
            {
                using var logScope = LogScope.Create("NewScope", this.LogMethod);
                this.LogMessages.Clear();

                Assert.AreEqual(0, this.LogMessages.Count);

                logScope.Log("Just a test");

                Assert.AreEqual(1, this.LogMessages.Count);
                Assert.AreEqual("Technical, Information, /0004, NewScope - Just a test", this.LogMessages[0]);
            }

            /// <summary>
            /// Tests whether <see cref="LogScope.Log(string,object)"/> logs only the specified level(s).
            /// </summary>
            [TestMethod]
            public void LogsOnlySpecifiedCategories()
            {
                using var logScope = LogScope.Create("NewScope", this.LogMethod);

                logScope.Category = LogCategories.Technical;
                this.LogMessages.Clear();
                logScope.Log(LogCategories.Technical, LogLevel.Trace, "Trace");
                Assert.AreEqual(1, this.LogMessages.Count);
                logScope.Log(LogCategories.Business, LogLevel.Trace, "Trace");
                Assert.AreEqual(1, this.LogMessages.Count);

                logScope.Category = LogCategories.Business;
                this.LogMessages.Clear();
                logScope.Log(LogCategories.Technical, LogLevel.Trace, "Trace");
                Assert.AreEqual(0, this.LogMessages.Count);
                logScope.Log(LogCategories.Business, LogLevel.Trace, "Trace");
                Assert.AreEqual(1, this.LogMessages.Count);

                logScope.Category = LogCategories.Business | LogCategories.Technical;
                this.LogMessages.Clear();
                logScope.Log(LogCategories.Technical, LogLevel.Trace, "Trace");
                Assert.AreEqual(1, this.LogMessages.Count);
                logScope.Log(LogCategories.Business, LogLevel.Trace, "Trace");
                Assert.AreEqual(2, this.LogMessages.Count);
            }

            /// <summary>
            /// Tests whether <see cref="LogScope.Log(string,object)"/> logs only the specified level(s).
            /// </summary>
            [TestMethod]
            public void LogsOnlyToSpecifiedLevel()
            {
                using var logScope = LogScope.Create("NewScope", this.LogMethod);
                this.LogMessages.Clear();

                Assert.AreEqual(0, this.LogMessages.Count);

                logScope.Level = LogLevel.Trace;
                logScope.Log(LogCategories.Technical, LogLevel.Trace, "Trace");
                logScope.Log(LogCategories.Technical, LogLevel.Information, "Information");
                logScope.Log(LogCategories.Technical, LogLevel.Warning, "Warning");
                logScope.Log(LogCategories.Technical, LogLevel.Exception, "Exception");
                Assert.AreEqual(4, this.LogMessages.Count);

                this.LogMessages.Clear();
                logScope.Level = LogLevel.Information;
                logScope.Log(LogCategories.Technical, LogLevel.Trace, "Trace");
                logScope.Log(LogCategories.Technical, LogLevel.Information, "Information");
                logScope.Log(LogCategories.Technical, LogLevel.Warning, "Warning");
                logScope.Log(LogCategories.Technical, LogLevel.Exception, "Exception");
                Assert.AreEqual(3, this.LogMessages.Count);

                this.LogMessages.Clear();
                logScope.Level = LogLevel.Warning;
                logScope.Log(LogCategories.Technical, LogLevel.Trace, "Trace");
                logScope.Log(LogCategories.Technical, LogLevel.Information, "Information");
                logScope.Log(LogCategories.Technical, LogLevel.Warning, "Warning");
                logScope.Log(LogCategories.Technical, LogLevel.Exception, "Exception");
                Assert.AreEqual(2, this.LogMessages.Count);

                this.LogMessages.Clear();
                logScope.Level = LogLevel.Exception;
                logScope.Log(LogCategories.Technical, LogLevel.Trace, "Trace");
                logScope.Log(LogCategories.Technical, LogLevel.Information, "Information");
                logScope.Log(LogCategories.Technical, LogLevel.Warning, "Warning");
                logScope.Log(LogCategories.Technical, LogLevel.Exception, "Exception");
                Assert.AreEqual(1, this.LogMessages.Count);
            }
        }
    }
}