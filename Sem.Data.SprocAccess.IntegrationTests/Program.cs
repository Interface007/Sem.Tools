// <copyright file="Program.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.IntegrationTests
{
    using System;
    using System.Threading.Tasks;

    using Sem.Data.SprocAccess.SqlServer;
    using Sem.Tools.Logging;

    /// <summary>
    /// Simple executable that will read the database named of a local SQL server instance
    /// using a trusted connection (current user must be able to execute SPROC [sys].[sp_databases]).
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point for the integration test program.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        public static async Task Main()
        {
            var con = "Server=.;Database=master;Trusted_Connection=True;";
            await using var db = (IDatabase)new SqlDatabase(con);

            // setting up a very simple logging method.
            LogScope.LogMethod = (category, level, scope, message) => Console.WriteLine($"{DateTime.Now:s} - {scope.Id} - {message}");

            // create a logger (providing a logger is optional for IDatabase)
            await using var logger = LogScope.Create("DB Access");

            // executing the SPROC and map the result to a simple anonymous type with just one property "Name"
            var enumerable = db.Execute(
                "sys.sp_databases",
                async reader => new
                {
                    Name = await reader.Get<string>(0).ConfigureAwait(false),
                },
                logger);

            // enumerate all database names
            await foreach (var database in enumerable)
            {
                Console.WriteLine(database);
            }
        }
    }
}
