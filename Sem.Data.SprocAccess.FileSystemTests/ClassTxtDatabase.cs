using System;

namespace Sem.Data.SprocAccess.FileSystemTests
{
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Sem.Data.SprocAccess.FileSystem;

    /// <summary>
    /// Tests for the class <see cref="TxtDatabase"/>.
    /// </summary>
    public static class ClassTxtDatabase
    {
        [TestClass]
        public class WithReader
        {
            [TestMethod]
            public async Task ReadsIntFromCorrectColumn()
            {
                var target = new TxtDatabase("Data");
                var result = target.WithReader("sample", async reader => new { Id = await reader.Get<int>(0) });
                await foreach (var item in result)
                {
                    Assert.AreEqual(42, item.Id);
                }
            }

            [TestMethod]
            public async Task ReadsDateTimeFromCorrectColumn()
            {
                var target = new TxtDatabase("Data");
                var result = target.WithReader("sample", async reader => new { Date = await reader.Get<DateTime>(1) });
                await foreach (var item in result)
                {
                    Assert.AreEqual(new DateTime(2020, 12, 23, 22, 44, 33), item.Date);
                }
            }
        }
    }
}