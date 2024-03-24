using System;

namespace Loggers
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    public interface ILogger
    {
        void Log(LogLevel level, string message);

        ILogger NextLogger { get; set; }
    }

    public class ConsoleLogger : ILogger
    {
        public ILogger NextLogger { get; set; }

        public void Log(LogLevel logLevel, string message)
        {
            if (logLevel == LogLevel.Debug || logLevel == LogLevel.Info)
            {
                Console.WriteLine($"[Console Logger] {logLevel} : {message}");
            }
            else if (NextLogger != null)
            {
                NextLogger.Log(logLevel, message);
            }
            else
            {
                Console.WriteLine("Log cannot be processed");
            }
        }
    }

    public class FileLogger : ILogger
    {
        public ILogger NextLogger { get; set; }

        public void Log(LogLevel logLevel, string message)
        {
            if (logLevel == LogLevel.Warning)
            {
                Console.WriteLine($"[File logger] {logLevel}: {message}");
            }
            else if (NextLogger != null)
            {
                NextLogger.Log(logLevel, message);
            }
            else
            {
                Console.WriteLine("Log cannot be processed");
            }
        }
    }

    public class EmailLogger : ILogger
    {
        public ILogger NextLogger { get; set; }

        public void Log(LogLevel logLevel, string message)
        {
            if (logLevel == LogLevel.Error)
            {
                Console.WriteLine($"[Email logger] {logLevel}: {message}");
            }
            else if (NextLogger != null)
            {
                NextLogger.Log(logLevel, message);
            }
            else
            {
                Console.WriteLine("Log cannot be processed");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();
            FileLogger fileLogger = new FileLogger();
            EmailLogger emailLogger = new EmailLogger();

            consoleLogger.NextLogger = fileLogger;
            fileLogger.NextLogger = emailLogger;

            consoleLogger.Log(LogLevel.Debug, "This is a debug message.");
            consoleLogger.Log(LogLevel.Info, "This is an info message.");
            consoleLogger.Log(LogLevel.Warning, "This is a warning message.");
            consoleLogger.Log(LogLevel.Error, "This is a error message");
        }
    }
}
