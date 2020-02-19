// <copyright file="TxtReader.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.FileSystem
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;

    using Sem.Tools;

    /// <summary>
    /// Reader implementation for a bunch of text files - <see cref="TxtDatabase"/>.
    /// </summary>
    public sealed class TxtReader : IReader
    {
        /// <summary>
        /// The file name of the data file for this result.
        /// </summary>
        private readonly string fileName;

        /// <summary>
        /// The actual lines of the file.
        /// TODO: would be better to read the file line by line - this is for simplicity of the class ... remember: it's a non-productive 'fun' project ;-).
        /// </summary>
        private string[] fileLines;

        /// <summary>
        /// The "pointer" to the current row;.
        /// </summary>
        private int lineIndex;

        /// <summary>
        /// The index of the current result set - all data files contain a two-digit-index.
        /// </summary>
        private int resultIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="TxtReader"/> class.
        /// </summary>
        /// <param name="fileName">The name of the file containing the data.</param>
        public TxtReader(string fileName)
        {
            this.fileName = fileName;
            this.Init();
        }

        /// <summary>
        /// Increments the line pointer.
        /// </summary>
        /// <returns>A value indicating whether there is still data at this line.</returns>
        public Task<bool> Read()
        {
            this.lineIndex++;
            return Task.FromResult(this.lineIndex < this.fileLines.Length - 1);
        }

        /// <summary>
        /// Reads the value of a column by its index.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="index">The column index.</param>
        /// <returns>The value of the column in the current row.</returns>
        public async Task<T> Get<T>(int index)
        {
            return (T)(await this.Get(index, typeof(T)).ConfigureAwait(false));
        }

        /// <summary>
        /// Reads the value of a column by its index.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <param name="type">The type of the result.</param>
        /// <returns>The value of the column in the current row.</returns>
        public Task<object> Get(int index, Type type)
        {
            var value = this.fileLines[this.lineIndex + 1].Split('\t')[index];
            var typedValue =
                type == typeof(DateTime) ? DateTime.ParseExact(value, "s", CultureInfo.InvariantCulture)
                    : Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
            return Task.FromResult(typedValue);
        }

        /// <summary>
        /// Advances to the next result set.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        public Task NextResult()
        {
            this.resultIndex++;
            this.Init();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Closes the reader.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        public Task Close()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the index of a column by its name (case-insensitive).
        /// When there are two columns with the same name, the first index will be returned.
        /// </summary>
        /// <param name="columnName">The name of the column to search.</param>
        /// <returns>The index of the column.</returns>
        public int IndexByName(string columnName)
        {
            columnName.MustNotBeNullOrEmpty(nameof(columnName));
            return Array.IndexOf(
                this.fileLines[0].ToUpperInvariant().Split('\t'),
                columnName.ToUpperInvariant());
        }

        /// <summary>
        /// Reads the text file and initializes the line-pointer.
        /// </summary>
        private void Init()
        {
            this.fileLines = File.ReadAllLines($"{this.fileName}+{this.resultIndex.ToString("00", CultureInfo.InvariantCulture)}.txt");
            this.lineIndex = -1;
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}