// <copyright file="Program.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.MdDocGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using Sem.Tools.CmdLine;

    /// <summary>
    /// The process that converts documentation XML into markdown.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        public static async Task Main() =>
            await new[]
            {
                MenuItem.Print(() => Render(Path.GetFullPath("..\\..\\..\\.."))),
            }.Show().ConfigureAwait(false);

        /// <summary>
        /// Renders the XML documentation of a solution starting at path <paramref name="path"/> into a TOC and
        /// multiple MD files.
        /// </summary>
        /// <param name="path">The path to start searching for XML files.</param>
        /// <returns>A series of status messages.</returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private static async IAsyncEnumerable<string> Render(string path)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var toc = Path.Combine(path, "README.md");
            if (File.Exists(toc))
            {
                yield return "deleting existing TOC";
                File.Delete(toc);
            }

            File.Copy(Path.Combine(path, "Preface.md"), toc);
            var processedXmlFile = new List<string>();

            var files = Directory.EnumerateFiles(path, "sem.*.xml", SearchOption.AllDirectories).ToArray();
            foreach (var file in files)
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

                yield return $"processing {fileName}";
                processedXmlFile.Add(fileName);

                var target = Path.Combine(path, Path.ChangeExtension(fileName, "md"));

                if (File.Exists(target))
                {
                    yield return $"deleting existing file {fileName}";
                    File.Delete(target);
                }

                var xmlDoc = await File.ReadAllTextAsync(file).ConfigureAwait(false);
                var doc = XDocument.Parse(xmlDoc);
                var md2 = new MdConverterDoc(doc.Root, new AssemblyContext { Files = files.Select(x => Path.ChangeExtension(Path.GetFileName(x), string.Empty)?.TrimEnd('.')).ToArray(), NameSpace = doc.Root?.Element("assembly")?.Element("name")?.Value });
                await File.AppendAllTextAsync(target, md2.ToString()).ConfigureAwait(false);
                await File.AppendAllTextAsync(toc, $"\n# [{md2.Context.NameSpace}]({md2.Context.NameSpace}.md)").ConfigureAwait(false);

                var xmlProj = await File.ReadAllTextAsync(projectFile).ConfigureAwait(false);
                var proj = XDocument.Parse(xmlProj);

                await File.AppendAllTextAsync(toc, "\n" + proj.Root?.Element("PropertyGroup")?.Element("Description")?.Value).ConfigureAwait(false);
                yield return $"done rendering {fileName}";
            }
        }
    }
}
