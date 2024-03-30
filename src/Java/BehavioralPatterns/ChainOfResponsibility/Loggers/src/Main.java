enum LogLevel {
    Debug,
    Info,
    Warning,
    Error
}

interface ILogger {
    void log(LogLevel level, String message);

    void setNextLogger(ILogger nextLogger);
}

class ConsoleLogger implements ILogger {
    private ILogger nextLogger;

    public void setNextLogger(ILogger nextLogger) {
        this.nextLogger = nextLogger;
    }

    public void log(LogLevel logLevel, String message) {
        if (logLevel == LogLevel.Debug || logLevel == LogLevel.Info) {
            System.out.println("[Console Logger] " + logLevel + " : " + message);
        } else if (nextLogger != null) {
            nextLogger.log(logLevel, message);
        } else {
            System.out.println("Log cannot be processed");
        }
    }
}

class FileLogger implements ILogger {
    private ILogger nextLogger;

    public void setNextLogger(ILogger nextLogger) {
        this.nextLogger = nextLogger;
    }

    public void log(LogLevel logLevel, String message) {
        if (logLevel == LogLevel.Warning) {
            System.out.println("[File logger] " + logLevel + ": " + message);
        } else if (nextLogger != null) {
            nextLogger.log(logLevel, message);
        } else {
            System.out.println("Log cannot be processed");
        }
    }
}

class EmailLogger implements ILogger {
    private ILogger nextLogger;

    public void setNextLogger(ILogger nextLogger) {
        this.nextLogger = nextLogger;
    }

    public void log(LogLevel logLevel, String message) {
        if (logLevel == LogLevel.Error) {
            System.out.println("[Email logger] " + logLevel + ": " + message);
        } else if (nextLogger != null) {
            nextLogger.log(logLevel, message);
        } else {
            System.out.println("Log cannot be processed");
        }
    }
}

public class Main {
    public static void main(String[] args) {
        ConsoleLogger consoleLogger = new ConsoleLogger();
        FileLogger fileLogger = new FileLogger();
        EmailLogger emailLogger = new EmailLogger();

        consoleLogger.setNextLogger(fileLogger);
        fileLogger.setNextLogger(emailLogger);

        consoleLogger.log(LogLevel.Debug, "This is a debug message.");
        consoleLogger.log(LogLevel.Info, "This is an info message.");
        consoleLogger.log(LogLevel.Warning, "This is a warning message.");
        consoleLogger.log(LogLevel.Error, "This is an error message");
    }
}