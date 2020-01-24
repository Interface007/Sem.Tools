// ReSharper disable UnusedVariable

using System.Linq;

namespace Sem.Tools.Logging.Tests
{
    using System.Text.RegularExpressions;

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

                logScope.Category = LogCategory.Technical;
                this.LogMessages.Clear();
                logScope.Log(LogCategory.Technical, LogLevel.Trace, "Trace");
                Assert.AreEqual(1, this.LogMessages.Count);
                logScope.Log(LogCategory.Business, LogLevel.Trace, "Trace");
                Assert.AreEqual(1, this.LogMessages.Count);

                logScope.Category = LogCategory.Business;
                this.LogMessages.Clear();
                logScope.Log(LogCategory.Technical, LogLevel.Trace, "Trace");
                Assert.AreEqual(0, this.LogMessages.Count);
                logScope.Log(LogCategory.Business, LogLevel.Trace, "Trace");
                Assert.AreEqual(1, this.LogMessages.Count);

                logScope.Category = LogCategory.Business | LogCategory.Technical;
                this.LogMessages.Clear();
                logScope.Log(LogCategory.Technical, LogLevel.Trace, "Trace");
                Assert.AreEqual(1, this.LogMessages.Count);
                logScope.Log(LogCategory.Business, LogLevel.Trace, "Trace");
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
                logScope.Log(LogCategory.Technical, LogLevel.Trace, "Trace");
                logScope.Log(LogCategory.Technical, LogLevel.Information, "Information");
                logScope.Log(LogCategory.Technical, LogLevel.Warning, "Warning");
                logScope.Log(LogCategory.Technical, LogLevel.Exception, "Exception");
                Assert.AreEqual(4, this.LogMessages.Count);

                this.LogMessages.Clear();
                logScope.Level = LogLevel.Information;
                logScope.Log(LogCategory.Technical, LogLevel.Trace, "Trace");
                logScope.Log(LogCategory.Technical, LogLevel.Information, "Information");
                logScope.Log(LogCategory.Technical, LogLevel.Warning, "Warning");
                logScope.Log(LogCategory.Technical, LogLevel.Exception, "Exception");
                Assert.AreEqual(3, this.LogMessages.Count);

                this.LogMessages.Clear();
                logScope.Level = LogLevel.Warning;
                logScope.Log(LogCategory.Technical, LogLevel.Trace, "Trace");
                logScope.Log(LogCategory.Technical, LogLevel.Information, "Information");
                logScope.Log(LogCategory.Technical, LogLevel.Warning, "Warning");
                logScope.Log(LogCategory.Technical, LogLevel.Exception, "Exception");
                Assert.AreEqual(2, this.LogMessages.Count);

                this.LogMessages.Clear();
                logScope.Level = LogLevel.Exception;
                logScope.Log(LogCategory.Technical, LogLevel.Trace, "Trace");
                logScope.Log(LogCategory.Technical, LogLevel.Information, "Information");
                logScope.Log(LogCategory.Technical, LogLevel.Warning, "Warning");
                logScope.Log(LogCategory.Technical, LogLevel.Exception, "Exception");
                Assert.AreEqual(1, this.LogMessages.Count);
            }
        }
    }
}