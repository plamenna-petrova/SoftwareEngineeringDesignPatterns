
const LogLevel = {
    Debug: "Debug",
    Info: "Info",
    Warning: "Warning",
    Error: "Error"
};

class ILogger {
    constructor() {
        this.nextLogger = null;
    }

    setNextLogger(logger) {
        this.nextLogger = logger;
    }

    log(level, message) {
        throw new Error("Method 'log' must be implemented");
    }
}

class ConsoleLogger extends ILogger {
    log(level, message) {
        if (level === LogLevel.Debug || level === LogLevel.Info) {
            console.log(`[Console Logger] ${level}: ${message}`);
        } else if (this.nextLogger !== null) {
            this.nextLogger.log(level, message);
        } else {
            console.log("Log cannot be processed");
        }
    }
}

class FileLogger extends ILogger {
    log(level, message) {
        if (level === LogLevel.Warning) {
            console.log(`[File logger] ${level}: ${message}`);
        } else if (this.nextLogger !== null) {
            this.nextLogger.log(level, message);
        } else {
            console.log("Log cannot be processed");
        }
    }
}

class EmailLogger extends ILogger {
    log(level, message) {
        if (level === LogLevel.Error) {
            console.log(`[Email logger] ${level}: ${message}`);
        } else if (this.nextLogger !== null) {
            this.nextLogger.log(level, message);
        } else {
            console.log("Log cannot be processed");
        }
    }
}

const consoleLogger = new ConsoleLogger();
const fileLogger = new FileLogger();
const emailLogger = new EmailLogger();

consoleLogger.setNextLogger(fileLogger);
fileLogger.setNextLogger(emailLogger);

consoleLogger.log(LogLevel.Debug, "This is a debug message.");
consoleLogger.log(LogLevel.Info, "This is an info message.");
consoleLogger.log(LogLevel.Warning, "This is a warning message.");
consoleLogger.log(LogLevel.Error, "This is an error message.");