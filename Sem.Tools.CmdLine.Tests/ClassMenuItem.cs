namespace Sem.Tools.CmdLine.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the class <see cref="MenuItem"/>.
    /// </summary>
    public static class ClassMenuItem
    {
        /// <summary>
        /// Tests the method <see cref="MenuItem.Print(System.Linq.Expressions.Expression{System.Func{System.Collections.Generic.IAsyncEnumerable{string}}},string)"/>
        /// </summary>
        [TestClass]
        public class For
        {
            /// <summary>
            /// Tests whether the method extracts menu items for a complete instance type.
            /// </summary>
            [TestMethod]
            public void CreatesGoodMenuItemFromInstanceType()
            {
                var target = MenuItem.For<TestMenuTarget>();
                Assert.AreEqual("A class containing method to create a menu from.", target.DisplayString);
            }
        }

        /// <summary>
        /// Tests the method <see cref="MenuItem.MenuItemsFor{T}"/>.
        /// </summary>
        [TestClass]
        public class MenuItemsFor
        {
            /// <summary>
            /// Tests whether the method extracts menu items for a complete instance type.
            /// </summary>
            [TestMethod]
            public void CreatesGoodSubMenuItemsFromInstanceType()
            {
                var target = MenuItem.MenuItemsFor<TestMenuTarget>();
                Assert.AreEqual(2, target.Length);
                Assert.AreEqual("Do It The Right Way", target[0].DisplayString);
                Assert.AreEqual("This is a good documented method.", target[1].DisplayString);
            }
        }

        /// <summary>
        /// Tests the method <see cref="MenuItem.Print(System.Linq.Expressions.Expression{System.Func{System.Collections.Generic.IAsyncEnumerable{string}}},string)"/>.
        /// </summary>
        [TestClass]
        public class Print
        {
            /// <summary>
            /// Tests whether the method extracts a menu item description
            /// from the method name when the method is not documented.
            /// </summary>
            [TestMethod]
            public void CreatesGoodMenuItemFromUndocumentedMethod()
            {
                var menuTarget = new TestMenuTarget();
                var target = MenuItem.Print(() => menuTarget.DoItTheRightWay());
                Assert.AreEqual("Do It The Right Way", target.DisplayString);
            }

            /// <summary>
            /// Tests whether the method extracts a menu item description
            /// from the XML documentation when the method is documented.
            /// </summary>
            [TestMethod]
            public void CreatesGoodMenuItemFromDocumentedMethod()
            {
                var menuTarget = new TestMenuTarget();
                var target = MenuItem.Print(() => menuTarget.DoItTheRightWayWithDocumentation());
                Assert.AreEqual("This is a good documented method.", target.DisplayString);
            }

            /// <summary>
            /// Tests whether the method extracts a menu item description
            /// from the XML documentation when the method is documented.
            /// </summary>
            [TestMethod]
            public void AcceptsVoidMethods()
            {
                var menuTarget = new TestMenuTarget();
                var target = MenuItem.Print(() => menuTarget.ThisIsAVoidMethod());
                Assert.AreEqual("This is a good documented void method.", target.DisplayString);
            }
        }
    }
}