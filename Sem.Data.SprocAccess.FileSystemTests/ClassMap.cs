// <copyright file="ClassMap.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.FileSystemTests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sem.Data.SprocAccess.FileSystem;

    /// <summary>
    /// Tests for the class <see cref="FileSystemTests.Map"/>.
    /// </summary>
    public static class ClassMap
    {
        /// <summary>
        /// Tests the method <see cref="FileSystemTests.Map.To{T}"/>.
        /// </summary>
        [TestClass]
        public class To
        {
            /// <summary>
            /// Tests default property name mapping to a sample class.
            /// </summary>
            /// <returns>A task to wait for.</returns>
            [TestMethod]
            public async Task MapsSampleType()
            {
                await using var target = new TxtDatabase("Data");
                var result = target.Execute("sample", FileSystemTests.Map.To<Sample>);
                await foreach (var item in result)
                {
                    Assert.AreEqual(42, item.Id);

                    var expected = new DateTime(2020, 12, 23, 22, 44, 33);
                    Assert.AreEqual(expected, item.Date);
                }
            }
        }
    }
}