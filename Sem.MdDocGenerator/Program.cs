using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Sem.MdDocGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath("..\\..\\..\\..");
            var toc = Path.Combine(path, "README.md");
            if (File.Exists(toc))
            {
                File.Delete(toc);
            }

            File.Copy(Path.Combine(path, "Preface.md"), toc);
            var processedXmlFile = new List<string>();

            foreach (var file in Directory.EnumerateFiles(path, "sem.*.xml", SearchOption.AllDirectories))
            {
                if (file.EndsWith("Tests.xml", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // We will need the CS project file, so we will skip when it's not present.
                var projectFile = Path.ChangeExtension(file, "csproj");
                if (!File.Exists(projectFile))
                {
                    continue;
                }

                // Only process files once ()
                var fileName = Path.GetFileName(file);
                if (processedXmlFile.Contains(fileName))
                {
                    continue;
                }

                processedXmlFile.Add(fileName);

                var target = Path.Combine(path, Path.ChangeExtension(fileName, "md"));

                if (File.Exists(target))
                {
                    File.Delete(target);
                }

                var xmlDoc = File.ReadAllText(file);
                var doc = XDocument.Parse(xmlDoc);
                ////var md1 = doc.Root.ToMarkDown(string.Empty);
                var md2 = new MdConverterDoc(doc.Root);
                File.AppendAllText(target, md2.ToString());

                File.AppendAllText(toc, "\n# " + md2.NameSpace + $"[{md2.NameSpace}]({md2.NameSpace}.md)");

                var xmlProj = File.ReadAllText(projectFile);
                var proj = XDocument.Parse(xmlProj);

                File.AppendAllText(toc, "\n" + proj.Root?.Element("PropertyGroup")?.Element("Description")?.Value);
            }
        }
    }
}
