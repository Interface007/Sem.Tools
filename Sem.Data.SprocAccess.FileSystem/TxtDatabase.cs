// <copyright file="TxtDatabase.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Sem.Tools;
    using Sem.Tools.Logging;

    /// <summary>
    /// Simple text file implementation of <see cref="IDatabase"/>.
    /// Can be used to mock database access easily.
    /// Each SPROC gets its own folder and each combination of parameters its own file.
    /// </summary>
    public class TxtDatabase : IDatabase
    {
        /// <summary>
        /// The base folder path.
        /// </summary>
        private readonly string baseFolder;

        /// <summary>
        /// Initializes a new instance of the <see cref="TxtDatabase"/> class.
        /// </summary>
        /// <param name="baseFolder">The base folder for the data files.</param>
        public TxtDatabase(string baseFolder)
        {
            this.baseFolder = baseFolder;
        }

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
            await using var scope = logger?.MethodStart(new { sproc, parameters });

            // produce a file name that includes the parameters
            var fileName = parameters
                .Aggregate("params-", (s, pair) => $"{s}-{pair.Key}={pair.Value}")
                .Replace("@", string.Empty, StringComparison.Ordinal);

            var targetPath = Path.Combine(this.baseFolder, sproc.SanitizeFileName(), fileName.SanitizeFileName());

            using var reader = new TxtReader(targetPath);
            scope?.Log(LogCategories.Technical, LogLevel.Trace, "reader created", reader);
            while (await reader.Read().ConfigureAwait(false))
            {
                yield return await readerToObject(reader).ConfigureAwait(false);
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.</summary>
        /// <returns>A task that represents the asynchronous dispose operation.</returns>
        public ValueTask DisposeAsync() => default;
    }
}