// <copyright file="MicrosoftSqlReader.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.MicrosoftSqlServer
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;
    using Microsoft.Data.SqlClient;
    using Sem.Data.SprocAccess;

    /// <summary>
    /// SQL serer implementation of the reader interface <see cref="IReader"/>.
    /// </summary>
    public sealed class MicrosoftSqlReader : IExtendedReader
    {
        private readonly SqlDataReader sqlDataReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftSqlReader"/> class.
        /// </summary>
        /// <param name="sqlDataReader">The data reader to read from.</param>
        public MicrosoftSqlReader(SqlDataReader sqlDataReader) => this.sqlDataReader = sqlDataReader;

        /// <summary>
        /// Advances to the next record.
        /// </summary>
        /// <returns>A value indicating whether there is still data to be read.</returns>
        public Task<bool> Read() =>
            this.sqlDataReader.ReadAsync();

        /// <summary>
        /// Reads the value of a column by its index.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="index">The column index.</param>
        /// <returns>The value of the column in the current row.</returns>
        public Task<T> Get<T>(int index) =>
            this.sqlDataReader.GetFieldValueAsync<T>(index);

        /// <summary>
        /// Reads the value of a column by its index.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <param name="type">The type of the result.</param>
        /// <returns>The value of the column in the current row.</returns>
        public Task<object> Get(int index, Type type)
        {
            var value = this.sqlDataReader.GetValue(index);
            var result = Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
            return Task.FromResult(result);
        }

        /// <summary>
        /// Advances to the next result set.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        public Task NextResult() =>
            this.sqlDataReader.NextResultAsync();

        /// <summary>
        /// Closes the reader.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        public Task Close() =>
            this.sqlDataReader.CloseAsync();

        /// <summary>
        /// Gets the index of a column by its name (case-insensitive).
        /// When there are two columns with the same name, the first index will be returned.
        /// </summary>
        /// <param name="columnName">The name of the column to search.</param>
        /// <returns>The index of the column.</returns>
        public int IndexByName(string columnName) =>
            this.sqlDataReader.GetOrdinal(columnName);

        /// <inheritdoc />
        public void Dispose() =>
            this.sqlDataReader?.Dispose();
        
        public int FieldCount => this.sqlDataReader.FieldCount;

        public string GetAsString(int index) =>
            this.sqlDataReader.IsDBNull(index) ? string.Empty : this.sqlDataReader.GetValue(index).ToString();

        public string NameByIndex(int index) => this.sqlDataReader.GetName(index);
    }
}