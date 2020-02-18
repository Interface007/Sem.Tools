// <copyright file="TestMenuTarget.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System.Collections.Generic;

    /// <summary>
    /// A class containing method to create a menu from.
    /// </summary>
    public class TestMenuTarget
    {
#pragma warning disable 1591
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async IAsyncEnumerable<string> DoItTheRightWay()
#pragma warning restore 1591
        {
            yield return "ok";
        }

        /// <summary>
        /// This is a good documented method.
        /// </summary>
        /// <returns>A stream of output messages.</returns>
        public async IAsyncEnumerable<string> DoItTheRightWayWithDocumentation()
        {
            yield return "ok";
        }

        /// <summary>
        /// This is a good documented void method.
        /// </summary>
        public void ThisIsAVoidMethod()
        {
        }
    }
}