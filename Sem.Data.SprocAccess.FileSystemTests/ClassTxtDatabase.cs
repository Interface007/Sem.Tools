// <copyright file="ClassTxtDatabase.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.FileSystemTests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Sem.Data.SprocAccess.FileSystem;

    /// <summary>
    /// Tests for the class <see cref="TxtDatabase"/>.
    /// </summary>
    public static class ClassTxtDatabase
    {
        /// <summary>
        /// Tests for the method <see cref="TxtDatabase.Execute{T}"/>.
        /// </summary>
        [TestClass]
        public class Execute
        {
            /// <summary>
            /// Tests whether the <see cref="int"/> column can be mapped correctly.
            /// </summary>
            /// <returns>A task to wait for.</returns>
            [TestMethod]
            public async Task ReadsIntFromCorrectColumn()
            {
                var target = new TxtDatabase("Data");
                var result = target.Execute("sample", async reader => new { Id = await reader.Get<int>(0).ConfigureAwait(false) });
                await foreach (var item in result)
                {
                    Assert.AreEqual(42, item.Id);
                }
            }

            /// <summary>
            /// Tests whether the <see cref="DateTime"/> column can be mapped correctly.
            /// </summary>
            /// <returns>A task to wait for.</returns>
            [TestMethod]
            public async Task ReadsDateTimeFromCorrectColumn()
            {
                var target = new TxtDatabase("Data");
                var result = target.Execute("sample", async reader => new { Date = await reader.Get<DateTime>(1).ConfigureAwait(false) });
                await foreach (var item in result)
                {
                    var expected = new DateTime(2020, 12, 23, 22, 44, 33);
                    Assert.AreEqual(expected, item.Date);
                }
            }
        }
    }
}