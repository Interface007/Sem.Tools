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
