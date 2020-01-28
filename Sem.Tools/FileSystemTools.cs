namespace Sem.Tools
{
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Tools for file system interaction.
    /// </summary>
    public static class FileSystemTools
    {
        /// <summary>
        /// A Regex to replace illegal characters from file names.
        /// </summary>
        private static readonly Regex Sanitizer = new Regex($"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]");

        /// <summary>
        /// Removes illegal characters from file names.
        /// </summary>
        /// <param name="fileName">The file name to sanitize.</param>
        /// <returns>The file name without illegal characters.</returns>
        public static string SanitizeFileName(string fileName)
        {
            return Sanitizer.Replace(fileName, string.Empty);
        }
    }
}
