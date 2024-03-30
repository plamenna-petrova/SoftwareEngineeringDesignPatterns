<?php

interface ILogger {
    public function log($logLevel, $message);
    public function setNextLogger($nextLogger);
}

class ConsoleLogger implements ILogger {
    private ILogger $nextLogger;

    public function setNextLogger($nextLogger): void
    {
        $this->nextLogger = $nextLogger;
    }

    public function log($logLevel, $message): void
    {
        if ($logLevel === LogLevel::Debug || $logLevel === LogLevel::Info) {
            echo "[Console Logger] $logLevel : $message\n";
        } elseif ($this->nextLogger !== null) {
            $this->nextLogger->log($logLevel, $message);
        } else {
            echo "Log cannot be processed\n";
        }
    }
}

class FileLogger implements ILogger {
    private ILogger $nextLogger;

    public function setNextLogger($nextLogger): void
    {
        $this->nextLogger = $nextLogger;
    }

    public function log($logLevel, $message): void
    {
        if ($logLevel === LogLevel::Warning) {
            echo "[File logger] $logLevel: $message\n";
        } elseif ($this->nextLogger !== null) {
            $this->nextLogger->log($logLevel, $message);
        } else {
            echo "Log cannot be processed\n";
        }
    }
}

class EmailLogger implements ILogger {
    private ILogger $nextLogger;

    public function setNextLogger($nextLogger): void
    {
        $this->nextLogger = $nextLogger;
    }

    public function log($logLevel, $message): void
    {
        if ($logLevel === LogLevel::Error) {
            echo "[Email logger] $logLevel: $message\n";
        } elseif ($this->nextLogger !== null) {
            $this->nextLogger->log($logLevel, $message);
        } else {
            echo "Log cannot be processed\n";
        }
    }
}

class LogLevel {
    const Debug = 'Debug';
    const Info = 'Info';
    const Warning = 'Warning';
    const Error = 'Error';
}

$consoleLogger = new ConsoleLogger();
$fileLogger = new FileLogger();
$emailLogger = new EmailLogger();

$consoleLogger->setNextLogger($fileLogger);
$fileLogger->setNextLogger($emailLogger);

$consoleLogger->log(LogLevel::Debug, "This is a debug message.");
$consoleLogger->log(LogLevel::Info, "This is an info message.");
$consoleLogger->log(LogLevel::Warning, "This is a warning message.");
$consoleLogger->log(LogLevel::Error, "This is an error message.");