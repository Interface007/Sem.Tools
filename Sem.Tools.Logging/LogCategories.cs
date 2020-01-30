// <copyright file="LogCategories.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Logging
{
    using System;

    /// <summary>
    /// The logging category distinguishes between technical and business information.
    /// </summary>
    [Flags]
    public enum LogCategories
    {
        /// <summary>
        /// The context is not determined.
        /// </summary>
        None = 0,

        /// <summary>
        /// The log information is pure technical.
        /// </summary>
        Technical = 1,

        /// <summary>
        /// The log information is pure business.
        /// </summary>
        Business = 2,
    }
}