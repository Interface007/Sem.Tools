namespace Sem.Tools.CmdLine
{
    using System;

    public class ConsoleWrapper : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}