// <copyright file="TestMenuTargetForFoundIssues.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>
    /// A class containing method to create a menu from.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TestMenuTargetForFoundIssues
    {
        /// <summary>
        /// Sample method of case 1 that was missing.
        /// </summary>
        /// <param name="param1">Just a simple parameter #1.</param>
        /// <param name="param2">Just a simple parameter #2.</param>
        /// <param name="param3">Just a simple parameter #3.</param>
        /// <returns>A task to wait for.</returns>
        public Task AsyncTaskMethod(string param1, int param2, string param3)
        {
            return Task.CompletedTask;
        }
    }
}