using System.Threading.Tasks;

namespace Sem.Tools.CmdLine.Tests
{
    /// <summary>
    /// A class containing method to create a menu from.
    /// </summary>
    public class TestMenuTargetWithCtorParameter
    {
        public string Text { get; set; }

        public TestMenuTargetWithCtorParameter(string text)
        {
            Text = text;
        }

        public async Task DoIt(TestMenuTargetWithCtorParameter container)
        {
            container.Text = this.Text;
        }
    }
}