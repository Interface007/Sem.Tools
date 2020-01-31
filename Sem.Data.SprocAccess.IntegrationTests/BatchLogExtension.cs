// <copyright file="BatchLogExtension.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Data.SprocAccess.IntegrationTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Sem.Tools.Logging;

    /// <summary>
    /// Logging batched items - this is only implemented to test the flexibility of the logging, not to be used in production.
    /// The way it is currently implemented does not provide any benefit to the logging process.
    /// </summary>
    public static class BatchLogExtension
    {
        /// <summary>
        /// Queue to collect logging items.
        /// </summary>
        private static readonly ConcurrentQueue<Tuple<LogCategories, LogLevel, LogScope, string>> Queue = new ConcurrentQueue<Tuple<LogCategories, LogLevel, LogScope, string>>();

        /// <summary>
        /// Lock to be able to pull a consistent set of items from the queue without other threads to interfere.
        /// </summary>
        private static readonly object QueueLock = new object();

        /// <summary>
        /// Simply batches the log execution - this has NO real benefit ... for testing purpose only.
        /// </summary>
        /// <param name="currentAction">The current log method.</param>
        /// <param name="batchSize">The count of logs to be collected.</param>
        /// <returns>A new log method.</returns>
        public static Action<LogCategories, LogLevel, LogScope, string> Batch(this Action<LogCategories, LogLevel, LogScope, string> currentAction, int batchSize)
        {
            if (currentAction == null)
            {
                return null;
            }

            return (logCategories, logLevel, logScope, message) =>
            {
                // ReSharper disable InconsistentlySynchronizedField
                Queue.Enqueue(new Tuple<LogCategories, LogLevel, LogScope, string>(logCategories, logLevel, logScope, message));
                if (Queue.Count < batchSize)
                {
                    return;
                }

                // ReSharper restore InconsistentlySynchronizedField
                var items = new List<Tuple<LogCategories, LogLevel, LogScope, string>>();
                lock (QueueLock)
                {
                    if (Queue.Count < batchSize)
                    {
                        return;
                    }

                    for (var i = 0; i < batchSize; i++)
                    {
                        if (Queue.TryDequeue(out var item))
                        {
                            items.Add(item);
                        }
                    }

                    foreach (var item in items)
                    {
                        currentAction(item.Item1, item.Item2, item.Item3, item.Item4);
                    }
                }
            };
        }
    }
}