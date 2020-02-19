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
        /// Gets or sets an implementation for console actions.
        /// </summary>
        public static IConsole Console { get; set; } = new ConsoleWrapper();

        /// <summary>
        /// Show the menu items and wait for selection of user.
        /// </summary>
        /// <param name="items">The items to display.</param>
        /// <returns>A task to wait for.</returns>
        public static async Task Show(this MenuItem[] items)
        {
            while (true)
            {
                Console.Clear();

                for (var i = 0; i < items.Length; i++)
                {
                    var menuItem = items[i];
                    System.Console.WriteLine($"{i}) {menuItem.DisplayString}");
                }

                Console.WriteLine("what should be executed?");

                if (!int.TryParse(System.Console.ReadLine(), out int number) || number >= items.Length)
                {
                    return;
                }

                Console.WriteLine($"executing menu item {items[number].DisplayString}");

                try
                {
                    await items[number].Action().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }

                Console.WriteLine("done");
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
            }
        }
    }
}