// <copyright file="LogExtension.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Logging
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Extension class providing some standard logging methods.
    /// </summary>
    public static class LogExtension
    {
        /// <summary>
        /// Simple output using <see cref="Debug.WriteLine(object)"/>.
        /// </summary>
        /// <param name="logMethod">The original log method, this method should be added to.</param>
        /// <returns>A new method that is the combination of <paramref name="logMethod"/> and an output to <see cref="Debug"/>.</returns>
        public static Action<LogCategories, LogLevel, LogScope, string> AddDebug(this Action<LogCategories, LogLevel, LogScope, string> logMethod)
        {
            return logMethod.Append((logCategories, logLevel, logScope, message) => Debug.WriteLine($"{DateTime.Now:s} - {logScope.Id} - {message}"));
        }

        /// <summary>
        /// Simple output using <see cref="Console.WriteLine(object)"/>.
        /// </summary>
        /// <param name="logMethod">The original log method, this method should be added to.</param>
        /// <returns>A new method that is the combination of <paramref name="logMethod"/> and an output to <see cref="Console"/>.</returns>
        public static Action<LogCategories, LogLevel, LogScope, string> AddConsole(this Action<LogCategories, LogLevel, LogScope, string> logMethod)
        {
            return logMethod.Append((logCategories, logLevel, logScope, message) => System.Console.WriteLine($"{DateTime.Now:s} - {logScope.Id} - {message}"));
        }
    }
}