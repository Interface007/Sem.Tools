namespace Sem.MdDocGenerator
{
    using System.Xml.Linq;

    public class MdConverterExample : MarkdownBase
    {
        public MdConverterExample(XElement el) : base(el) { }

        public override string ToString()
        {
            return $"_C# code_\n\n```c#\n{ToCodeBlock(this.Node.Value)}\n```\n\n";
        }
    }
}