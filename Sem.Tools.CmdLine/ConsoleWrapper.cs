// <copyright file="ConsoleWrapper.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Wrapper for console functionality that is needed.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsoleWrapper : IConsole
    {
        /// <summary>
        /// Clears the console.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Writes to the console.
        /// </summary>
        /// <param name="value">The line to be written.</param>
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Waits for a key press event.
        /// </summary>
        public void ReadKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Reads a text line from the console.
        /// </summary>
        /// <returns>The text entered by the user.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}