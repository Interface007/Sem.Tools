﻿// <copyright file="ConsoleSimulator.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.TestHelper
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Helps to test functionality that relies on <see cref="System.Console"/>.
    /// </summary>
    public class ConsoleSimulator : IConsole
    {
        /// <summary>
        /// The data "entered by the user".
        /// </summary>
        private readonly Queue<string> lines = new Queue<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleSimulator"/> class.
        /// </summary>
        /// <param name="lines">The lines to be simulated.</param>
        public ConsoleSimulator(params string[] lines)
        {
            foreach (var line in lines)
            {
                this.lines.Enqueue(line);
            }
        }

        /// <summary>
        /// Gets a list of output generated by the program.
        /// </summary>
        public IList<string> Output { get; } = new List<string>();

        /// <summary>
        /// Adds a "{clear}" entry to the list of output.
        /// </summary>
        public void Clear() => this.Output.Add("{clear}");

        /// <summary>
        /// Writes a value to the list of output.
        /// </summary>
        /// <param name="value">The value to be added.</param>
        [ExcludeFromCodeCoverage]
        public void WriteLine(string value) => this.Output.Add(value?.Trim('\n'));

        /// <summary>
        /// Dequeues an entry from the list of user input (simulates "press any key").
        /// </summary>
        public void ReadKey()
        {
            if (this.lines.Count > 0)
            {
                _ = this.lines.Dequeue();
            }
        }

        /// <summary>
        /// Gets an entry from the queue of user input.
        /// </summary>
        /// <returns>One text line.</returns>
        public string ReadLine()
        {
            if (this.lines.Count > 0)
            {
                return this.lines.Dequeue();
            }

            return string.Empty;
        }
    }
}