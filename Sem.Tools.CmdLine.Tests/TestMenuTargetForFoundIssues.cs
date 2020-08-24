// <copyright file="TestMenuTargetForFoundIssues.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>
// ReSharper disable ClassNeverInstantiated.Global
namespace Sem.Tools.CmdLine.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>
    /// A class containing method that I want to use to to create a menu.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TestMenuTargetForFoundIssues
    {
        private readonly TestMenuTargetComplexParameter parameter;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestMenuTargetForFoundIssues"/> class.
        /// </summary>
        /// <param name="parameter">A simple ctor parameter.</param>
        public TestMenuTargetForFoundIssues(TestMenuTargetComplexParameter parameter) => this.parameter = parameter;

        /// <summary>
        /// Sample method of case 1 that was missing.
        /// </summary>
        /// <param name="param1">Just a simple parameter #1.</param>
        /// <param name="param2">Just a simple parameter #2.</param>
        /// <param name="param3">Just a simple parameter #3.</param>
        /// <returns>A task to wait for.</returns>
        public Task AsyncTaskMethod(string param1, int param2, string param3) => Task.CompletedTask;
    }
}