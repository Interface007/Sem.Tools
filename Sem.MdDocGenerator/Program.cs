using System;
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
                if (file.EndsWith("Tests.xml", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var xml = File.ReadAllText(file);
                var doc = XDocument.Parse(xml);
                var md = doc.Root.ToMarkDown(string.Empty);
                File.AppendAllText(target, md);
            }
        }
    }
}
