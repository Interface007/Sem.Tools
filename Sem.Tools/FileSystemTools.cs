﻿// <copyright file="FileSystemTools.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

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
        public static string SanitizeFileName(this string fileName) =>
            string.IsNullOrEmpty(fileName)
                ? string.Empty
                : Sanitizer.Replace(fileName, string.Empty);
    }
}
