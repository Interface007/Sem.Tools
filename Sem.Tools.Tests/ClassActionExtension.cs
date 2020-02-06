// <copyright file="ClassActionExtension.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the extension class <see cref="ActionExtension"/>.
    /// </summary>
    public static class ClassActionExtension
    {
        /// <summary>
        /// Tests the method <see cref="ActionExtension.Append"/> and its overloads.
        /// </summary>
        [TestClass]
        public class Append
        {
            /// <summary>
            /// Tests whether both of two methods with 0 parameters are being called.
            /// </summary>
            [TestMethod]
            public void ConcatenatesActionsWith0Parameter()
            {
                var value = 0;
                Action action1 = () => value++;
                Action action2 = () => value += 2;

                action1.Append(action2)();

                Assert.AreEqual(3, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 1 parameters are being called.
            /// </summary>
            [TestMethod]
            public void ConcatenatesActionsWith1Parameter()
            {
                var value = 0;
                Action<int> action1 = x => value++;
                Action<int> action2 = x => value += 2;

                action1.Append(action2)(1);

                Assert.AreEqual(3, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 2 parameters are being called.
            /// </summary>
            [TestMethod]
            public void ConcatenatesActionsWith2Parameter()
            {
                var value = 0;
                Action<int, int> action1 = (x, y) => value++;
                Action<int, int> action2 = (x, y) => value += 2;

                action1.Append(action2)(1, 2);

                Assert.AreEqual(3, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 3 parameters are being called.
            /// </summary>
            [TestMethod]
            public void ConcatenatesActionsWith3Parameter()
            {
                var value = 0;
                Action<int, int, int> action1 = (x, y, z) => value++;
                Action<int, int, int> action2 = (x, y, z) => value += 2;

                action1.Append(action2)(1, 2, 3);

                Assert.AreEqual(3, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 4 parameters are being called.
            /// </summary>
            [TestMethod]
            public void ConcatenatesActionsWith4Parameter()
            {
                var value = 0;
                Action<int, int, int, int> action1 = (x, y, z, a) => value++;
                Action<int, int, int, int> action2 = (x, y, z, a) => value += 2;

                action1.Append(action2)(1, 2, 3, 4);

                Assert.AreEqual(3, value);
            }
        
            /// <summary>
            /// Tests whether both of two methods with 0 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInFirstActionsWith0Parameter()
            {
                var value = 0;
                Action action1 = null;
                Action action2 = () => value += 2;

                action1.Append(action2)();

                Assert.AreEqual(2, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 1 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInFirstActionsWith1Parameter()
            {
                var value = 0;
                Action<int> action1 = null;
                Action<int> action2 = x => value += 2;

                action1.Append(action2)(1);

                Assert.AreEqual(2, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 2 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInFirstActionsWith2Parameter()
            {
                var value = 0;
                Action<int, int> action1 = null;
                Action<int, int> action2 = (x, y) => value += 2;

                action1.Append(action2)(1, 2);

                Assert.AreEqual(2, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 3 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInFirstActionsWith3Parameter()
            {
                var value = 0;
                Action<int, int, int> action1 = null;
                Action<int, int, int> action2 = (x, y, z) => value += 2;

                action1.Append(action2)(1, 2, 3);

                Assert.AreEqual(2, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 4 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInFirstActionsWith4Parameter()
            {
                var value = 0;
                Action<int, int, int, int> action1 = null;
                Action<int, int, int, int> action2 = (x, y, z, a) => value += 2;

                action1.Append(action2)(1, 2, 3, 4);

                Assert.AreEqual(2, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 0 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInSecondActionsWith0Parameter()
            {
                var value = 0;
                Action action1 = () => value++;
                Action action2 = null;

                action1.Append(action2)();

                Assert.AreEqual(1, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 1 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInSecondActionsWith1Parameter()
            {
                var value = 0;
                Action<int> action1 = x => value++;
                Action<int> action2 = null;

                action1.Append(action2)(1);

                Assert.AreEqual(1, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 2 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInSecondActionsWith2Parameter()
            {
                var value = 0;
                Action<int, int> action1 = (x, y) => value++;
                Action<int, int> action2 = null;

                action1.Append(action2)(1, 2);

                Assert.AreEqual(1, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 3 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInSecondActionsWith3Parameter()
            {
                var value = 0;
                Action<int, int, int> action1 = (x, y, z) => value++;
                Action<int, int, int> action2 = null;

                action1.Append(action2)(1, 2, 3);

                Assert.AreEqual(1, value);
            }

            /// <summary>
            /// Tests whether both of two methods with 4 parameters are being called.
            /// </summary>
            [TestMethod]
            public void HandlesNullInSecondActionsWith4Parameter()
            {
                var value = 0;
                Action<int, int, int, int> action1 = (x, y, z, a) => value++;
                Action<int, int, int, int> action2 = null;

                action1.Append(action2)(1, 2, 3, 4);

                Assert.AreEqual(1, value);
            }
        }
    }
}
