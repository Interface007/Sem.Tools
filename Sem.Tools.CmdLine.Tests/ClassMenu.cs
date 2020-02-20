// <copyright file="ClassMenu.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Sem.Tools.TestHelper;

    public static class ClassMenu
    {
        [TestClass]
        public class Show
        {
            [TestMethod]
            public async Task InvokesAction()
            {
                var value = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
                var menuTarget = new TestMenuTarget();
                var simulator = new ConsoleSimulator("0", " ", " ");
                MenuItem.Console = simulator;

                var target = MenuItem.MenuItemsFor<TestMenuTarget>(new { myParameterWrong = value, target = menuTarget });
                await target.Show(simulator);

                Assert.AreEqual("{clear}", simulator.Output[0]);
                Assert.AreEqual("0) Do It The Right Way", simulator.Output[1]);
                Assert.AreEqual("1) This is a good documented method.", simulator.Output[2]);
                Assert.AreEqual("2) This is a good documented void method with parameter.", simulator.Output[3]);
                Assert.AreEqual("3) This is a good documented void method.", simulator.Output[4]);
                Assert.AreEqual("what should be executed?", simulator.Output[5]);
                Assert.AreEqual("executing menu item Do It The Right Way", simulator.Output[6]);
                Assert.AreEqual("ok", simulator.Output[7]);
                Assert.AreEqual("done", simulator.Output[8]);
                Assert.AreEqual("press any key to continue", simulator.Output[9]);
            }
        }
    }
}
