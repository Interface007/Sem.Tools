// <copyright file="Mermaid.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    public sealed class Mermaid : IDisposable, IMermaid
    {
        private static readonly string Path = Environment.GetEnvironmentVariable("mermaid-target-path");
        private static readonly bool Configured = !string.IsNullOrEmpty(Path);
        private static readonly Stack<string> Stack = Configured ? new() : null;

        static Mermaid()
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

            Write("sequenceDiagram\n");
        }

        [DebuggerStepThrough]
        private Mermaid(string memberName, string sourceFilePath)
        {
            if (!Configured)
            {
                return;
            }

            var source = Stack.Count > 0 ? Stack.Peek() : "client";
            var name = System.IO.Path.GetFileNameWithoutExtension(sourceFilePath);
            Stack.Push(name);

            Write($"    {source}->>+{name} : {memberName}");
        }

        [DebuggerStepThrough]
        public static Mermaid Method([CallerMemberName] string name = "", [CallerFilePath] string path = "")
            => Configured ? new Mermaid(name, path) : null;

        [DebuggerStepThrough]
        public void Dispose()
        {
            if (!Configured)
            {
                return;
            }

            var name = Stack.Pop();
            var source = Stack.Count > 0 ? Stack.Peek() : "client";

            Write($"    {name}->>-{source} : result");
        }

        [DebuggerStepThrough]
        private static void Write(string line) => File.AppendAllText(Path, line);
    }
}
