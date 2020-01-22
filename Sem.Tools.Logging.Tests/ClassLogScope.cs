// ReSharper disable UnusedVariable
namespace Sem.Tools.Logging.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the class <see cref="LogScope"/>.
    /// </summary>
    public static class ClassLogScope
    {
        /// <summary>
        /// Tests the constructor(s) or <see cref="LogScope"/>.
        /// </summary>
        [TestClass]
        public class LogScopeConstructor
        {
            /// <summary>
            /// Tests whether the ctor log line is formatted correctly.
            /// </summary>
            [TestMethod]
            public void LogsScopeStart()
            {
                var logger = new List<string>();
                LogScope.LogMethod = (category, level, scope, message) => logger.Add(message);
                LogScope.BasePath = this.BasePath();

                using var logScope = LogScope.Create("NewScope");

                Assert.AreEqual(1, logger.Count);
                Assert.AreEqual("NewScope - Starting scope NewScope in member LogsScopeStart of ClassLogScope.cs.", logger[0]);
            }

            private string BasePath([CallerFilePath] string path = "")
            {
                return Path.GetDirectoryName(path);
            }
        }
    }
}