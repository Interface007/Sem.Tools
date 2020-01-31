// <copyright file="BatchLogExtension.cs" company="Sven Erik Matzen">
// Copyright (c) Sven Erik Matzen. All rights reserved.
// </copyright>

namespace Sem.Tools.Logging
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// Extension class providing a logging method
    /// </summary>
    public static class BatchLogExtension
    {
        /// <summary>
        /// Queue to collect log messages.
        /// </summary>
        private static ConcurrentQueue<Tuple<LogCategories, LogLevel, LogScope, string>> queue = new ConcurrentQueue<Tuple<LogCategories, LogLevel, LogScope, string>>();

        /// <summary>
        /// Lock to be able to pull a consistent set of items from the queue without other threads to interfere.
        /// </summary>
        private static readonly object QueueLock = new object();

        /// <summary>
        /// Collects the messages until a minimum of <paramref name="batchSize"/> entries are available, then calls the underlying log method for these entries.
        /// </summary>
        /// <param name="currentAction">The current log method.</param>
        /// <param name="batchSize">The number of messages to wait for before processing.</param>
        /// <returns>A new log method.</returns>
        public static Action<LogCategories, LogLevel, LogScope, string> Batch(this Action<LogCategories, LogLevel, LogScope, string> currentAction, int batchSize)
        {
            if (currentAction == null)
            {
                return null;
            }

            return (logCategories, logLevel, logScope, message) =>
            {
                queue.Enqueue(new Tuple<LogCategories, LogLevel, LogScope, string>(logCategories, logLevel, logScope, message));
                if (queue.Count < batchSize)
                {
                    return;
                }

                var items = new List<Tuple<LogCategories, LogLevel, LogScope, string>>();
                lock (QueueLock)
                {
                    if (queue.Count < batchSize)
                    {
                        return;
                    }

                    for (var i = 0; i < batchSize; i++)
                    {
                        if (queue.TryDequeue(out var item))
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