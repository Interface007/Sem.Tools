namespace Sem.Tools.Logging
{
    using System;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class LogScope : IDisposable, IAsyncDisposable
    {
        private readonly DateTime start = DateTime.UtcNow;

        private readonly string scopeName;

        private readonly string member;

        private readonly string path;

        public static LogLevel Level => LogLevel.Trace;

        public static LogCategory Category => LogCategory.Technical | LogCategory.Business;

        public static Action<LogCategory, LogLevel, LogScope, string> LogMethod;

        public static Func<string> IdFactory { get; set; } = () => (DateTime.UtcNow.Ticks - 636818976000000000).ToString("X", CultureInfo.InvariantCulture);

        private LogScope(string scopeName, string member, string path, LogScope parent = null)
        {
            this.scopeName = scopeName;
            this.member = member;
            this.path = path;

            this.IdStack = parent?.IdStack ?? new ConcurrentStack<string>();

            var newId = LogScope.IdFactory();
            this.IdStack.Push($"{parent?.Id}/{newId.Substring(newId.Length - 4)}");

            LogMethod?.Invoke(LogCategory.Technical, LogLevel.Trace, this, $"Starting scope {scopeName} in member {member} of {path}.");
        }

        /// <summary>
        /// Gets the hierarchical ID of the scope.
        /// </summary>
        public string Id => this.IdStack.TryPeek(out var id) ? id : "0000";

        public ConcurrentStack<string> IdStack { get; private set; }

        public void Dispose()
        {
            var ms = (DateTime.UtcNow - this.start).TotalMilliseconds;
            LogMethod?.Invoke(LogCategory.Technical, LogLevel.Trace, this, $"Finished scope {this.scopeName} in member {this.member} of {this.path} - took {ms}ms.");
        }

        public static LogScope MethodStart([CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            return new LogScope("default", member, path);
        }

        public static LogScope Create(string scopeName, [CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            return new LogScope(scopeName, member, path);
        }

        public static LogScope Create(string scopeName, LogScope parent, [CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            return new LogScope(scopeName, member, path, parent);
        }

        public void Log(string message)
        {
            LogMethod?.Invoke(LogCategory.Technical, LogLevel.Trace, this, message);
        }

        public ValueTask DisposeAsync()
        {
            this.Dispose();
            return default;
        }
    }
}