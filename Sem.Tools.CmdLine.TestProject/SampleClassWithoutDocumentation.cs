// <copyright file="SampleClassWithoutDocumentation.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.TestProject
{
    using System.Diagnostics.CodeAnalysis;

    public class SampleClassWithoutDocumentation
    {
        [ExcludeFromCodeCoverage]
        public void JustASimpleMethod()
        {
        }
    }
}
