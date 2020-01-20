using System.Threading.Tasks;

namespace Sem.Tools.Logging
{
    using System;
    using System.Runtime.CompilerServices;

    public class LogScope : IDisposable, IAsyncDisposable
    {
        private readonly DateTime start = DateTime.UtcNow;

        private readonly string scopeName;
        private readonly string member;
        private readonly string path;

        public static LogLevel Level => LogLevel.Trace;

        public static LogCategory Category => LogCategory.Technical | LogCategory.Business;

        public static Action<LogCategory, LogLevel, string> LogMethod;

        private LogScope(string scopeName, string member, string path)
        {
            this.scopeName = scopeName;
            this.member = member;
            this.path = path;
            LogMethod?.Invoke(LogCategory.Technical, LogLevel.Trace, $"Starting scope {scopeName} in member {member} of {path}.");
        }

        public void Dispose()
        {
            var ms = (DateTime.UtcNow - this.start).TotalMilliseconds;
            LogMethod?.Invoke(LogCategory.Technical, LogLevel.Trace, $"Finished scope {this.scopeName} in member {this.member} of {this.path} - took {ms}ms.");
        }

        public static LogScope MethodStart([CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            return new LogScope("default", member, path);
        }

        public static LogScope Create(string scopeName, [CallerMemberName] string member = "", [CallerFilePath] string path = "")
        {
            return new LogScope(scopeName, member, path);
        }

        public void Log(string message)
        {
            LogMethod?.Invoke(LogCategory.Technical, LogLevel.Trace, message);
        }

        public ValueTask DisposeAsync()
        {
            this.Dispose();
            return default;
        }
    }
}