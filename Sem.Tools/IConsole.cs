// <copyright file="IConsole.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools
{
    /// <summary>
    /// Interface of for methods used from <see cref="System.Console"/>.
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Clears the console.
        /// </summary>
        void Clear();

        /// <summary>
        /// Writes a single line.
        /// </summary>
        /// <param name="value">The line to write.</param>
        void WriteLine(string value);

        /// <summary>
        /// Waits for the user pressing a key.
        /// </summary>
        void ReadKey();

        /// <summary>
        /// Returns a line of text entered by the user.
        /// </summary>
        /// <returns>The text.</returns>
        string ReadLine();
    }
}