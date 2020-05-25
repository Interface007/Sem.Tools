// <copyright file="LoggerTestBase.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Logging.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Base class for tests of the logger class.
    /// </summary>
    public class LoggerTestBase
    {
        /// <summary>
        /// Initializes static members of the <see cref="LoggerTestBase"/> class.
        /// Initializes the static values of <see cref="LogScope"/> to produce deterministic log entries.
        /// </summary>
        static LoggerTestBase()
        {
            LogScope.BasePath = BasePath();
            LogScope.IdFactory = x => $"{x.Id.Length:0000}";
        }

        /// <summary>
        /// Gets the logged messages.
        /// </summary>
        protected IList<string> LogMessages { get; } = new List<string>();

        /// <summary>
        /// A log method that adds the log information to <see cref="LogMessages"/>.
        /// </summary>
        /// <param name="category">The category of the log entry.</param>
        /// <param name="level">The log level.</param>
        /// <param name="scope">The logging scope that renders the log entry.</param>
        /// <param name="message">The log message.</param>
        protected void LogMethod(LogCategories category, LogLevel level, LogScope scope, string message)
        {
            scope.MustNotBeNull(nameof(scope));
            this.LogMessages.Add($"{category}, {level}, {scope.Id}, {message}");
        }

        /// <summary>
        /// Uses a compile time attribute to determine the source code path of this class.
        /// </summary>
        /// <param name="path">Path of this class will be set at compile time.</param>
        /// <returns>The source code path of this class.</returns>
        private static string BasePath([CallerFilePath] string path = "") =>
            Path.GetDirectoryName(path);
    }
}