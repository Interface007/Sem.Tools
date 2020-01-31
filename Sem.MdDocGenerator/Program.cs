using System.IO;
using System.Xml.Linq;

namespace Sem.MdDocGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath("..\\..\\..\\..");
            var target = Path.Combine(path,"Documentation.MD");

            if (File.Exists(target))
            {
                File.Delete(target);
            }

            foreach (var file in Directory.EnumerateFiles(path, "sem.*.xml", SearchOption.AllDirectories))
            {
                var xml = File.ReadAllText(file);
                var doc = XDocument.Parse(xml);
                var md = doc.Root.ToMarkDown();
                File.AppendAllText(target, md);
            }
        }
    }
}
