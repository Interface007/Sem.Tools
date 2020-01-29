namespace Sem.Data.SprocAccess.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using Sem.Tools.Logging;

    /// <summary>
    /// An implementation of <see cref="IDatabase"/> using SQL server as a backend.
    /// </summary>
    public class SqlDatabase : IDatabase
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDatabase"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string to use for this instance.</param>
        public SqlDatabase(string connectionString) => this.connectionString = connectionString;

        /// <inheritdoc />
        public async IAsyncEnumerable<T> Execute<T>(string sproc, Func<IReader, Task<T>> readerToObject, LogScope logger = null, params KeyValuePair<string, object>[] parameters)
        {
            await using var scope = logger?.MethodStart(new { sproc, parameters });
            await using var con = new SqlConnection(this.connectionString);
            await using var cmd = new SqlCommand(sproc, con)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
            };

            foreach (var (key, value) in parameters)
            {
                cmd.Parameters.AddWithValue(key, value);
            }

            await using (var unused = scope?.Child("opening connection"))
            {
                await con.OpenAsync();
            }

            await using (var unused = scope?.Child("executing reader"))
            {
                var reader = new SqlReader(await cmd.ExecuteReaderAsync());
                while (await reader.Read())
                {
                    yield return await readerToObject(reader);
                }
            }
        }

        /// <inheritdoc />
        public ValueTask DisposeAsync()
        {
            return default;
        }
    }
}