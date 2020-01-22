namespace Sem.Tools.Logging.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class LoggerTestBase
    {
        public List<string> LogMessages { get; set; } = new List<string>();

        public LoggerTestBase()
        {
            LogScope.BasePath = this.BasePath();
        }

        protected void LogMethod(LogCategory category, LogLevel level, LogScope scope, string message)
        {
            this.LogMessages.Add($"{category}, {level}, {message}");
        }

        private string BasePath([CallerFilePath] string path = "")
        {
            return Path.GetDirectoryName(path);
        }
    }
}