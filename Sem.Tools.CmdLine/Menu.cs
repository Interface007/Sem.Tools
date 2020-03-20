// <copyright file="Menu.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
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
        [ExcludeFromCodeCoverage]
        public static Task Show(this MenuItem[] items)
        {
            return ShowInternal(items, new ConsoleWrapper());
        }

        /// <summary>
        /// Show the menu items and wait for selection of user.
        /// </summary>
        /// <param name="items">The items to display.</param>
        /// <param name="parameters">The parameters for method calls and/or constructors.</param>
        /// <returns>A task to wait for.</returns>
        [ExcludeFromCodeCoverage]
        public static Task Show(this MenuItem[] items, params object[] parameters)
        {
            var console = parameters.First(x => x is IConsole);
            if (console == null)
            {
                parameters = new[] { (object)new ConsoleWrapper() }.Union(parameters).ToArray();
            }

            return ShowInternal(items, parameters);
        }

        /// <summary>
        /// Show the menu items and wait for selection of user.
        /// </summary>
        /// <param name="items">The items to display.</param>
        /// <param name="parameters">The parameters for method calls and/or constructors.</param>
        /// <returns>A task to wait for.</returns>
        private static async Task ShowInternal(this MenuItem[] items, params object[] parameters)
        {
            var console = (IConsole)parameters.First(x => x is IConsole);

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

                console.WriteLine($"executing menu item #{number} {items[number].DisplayString}");

                try
                {
                    if (items[number].ActionWithParameters != null)
                    {
                        var task = items[number].ActionWithParameters(parameters);
                        if (task is Task<string> stringTask)
                        {
                            console.WriteLine(await stringTask.ConfigureAwait(false));
                        }
                        else
                        {
                            await task.ConfigureAwait(false);
                        }
                    }
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