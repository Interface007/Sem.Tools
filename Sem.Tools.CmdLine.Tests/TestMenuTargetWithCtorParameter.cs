// <copyright file="TestMenuTargetWithCtorParameter.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System.Threading.Tasks;

    /// <summary>
    /// A class containing method to create a menu from.
    /// </summary>
    public class TestMenuTargetWithCtorParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestMenuTargetWithCtorParameter"/> class.
        /// </summary>
        /// <param name="text">The value for the text property.</param>
        public TestMenuTargetWithCtorParameter(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Gets or sets a simple property.
        /// </summary>
        public string Text { get; set; }

#pragma warning disable 1591
        public async Task DoIt(TestMenuTargetWithCtorParameter container)
#pragma warning restore 1591
        {
            await Task.Delay(5);
            container.MustNotBeNull(nameof(container)).Text = this.Text;
        }

#pragma warning disable 1591
        public async Task DoIt()
#pragma warning restore 1591
        {
            await Task.Delay(5);
        }

#pragma warning disable 1591
        public void VoidDoIt()
#pragma warning restore 1591
        {
        }
    }
}