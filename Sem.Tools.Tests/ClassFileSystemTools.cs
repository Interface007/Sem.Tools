// <copyright file="ClassFileSystemTools.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the class <see cref="FileSystemTools"/>.
    /// </summary>
    public static class ClassFileSystemTools
    {
        /// <summary>
        /// Tests the method <see cref="FileSystemTools.SanitizeFileName"/>.
        /// </summary>
        [TestClass]
        public class SanitizeFileName
        {
            /// <summary>
            /// Tests whether special characters are removed.
            /// </summary>
            [TestMethod]
            public void RemovesSpecialCharacters()
            {
                // ReSharper disable StringLiteralTypo
                var target = "C:\"'Helöüß%§!:.;,#+*?`´<>";
                var result = target.SanitizeFileName();
                var expected = "C'Helöüß%§!.;,#+`´";

                // ReSharper restore StringLiteralTypo
                Assert.AreEqual(expected, result);
            }

            /// <summary>
            /// Tests whether NULL values are accepted.
            /// </summary>
            [TestMethod]
            public void AcceptsNull()
            {
                // ReSharper disable StringLiteralTypo
                var result = FileSystemTools.SanitizeFileName(null);
                var expected = string.Empty;

                // ReSharper restore StringLiteralTypo
                Assert.AreEqual(expected, result);
            }
        }
    }
}
