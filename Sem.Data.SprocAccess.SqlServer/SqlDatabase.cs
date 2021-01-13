// <copyright file="SqlDatabase.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using Sem.Tools;
    using Sem.Tools.Logging;

    /// <summary>
    /// An implementation of <see cref="IDatabase"/> using SQL server as a backend.
    /// </summary>
    public class SqlDatabase : IDatabase
    {
        /// <summary>
        /// The connection string for the database.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabase"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string to use for this instance.</param>
        public SqlDatabase(string connectionString) => this.connectionString = connectionString;

        /// <summary>
        /// Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs.
        /// </summary>
        /// <typeparam name="T">The POCO type to map the result to.</typeparam>
        /// <param name="sproc">The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").</param>
        /// <param name="readerToObject">A function that maps a single result into a POCO instance.</param>
        /// <param name="logger">Optional logger.</param>
        /// <param name="parameters">The named parameters for the SPROC.</param>
        /// <returns>A series of POCO instances.</returns>
        public async IAsyncEnumerable<T> Execute<T>(string sproc, Func<IReader, Task<T>> readerToObject, LogScope logger = null, params KeyValuePair<string, object>[] parameters)
        {
            _ = readerToObject.MustNotBeNull(nameof(readerToObject));
            await using var scope = logger?.MethodStart(new { sproc, parameters });
            if (sproc.MustNotBeNullOrEmpty(nameof(sproc)).Contains('\'', StringComparison.Ordinal))
            {
                throw new ArgumentOutOfRangeException(nameof(sproc), "Must not contain the character >'<");
            }

            await using var con = new SqlConnection(this.connectionString);
            await using var cmd = new SqlCommand(sproc, con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
            };

            foreach (var (key, value) in parameters)
            {
                _ = cmd.Parameters.AddWithValue(key, value);
            }

            await using var unused = scope?.Child("executing reader");
            await con.OpenAsync().ConfigureAwait(false);
            await using var dataReader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
            var reader = new SqlReader(dataReader);
            while (await reader.Read().ConfigureAwait(false))
            {
                yield return await readerToObject(reader).ConfigureAwait(false);
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.</summary>
        /// <returns>A task that represents the asynchronous dispose operation.</returns>
        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return default;
        }
    }
}