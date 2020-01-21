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

                System.Console.WriteLine("what should be executed?");

                if (!int.TryParse(System.Console.ReadLine(), out int number) || number >= items.Length)
                {
                    return;
                }

                System.Console.WriteLine($"executing menu item {items[number].DisplayString}");

                try
                {
                    await items[number].Action().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }

                System.Console.WriteLine("done");
                System.Console.WriteLine("press any key to continue");
                System.Console.ReadKey();
            }
        }
    }
}