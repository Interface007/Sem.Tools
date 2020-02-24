// <copyright file="TestMenuTargetForException.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System;

    /// <summary>
    /// Test case class throwing an exception.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TestMenuTargetForException
    {
        /// <summary>
        /// Simply throws an exception.
        /// </summary>
        public void ThrowException()
        {
            throw new NotImplementedException();
        }
    }
}