// <copyright file="ClassLogCategoryExtensions.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Logging.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the static helper class <see cref="LogCategoryExtensions"/>.
    /// </summary>
    public static class ClassLogCategoryExtensions
    {
        /// <summary>
        /// Tests the method <see cref="LogCategoryExtensions.HasFlag{T}"/>.
        /// </summary>
        [TestClass]
        public class HasFlagFast
        {
            /// <summary>
            /// Tests whether the method can detect a single flag being set.
            /// </summary>
            [TestMethod]
            public void DetectsFlagSingle()
            {
                var target1 = LogCategories.Business;
                var result1 = target1.HasFlag(LogCategories.Business);
                Assert.IsTrue(result1);

                var target2 = LogCategories.Technical;
                var result2 = target2.HasFlag(LogCategories.Technical);
                Assert.IsTrue(result2);
            }

            /// <summary>
            /// Tests whether the method can detect a single flag in a variable with multiple flags being set.
            /// </summary>
            [TestMethod]
            public void DetectsFlagInCombination()
            {
                var target = LogCategories.Business | LogCategories.Technical;

                var result1 = target.HasFlag(LogCategories.Business);
                Assert.IsTrue(result1);

                var result2 = target.HasFlag(LogCategories.Technical);
                Assert.IsTrue(result2);
            }

            /// <summary>
            /// Tests whether the method can detect a single flag not being set.
            /// </summary>
            [TestMethod]
            public void DetectsFlagNotSet()
            {
                var target1 = LogCategories.Technical;
                var result1 = target1.HasFlag(LogCategories.Business);
                Assert.IsFalse(result1);

                var target2 = LogCategories.Business;
                var result2 = target2.HasFlag(LogCategories.Technical);
                Assert.IsFalse(result2);
            }
        }
    }
}
