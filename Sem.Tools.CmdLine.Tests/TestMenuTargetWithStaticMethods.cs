// <copyright file="TestMenuTargetWithStaticMethods.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>
    /// A class containing method to create a menu from.
    /// </summary>
    public class TestMenuTargetWithStaticMethods
    {
        /// <summary>
        /// Gets or sets the result of a method invocation.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// This is a good documented void method.
        /// </summary>
        /// <param name="menuTarget">The instance to accept the result.</param>
        [ExcludeFromCodeCoverage]
        public static void ThisIsAVoidMethod(TestMenuTargetWithStaticMethods menuTarget) => menuTarget.MustNotBeNull(nameof(menuTarget)).Result = "ok";

        /// <summary>
        /// This is a method returning a string async.
        /// </summary>
        /// <param name="menuTarget">The instance to accept the result.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [ExcludeFromCodeCoverage]
        public static Task<string> WithAsyncStringResult(TestMenuTargetWithStaticMethods menuTarget)
        {
            menuTarget.MustNotBeNull(nameof(menuTarget)).Result = "ok";
            return Task.FromResult("return value");
        }

        /// <summary>
        /// This is a method returning an <see cref="IEnumerable{T}"/> string async.
        /// </summary>
        /// <param name="menuTarget">The instance to accept the result.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [ExcludeFromCodeCoverage]
        public static Task<IEnumerable<string>> WithAsyncIEnumerableStringResult(TestMenuTargetWithStaticMethods menuTarget)
        {
            menuTarget.MustNotBeNull(nameof(menuTarget)).Result = "ok";
            return Task.FromResult((IEnumerable<string>)new[] { "return value" });
        }
    }
}