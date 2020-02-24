// <copyright file="ClassTxtDatabase.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>
namespace Sem.Data.SprocAccess.FileSystemTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Sem.Data.SprocAccess.FileSystem;
    using Sem.Tools.Logging;

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

            /// <summary>
            /// Reads the correct file when using parameters.
            /// </summary>
            /// <returns>A task to wait for.</returns>
            [TestMethod]
            public async Task ReadsCorrectFileWithParameters()
            {
                var target = new TxtDatabase("Data");
                var result = target.Execute("sample", async reader => new { Date = await reader.Get<DateTime>(1).ConfigureAwait(false) }, null, new KeyValuePair<string, object>("test", "value"));
                await foreach (var item in result)
                {
                    var expected = new DateTime(2019, 12, 23, 22, 44, 33);
                    Assert.AreEqual(expected, item.Date);
                }
            }

            /// <summary>
            /// Tests whether logs contain the correct information.
            /// </summary>
            /// <returns>A task to wait for.</returns>
            [TestMethod]
            [ExcludeFromCodeCoverage]
            public async Task LogsCorrectly()
            {
                var logEntries = new List<string>();
                void LogMethod(LogCategories categories, LogLevel level, LogScope scope, string message)
                {
                    logEntries.Add(message);
                }

                var target = new TxtDatabase("Data");

                await using var log = LogScope.Create("db", LogMethod);
                var result = target.Execute("sample", async reader => new { Date = await reader.Get<DateTime>(1).ConfigureAwait(false) }, log);
                await foreach (var item in result)
                {
                    var expected = new DateTime(2019, 12, 23, 22, 44, 33);
                    Assert.AreEqual("MethodScope - scope value:  - Data: {\"sproc\":\"sample\",\"parameters\":[]}", logEntries[2]);
                }
            }

            /// <summary>
            /// Tests whether the method can read a 2nd result set.
            /// </summary>
            /// <returns>A task to wait for.</returns>
            [TestMethod]
            [ExcludeFromCodeCoverage]
            public async Task ReadsSecondResult()
            {
                var target = new TxtDatabase("Data");
                var result = target.Execute(
                    "sample",
                    async reader =>
                    {
                        await reader.NextResult().ConfigureAwait(false);
                        return new { Date = await reader.Get<DateTime>(1).ConfigureAwait(false) };
                    });
                await foreach (var item in result)
                {
                    var expected = new DateTime(2018, 12, 23, 22, 44, 33);
                    Assert.AreEqual(expected, item.Date);
                }
            }
        }
    }
}