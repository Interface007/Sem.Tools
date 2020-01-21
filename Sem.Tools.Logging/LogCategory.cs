namespace Sem.Tools.Logging
{
    using System;

    /// <summary>
    /// The logging category distinguishes between technical and business information.
    /// </summary>
    [Flags]
    public enum LogCategory
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