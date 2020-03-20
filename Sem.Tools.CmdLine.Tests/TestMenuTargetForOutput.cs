// <copyright file="TestMenuTargetForOutput.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

// ReSharper disable ClassNeverInstantiated.Global
namespace Sem.Tools.CmdLine.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>
    /// A class containing a method to create a menu from.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TestMenuTargetForOutput
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static Task<string> ReadSingleContact(TestMenuTarget client, Guid sampleCrmId)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return Task.FromResult("ok");
        }
    }
}