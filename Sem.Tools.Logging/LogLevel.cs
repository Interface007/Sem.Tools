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
        /// When writing logs: Specifies that this entry is an exception.
        /// When configuring logger: will only allow exceptions to be logged.
        /// </summary>
        Exception = 1,

        /// <summary>
        /// When writing logs: Specifies that this entry is a
        /// ing (less important than an <see cref="Exception"/>).
        /// When configuring logger: will only allow exceptions and warnings to be logged.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// When writing logs: Specifies that this entry is a information (less important than an <see cref="Exception"/> or a <see cref="Warning"/>).
        /// When configuring logger: will only allow information, exceptions and warnings to be logged.
        /// </summary>
        Information = 3,

        /// <summary>
        /// When writing logs: Specifies that this entry is a trace message (something that should be logged while debugging).
        /// When configuring logger: will only allow any message to be logged.
        /// </summary>
        Trace = 4,
    }
}