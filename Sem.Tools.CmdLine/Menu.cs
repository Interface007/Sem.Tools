// <copyright file="Menu.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods to handle command line menu definitions.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Show the menu items and wait for selection of user.
        /// </summary>
        /// <param name="items">The items to display.</param>
        /// <returns>A task to wait for.</returns>
        public static Task Show(this MenuItem[] items)
        {
            return Show(items, new ConsoleWrapper());
        }

        /// <summary>
        /// Show the menu items and wait for selection of user.
        /// </summary>
        /// <param name="items">The items to display.</param>
        /// <param name="console">The console implementation.</param>
        /// <returns>A task to wait for.</returns>
        public static async Task Show(this MenuItem[] items, IConsole console)
        {
            while (true)
            {
                console.Clear();

                for (var i = 0; i < items.Length; i++)
                {
                    var menuItem = items[i];
                    console.WriteLine($"{i}) {menuItem.DisplayString}");
                }

                console.WriteLine("what should be executed?");

                if (!int.TryParse(console.ReadLine(), out int number) || number >= items.Length)
                {
                    return;
                }

                console.WriteLine($"executing menu item {items[number].DisplayString}");

                try
                {
                    await items[number].Action().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    console.WriteLine(e.ToString());
                }

                console.WriteLine("done");
                console.WriteLine("press any key to continue");
                console.ReadKey();
            }
        }
    }
}