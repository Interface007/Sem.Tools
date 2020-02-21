// <copyright file="ClassMenuItem.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Sem.Tools.CmdLine.TestProject;
    using Sem.Tools.TestHelper;

    /// <summary>
    /// Tests the class <see cref="MenuItem"/>.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = "parameters are just to build up different signatures")]
    public static class ClassMenuItem
    {
        /// <summary>
        /// Tests a complete sample of many ways to create a method.
        /// </summary>
        [TestClass]
        [ExcludeFromCodeCoverage]
        public class MenuSample
        {
            /// <summary>
            /// Sample with multiple ways to specify what should be available in the menu.
            /// </summary>
            /// <returns>A task to wait for.</returns>
            [TestMethod]
            public async Task SampleMenuCreation()
            {
                var console = new ConsoleSimulator(" ", " ");
                var menuTarget = new TestMenuTargetWithStaticMethods();
                var parameter2 = new TestMenuTargetWithCtorParameter("fail");

                await new[]
                {
                    MenuItem.Print(() => this.LocalVoidMethodWithParameter(string.Empty)),
                    MenuItem.Print(() => this.LocalStringMethodWithParameter(string.Empty)),
                    MenuItem.Print(() => this.LocalAsyncVoidMethodWithParameter(string.Empty)),
                    MenuItem.Print(() => this.LocalAsyncStringMethodWithParameter(string.Empty)),
                    MenuItem.For<TestMenuTargetWithStaticMethods>("hello", menuTarget),
                    MenuItem.For<TestMenuTarget>(x => x.ThisIsAVoidMethod(), "hello", menuTarget),
                    MenuItem.For<TestMenuTargetWithCtorParameter>(x => x.DoIt(parameter2), "hello", menuTarget),
                }.Show(console);

                var result = console.Output.Aggregate((x, s) => x + "\n" + s);
                const string expected = "{clear}\n0) Local Void Method With Parameter\n1) Local String Method With Parameter\n2) Local Async Void Method With Parameter\n3) Local Async String Method With Parameter\n4) A class containing method to create a menu from.\n5) This is a good documented void method.\n6) Do It\nwhat should be executed?";

                Assert.AreEqual(expected, result);
            }

            /// <summary>
            /// Sample void sync method with parameter.
            /// </summary>
            /// <param name="value">A simple parameter.</param>
            private void LocalVoidMethodWithParameter(string value)
            {
            }

            /// <summary>
            /// Sample sync method with parameter.
            /// </summary>
            /// <param name="value">A simple parameter.</param>
            /// <returns>The value of <paramref name="value"/>.</returns>
            // ReSharper disable once UnusedMethodReturnValue.Local
            private string LocalStringMethodWithParameter(string value)
            {
                return value;
            }

            /// <summary>
            /// Sample async method with parameter without return value.
            /// </summary>
            /// <param name="value">A simple parameter.</param>
            /// <returns>A task to wait for.</returns>
            // ReSharper disable once UnusedMethodReturnValue.Local
            private Task LocalAsyncVoidMethodWithParameter(string value)
            {
                return Task.CompletedTask;
            }

            /// <summary>
            /// Sample async method with parameter.
            /// </summary>
            /// <param name="value">A simple parameter.</param>
            /// <returns>A string returned as a task to wait for.</returns>
            private Task<string> LocalAsyncStringMethodWithParameter(string value)
            {
                return Task.FromResult(value);
            }
        }

        /// <summary>
        /// Tests the method <see cref="MenuItem.Print(System.Linq.Expressions.Expression{System.Func{System.Collections.Generic.IAsyncEnumerable{string}}},string)"/>.
        /// </summary>
        [TestClass]
#pragma warning disable CA1716 // Identifiers should not match keywords
        public class For
#pragma warning restore CA1716 // Identifiers should not match keywords
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

            /// <summary>
            /// Tests whether the method extracts one item for a single method.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task AcceptsExpressionToSingleAsyncMethod()
            {
                var container = new TestMenuTargetWithCtorParameter("false");
                var target = MenuItem.For<TestMenuTargetWithCtorParameter>(x => x.DoIt(container), "some text", container);

                Assert.AreEqual("Do It", target.DisplayString);

                await target.Action();
                Assert.AreEqual("some text", container.Text);
            }
        }

        /// <summary>
        /// Tests the method <see cref="MenuItem.MenuItemsFor{T}"/>.
        /// </summary>
        [TestClass]
        [ExcludeFromCodeCoverage]
        public class MenuItemsFor
        {
            /// <summary>
            /// Tests whether the method extracts menu items for a complete instance type.
            /// </summary>
            [TestMethod]
            public void CreatesGoodSubMenuItemsFromInstanceType()
            {
                var target = MenuItem.MenuItemsFor<TestMenuTarget>();
                Assert.AreEqual(4, target.Length);
                Assert.AreEqual("Do It The Right Way", target[0].DisplayString);
                Assert.AreEqual("This is a good documented method.", target[1].DisplayString);
                Assert.AreEqual("This is a good documented void method with parameter.", target[2].DisplayString);
                Assert.AreEqual("This is a good documented void method.", target[3].DisplayString);
            }

            /// <summary>
            /// Tests whether parameters are mapped correctly when using one anonymous type parameter with multiple matching names of properties.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task MapsParametersByAnonymousTypePropertyName()
            {
                var value = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
                var menuTarget = new TestMenuTarget();
                var target = MenuItem.MenuItemsFor<TestMenuTarget>(new { myParameter = value, target = menuTarget });
                await target[2].Action.Invoke().ConfigureAwait(false);
                Assert.AreEqual(value, menuTarget.Parameter);
            }

            /// <summary>
            /// Tests whether parameters are NOT mapped when using one anonymous type parameter with non-matching names of properties.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            [ExpectedExceptionMessage(typeof(InvalidOperationException), "no value found for the parameter \\[myParameter\\] of method \\[ThisIsAVoidMethod\\] with the type \\[String\\]")]
            public async Task NotMapsParametersByAnonymousTypePropertyName()
            {
                var value = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
                var menuTarget = new TestMenuTarget();
                var target = MenuItem.MenuItemsFor<TestMenuTarget>(new { myParameterWrong = value, target = menuTarget });
                await target[2].Action.Invoke().ConfigureAwait(false);
            }

            /// <summary>
            /// Tests whether parameters are mapped correctly when using multiple parameters with matching types.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task MapsParametersByType()
            {
                var value = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
                var menuTarget = new TestMenuTarget();
                var target = MenuItem.MenuItemsFor<TestMenuTarget>(value, menuTarget);
                await target[2].Action.Invoke().ConfigureAwait(false);
                Assert.AreEqual(value, menuTarget.Parameter);
            }

            /// <summary>
            /// Tests whether parameters are mapped correctly when using multiple parameters with matching types.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task AcceptsStaticMethods()
            {
                var menuTarget = new TestMenuTargetWithStaticMethods();
                var target = MenuItem.MenuItemsFor<TestMenuTargetWithStaticMethods>(menuTarget);
                await target[0].Action.Invoke().ConfigureAwait(false);
                Assert.AreEqual("ok", menuTarget.Result);
            }
        }

        /// <summary>
        /// Tests the method <see cref="MenuItem.Print(System.Linq.Expressions.Expression{System.Func{System.Collections.Generic.IAsyncEnumerable{string}}},string)"/>.
        /// </summary>
        [TestClass]
        public class Print
        {
            /// <summary>
            /// Builds the description from the method name when no XML available.
            /// </summary>
            [TestMethod]
            public void BuildsDescriptionFromNameWhenNoXmlAvailable()
            {
                var menuTarget = new SampleClassWithoutDocumentation();
                var target = MenuItem.Print(() => menuTarget.JustASimpleMethod());
                Assert.AreEqual("Just A Simple Method", target.DisplayString);
            }

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

            /// <summary>
            /// Tests whether the method accepts an async method returning a string.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task AcceptsAsyncMethodsReturningString()
            {
                var menuTarget = new TestMenuTargetWithStaticMethods();
                var target = MenuItem.Print(() => TestMenuTargetWithStaticMethods.WithAsyncStringResult(menuTarget));
                await target.Action.Invoke().ConfigureAwait(false);
                Assert.AreEqual("ok", menuTarget.Result);
            }

            /// <summary>
            /// Tests whether the method accepts an async method returning an <see cref="IEnumerable{T}"/> of string.
            /// </summary>
            /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
            [TestMethod]
            public async Task AcceptsAsyncMethodsReturningIEnumerableString()
            {
                var menuTarget = new TestMenuTargetWithStaticMethods();
                var target = MenuItem.Print(() => TestMenuTargetWithStaticMethods.WithAsyncIEnumerableStringResult(menuTarget));
                await target.Action.Invoke().ConfigureAwait(false);
                Assert.AreEqual("ok", menuTarget.Result);
            }
        }
    }
}