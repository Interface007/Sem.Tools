// <copyright file="LogScope.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ExplicitCallerInfoArgument
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
namespace Sem.Tools.Logging
{
    using System;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Simple hierarchical logging scope.
    /// </summary>
    public sealed class LogScope : IDisposable, IAsyncDisposable
    {
        private readonly DateTime start = DateTime.UtcNow;

        private readonly string scopeName;

        private readonly Action<LogCategories, LogLevel, LogScope, string> logMethod;

        /// <summary>
        /// Gets the structure handling the hierarchy.
        /// </summary>
        private readonly ConcurrentStack<string> idStack;

        private LogScope(string scopeName, string member, string path, LogScope parent, Action<LogCategories, LogLevel, LogScope, string> logMethod)
        {
            this.scopeName = scopeName;
            this.idStack = parent?.idStack ?? new ConcurrentStack<string>();
            this.logMethod = logMethod ?? LogMethod;

            var newId = LogScope.IdFactory(this);
            this.idStack.Push($"{parent?.Id}/{newId.Substring(newId.Length - 4)}");

            var replace = string.IsNullOrEmpty(LogScope.BasePath) ? path : path.Replace(LogScope.BasePath, string.Empty, StringComparison.OrdinalIgnoreCase);
            var pat = replace.Trim('\\').Trim('/');
            this.Log(LogCategories.Technical, LogLevel.Trace, $"Starting scope {scopeName} in member {member} of {pat}.");
        }

        /// <summary>
        /// Gets or sets the level of "chattiness".
        /// </summary>
        public static LogLevel DefaultLevel { get; set; } = LogLevel.Trace;

        /// <summary>
        /// Gets or sets the type of logs to be written.
        /// </summary>
        public static LogCategories DefaultCategory { get; set; } = LogCategories.Technical | LogCategories.Business;

        /// <summary>
        /// Gets or sets the method that will write the log information.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public static Action<LogCategories, LogLevel, LogScope, string> LogMethod { get; set; }

        /// <summary>
        /// Gets or sets the method generating an ID for this logger instance - only the last 4 characters will be used.
        /// </summary>
        public static Func<LogScope, string> IdFactory { get; set; } = x => (DateTime.UtcNow.Ticks - 636818976000000000).ToString("X", CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets or sets a path to be removed in logs.
        /// </summary>
        public static string BasePath { get; set; } = GetBasePath();

        /// <summary>
        /// Gets or sets the type of logs to be written.
        /// </summary>
        public LogCategories Category { get; set; } = DefaultCategory;

        /// <summary>
        /// Gets or sets the level of "chattiness".
        /// </summary>
        public LogLevel Level { get; set; } = DefaultLevel;

        /// <summary>
        /// Gets the hierarchical ID of the scope.
        /// </summary>
        public string Id => this.idStack.TryPeek(out var id) ? id : "0000";

        /// <summary>
        /// Create a new scope instance.
        /// </summary>
        /// <param name="scopeName">Name of the scope.</param>
        /// <param name="logMethod">Method that renders the log entry.</param>
        /// <param name="member">The member (method) that creates the instance.</param>
        /// <param name="path">The path to the class file.</param>
        /// <returns>A new logging scope.</returns>
        public static LogScope Create(string scopeName, Action<LogCategories, LogLevel, LogScope, string> logMethod = null, [CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            return new LogScope(scopeName, member, path, null, logMethod);
        }

        /// <summary>
        /// Call this to indicate a method start.
        /// </summary>
        /// <param name="value">A value that should be logged as part of the creation.</param>
        /// <param name="member">The name of the method.</param>
        /// <param name="path">The path of the source file.</param>
        /// <returns>A new scope.</returns>
        public LogScope MethodStart(object value = null, [CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            return this.Child("MethodScope", value, member, path);
        }

        /// <summary>
        /// Creates a new child scope.
        /// </summary>
        /// <param name="childName"> The name of the scope. </param>
        /// <param name="value">A value that should be logged as part of the creation.</param>
        /// <param name="member">The name of the method.</param>
        /// <param name="path">The path of the source file.</param>
        /// <returns>A new scope.</returns>
        public LogScope Child(string childName, object value = null, [CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            var scope = new LogScope(childName, member, path, this, this.logMethod)
            {
                Level = this.Level,
                Category = this.Category,
            };

            if (value != null)
            {
                scope.Log(LogCategories.Technical, LogLevel.Information, "scope value: ", value);
            }

            return scope;
        }

        /// <summary>
        /// Async implementation of the dispose pattern.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        public ValueTask DisposeAsync()
        {
            this.Dispose();
            return default;
        }

        /// <summary>
        /// Logs the end of the scope.
        /// </summary>
        public void Dispose()
        {
            var ms = (DateTime.UtcNow - this.start).TotalMilliseconds;
            this.Log(LogCategories.Technical, LogLevel.Trace, "Finished scope", new { this.scopeName, ms });
            this.idStack.TryPop(out _);
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        /// <param name="value">A value that should be included into the message as addition data.</param>
        public void Log(string message, object value = null)
        {
            this.Log(LogCategories.Technical, LogLevel.Information, message, value);
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="logCategory">The category of this message (Is it technical information of business process information?).</param>
        /// <param name="logLevel">The log level of this message (How important is this message?).</param>
        /// <param name="message">The message to be logged.</param>
        /// <param name="value">A value that should be included into the message as addition data.</param>
        public void Log(LogCategories logCategory, LogLevel logLevel, string message, object value = null)
        {
            if ((logLevel > this.Level) || (logCategory & this.Category) == 0)
            {
                return;
            }

            var data = value == null ? string.Empty : (" - Data: " + JsonSerializer.Serialize(value, value.GetType()));
            this.logMethod?.Invoke(logCategory, logLevel, this, this.scopeName + " - " + message + data);
        }

        private static string GetBasePath([CallerFilePath] string path = "")
        {
            return Path.GetDirectoryName(path);
        }
    }
}