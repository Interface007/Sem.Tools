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

        /// <inheritdoc />
        public async IAsyncEnumerable<T> Execute<T>(string sproc, Func<IReader, Task<T>> readerToObject, LogScope logger = null, params KeyValuePair<string, object>[] parameters)
        {
            await using var scope = logger?.MethodStart(new { sproc, parameters });

            // produce a file name that includes the parameters
            var fileName = parameters
                .Aggregate("params-", (s, pair) => $"{s}-{pair.Key}={pair.Value}")
                .Replace("@", string.Empty);

            var targetPath = Path.Combine(this.baseFolder, FileSystemTools.SanitizeFileName(sproc), FileSystemTools.SanitizeFileName(fileName));

            var reader = new TxtReader(targetPath);

            scope?.Log(LogCategory.Technical, LogLevel.Trace, "reader created", reader);
            while (await reader.Read())
            {
                yield return await readerToObject(reader);
            }
        }

        /// <inheritdoc />
        public ValueTask DisposeAsync()
        {
            return default;
        }
    }
}