// <copyright file="LogLevel.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Logging
{
    /// <summary>
    /// The "chattiness" level.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Log never.
        /// </summary>
        None = 0,

        /// <summary>
        /// When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging).
        /// When configuring logger: will only allow any message to be logged.
        /// </summary>
        Trace = 10000,

        /// <summary>
        /// When writing logs: Specifies that this entry is debugging information (less important than an <see cref="Information"/>).
        /// When configuring logger: will only allow information, exceptions and warnings to be logged.
        /// </summary>
        Debug = 20000,

        /// <summary>
        /// When writing logs: Specifies that this entry is a information (less important than an <see cref="Exception"/> or a <see cref="Warning"/>).
        /// When configuring logger: will only allow information, exceptions and warnings to be logged.
        /// </summary>
        Information = 30000,

        /// <summary>
        /// When writing logs: Specifies that this entry is a
        /// ing (less important than an <see cref="Exception"/>).
        /// When configuring logger: will only allow exceptions and warnings to be logged.
        /// </summary>
        Warning = 40000,

        /// <summary>
        /// When writing logs: Specifies that this entry is an exception.
        /// When configuring logger: will only allow exceptions to be logged.
        /// </summary>
        Error = 50000,

        /// <summary>
        /// When writing logs: Specifies that this entry is an exception.
        /// When configuring logger: will only allow exceptions to be logged.
        /// </summary>
        Exception = 60000,

        /// <summary>
        /// When writing logs: Specifies that this entry is absolutely critical to report - you cannot suppress reporting this.
        /// When configuring logger: will only allow only this to be reported.
        /// </summary>
        Critical = int.MaxValue,
    }
}