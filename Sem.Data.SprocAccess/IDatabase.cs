using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sem.Tools.Logging;

namespace Sem.Data.SprocAccess
{
    /// <summary>
    /// Very simple and small interface to interact with databases.
    /// </summary>
    public interface IDatabase : IAsyncDisposable
    {
        /// <summary>
        /// Executes a "stored procedure" (aka. "SPROC") and maps the result to a series of POCOs.
        /// </summary>
        /// <typeparam name="T">The POCO type to map the result to.</typeparam>
        /// <param name="sproc">The name of the stored procedure (e.g. "sys.sp_databases" or "[sys].[sp_databases]")</param>
        /// <param name="readerToObject">A function that maps a single result into a POCO instance.</param>
        /// <param name="logger">Optional logger.</param>
        /// <param name="parameters">The named parameters for the SPROC.</param>
        /// <returns>A series of POCO instances.</returns>
        IAsyncEnumerable<T> WithReader<T>(string sproc, Func<IReader, Task<T>> readerToObject, LogScope logger = null, params KeyValuePair<string, object>[] parameters);
    }
}