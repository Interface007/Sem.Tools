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
        /// <returns>A new method that is the combination of <paramref name="logMethod"/> and an output to <see cref="Debug"/></returns>
        public static Action<LogCategories, LogLevel, LogScope, string> AddDebug(this Action<LogCategories, LogLevel, LogScope, string> logMethod)
        {
            return logMethod.Add((logCategories, logLevel, logScope, message) => Debug.WriteLine($"{DateTime.Now:s} - {logScope.Id} - {message}"));
        }

        /// <summary>
        /// Simple output using <see cref="Console.WriteLine(object)"/>.
        /// </summary>
        /// <param name="logMethod">The original log method, this method should be added to.</param>
        /// <returns>A new method that is the combination of <paramref name="logMethod"/> and an output to <see cref="Console"/></returns>
        public static Action<LogCategories, LogLevel, LogScope, string> AddConsole(this Action<LogCategories, LogLevel, LogScope, string> logMethod)
        {
            return logMethod.Add((logCategories, logLevel, logScope, message) => System.Console.WriteLine($"{DateTime.Now:s} - {logScope.Id} - {message}"));
        }

        /// <summary>
        /// Extension to combine two logging methods into a new one.
        /// </summary>
        /// <param name="currentAction">The logging method that should be executed first</param>
        /// <param name="actionToAdd">The logging method to be executed after <paramref name="currentAction"/>.</param>
        /// <returns>A new method combining both methods specified in the parameters.</returns>
        public static Action<LogCategories, LogLevel, LogScope, string> Add(this Action<LogCategories, LogLevel, LogScope, string> currentAction, Action<LogCategories, LogLevel, LogScope, string> actionToAdd)
        {
            if (currentAction == null)
            {
                return actionToAdd;
            }

            return (logCategories, logLevel, logScope, message) =>
            {
                currentAction(logCategories, logLevel, logScope, message);
                actionToAdd(logCategories, logLevel, logScope, message);
            };
        }
    }
}