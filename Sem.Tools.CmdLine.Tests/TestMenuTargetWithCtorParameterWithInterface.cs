// <copyright file="TestMenuTargetWithCtorParameterWithInterface.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.CmdLine.Tests
{
    using System.Threading.Tasks;

    /// <summary>
    /// A class containing method to create a menu from.
    /// </summary>
    public class TestMenuTargetWithCtorParameterWithInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestMenuTargetWithCtorParameterWithInterface"/> class.
        /// </summary>
        /// <param name="sample">The value for the text property.</param>
        public TestMenuTargetWithCtorParameterWithInterface(ISample sample) => this.Sample = sample;

        /// <summary>
        /// Gets or sets a simple property.
        /// </summary>
        public ISample Sample { get; set; }

#pragma warning disable 1591
        public async Task DoIt(TestMenuTargetWithCtorParameterWithInterface container)
#pragma warning restore 1591
        {
            await Task.Delay(5).ConfigureAwait(false);
            container.MustNotBeNull(nameof(container)).Sample.Text = this.Sample.Text;
        }

#pragma warning disable 1591
        public async Task DoIt() => await Task.Delay(5);
#pragma warning restore 1591

#pragma warning disable 1591
        public void VoidDoIt()
#pragma warning restore 1591
        {
        }
    }
}