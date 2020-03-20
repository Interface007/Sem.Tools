// <copyright file="TestMenuTarget.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A class containing a method to create a menu from.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TestMenuTarget
    {
        /// <summary>
        /// Gets or sets the parameter that has been set by <see cref="ThisIsAVoidMethod(string,Sem.Tools.CmdLine.Tests.TestMenuTarget)"/>.
        /// </summary>
        public string Parameter { get; set; }

#pragma warning disable 1591
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        [ExcludeFromCodeCoverage]
        public async IAsyncEnumerable<string> DoItTheRightWay()
#pragma warning restore 1591
        {
            yield return "ok";
        }

        /// <summary>
        /// This is a good documented method.
        /// </summary>
        /// <returns>A stream of output messages.</returns>
        [ExcludeFromCodeCoverage]
        public async IAsyncEnumerable<string> DoItTheRightWayWithDocumentation()
        {
            yield return "ok";
        }

        /// <summary>
        /// This is a good documented void method with parameter.
        /// </summary>
        /// <param name="myParameter">Just a simple parameter.</param>
        /// <param name="target">The class that should get the value of <paramref name="myParameter"/>.</param>
        [ExcludeFromCodeCoverage]
        public void ThisIsAVoidMethod(string myParameter, TestMenuTarget target)
        {
            target.MustNotBeNull(nameof(target)).Parameter = myParameter;
        }

        /// <summary>
        /// This is a good documented void method.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void ThisIsAVoidMethod()
        {
        }
    }
}