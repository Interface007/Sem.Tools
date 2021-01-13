// <copyright file="MicrosoftSqlDatabase.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.MicrosoftSqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Data.SqlClient;
    using SprocAccess;
    using Tools;
    using Tools.Logging;

    public class MicrosoftSqlDatabase : IDatabase
    {
        /// <summary>
        /// The connection string for the database.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftSqlDatabase"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string to use for this instance.</param>
        public MicrosoftSqlDatabase(string connectionString) => this.connectionString = connectionString;

        public MicrosoftSqlDatabase(string hostName, string databaseName)
            => this.connectionString = $@"Server={hostName};Initial Catalog={databaseName};Integrated Security=true;Connect Timeout=120";

        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftSqlDatabase"/> class.
        /// </summary>
        /// <param name="hostName">The DNS name of the SQL Server host.</param>
        /// <param name="databaseName">The name of the database to connect to.</param>
        /// <param name="clientId">The client ID of the AAD registered application.</param>
        /// <param name="clientSecret">The client secret of the AAD registered application.</param>
        public MicrosoftSqlDatabase(string hostName, string databaseName, string clientId, string clientSecret)
            => this.connectionString = $@"Server={hostName},1433;Initial Catalog={databaseName};Authentication=Active Directory Service Principal;UID={clientId};PWD={clientSecret};Connect Timeout=120";

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
            var reader = new MicrosoftSqlReader(dataReader);
            while (await reader.Read().ConfigureAwait(false))
            {
                yield return await readerToObject(reader).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs.
        /// </summary>
        /// <param name="sql">The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]").</param>
        /// <param name="logger">Optional logger.</param>
        /// <param name="parameters">The named parameters for the SPROC.</param>
        /// <returns>A series of POCO instances.</returns>
        public async Task ExecuteSql(string sql, LogScope logger = null, params KeyValuePair<string, object>[] parameters)
        {
            await using var scope = logger?.MethodStart(new { sproc = sql, parameters });

            await using var con = new SqlConnection(this.connectionString);
            await using var cmd = new SqlCommand(sql, con)
            {
                CommandType = System.Data.CommandType.Text,
            };

            foreach (var (key, value) in parameters)
            {
                _ = cmd.Parameters.AddWithValue(key, value);
            }

            await using var unused = scope?.Child("executing reader");
            await con.OpenAsync().ConfigureAwait(false);
            _ = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
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
