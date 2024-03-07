using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Logger
{
    public class NonSingletonLogger
    {
        private static int loggerInstancesCounter = 0;

        public NonSingletonLogger()
        {
            loggerInstancesCounter++;
            Console.WriteLine($"Created instances: {loggerInstancesCounter}");
        }

        public void LogMessage(string message) => Console.WriteLine($"Message {message}");
    }

    public sealed class LoggerSingleton
    {
        private static int loggerInstancesCounter = 0;

        private static LoggerSingleton loggerSingletonInstance = null;

        private LoggerSingleton()
        {
            loggerInstancesCounter++;
            Console.WriteLine($"Created instances: {loggerInstancesCounter}");
        }

        public static LoggerSingleton LoggerSingletonInstance
        {
            get
            {
                if (loggerSingletonInstance == null)
                {
                    loggerSingletonInstance = new LoggerSingleton();
                }

                return loggerSingletonInstance;
            }
        }

        public void LogMessage(string message) => Console.WriteLine($"Message {message}");
    }

    public sealed class LoggerSingletonWithLock
    {
        private static int loggerInstancesCounter = 0;

        private static LoggerSingletonWithLock loggerSingletonWithLockInstance = null;

        private static readonly object lockObject = new object();

        private LoggerSingletonWithLock()
        {
            loggerInstancesCounter++;
            Console.WriteLine($"Created instances: {loggerInstancesCounter}");
        }

        public static LoggerSingletonWithLock LoggerSingletonWithLockInstance
        {
            get
            {
                lock (lockObject)
                {
                    if (loggerSingletonWithLockInstance == null)
                    {
                        loggerSingletonWithLockInstance = new LoggerSingletonWithLock();
                    }
                }

                return loggerSingletonWithLockInstance;
            }
        }

        public void LogMessage(string message) => Console.WriteLine($"Message {message}");
    }

    public sealed class LoggerSingletonWithDoubleCheckedLocking
    {
        private static int loggerInstancesCounter = 0;

        private static LoggerSingletonWithDoubleCheckedLocking loggerSingletonWithDoubleCheckedLockingInstance = null;

        private static readonly object lockObject = new object();

        public LoggerSingletonWithDoubleCheckedLocking()
        {
            loggerInstancesCounter++;
            Console.WriteLine($"Created instances: {loggerInstancesCounter}");
        }

        public static LoggerSingletonWithDoubleCheckedLocking LoggerSingletonWithDoubleCheckedLockingInstance
        {
            get
            {
                if (loggerSingletonWithDoubleCheckedLockingInstance == null)
                {
                    lock (lockObject)
                    {
                        if (loggerSingletonWithDoubleCheckedLockingInstance == null)
                        {
                            loggerSingletonWithDoubleCheckedLockingInstance = new LoggerSingletonWithDoubleCheckedLocking();
                        }
                    }
                }

                return loggerSingletonWithDoubleCheckedLockingInstance;
            }
        }

        public void LogMessage(string message) => Console.WriteLine($"Message {message}");
    }

    public sealed class LoggerReadonlySingleton
    {
        private static int loggerInstancesCounter = 0;

        private static readonly LoggerReadonlySingleton loggerReadonlySingletonInstance = new LoggerReadonlySingleton();
        
        private LoggerReadonlySingleton()
        {
            loggerInstancesCounter++;
            Console.WriteLine($"Created instances: {loggerInstancesCounter}");
        }

        public static LoggerReadonlySingleton LoggerReadonlySingletonInstance => loggerReadonlySingletonInstance;

        public void LogMessage(string message) => Console.WriteLine($"Message {message}");
    }

    public sealed class LoggerSingletonWithLazyInitialization
    {
        private static int loggerInstancesCounter = 0;

        private static readonly Lazy<LoggerSingletonWithLazyInitialization> loggerSingletonWithLazyInitializationInstance = 
            new Lazy<LoggerSingletonWithLazyInitialization>(() => new LoggerSingletonWithLazyInitialization());

        private LoggerSingletonWithLazyInitialization()
        {
            loggerInstancesCounter++;
            Console.WriteLine($"Created instances: {loggerInstancesCounter}");
        }

        public static LoggerSingletonWithLazyInitialization LoggerSingletonWithLazyInitializationInstance => 
            loggerSingletonWithLazyInitializationInstance.Value;

        public void LogMessage(string message) => Console.WriteLine($"Message {message}");
    }

    public class LoggerSingletonWithLazyInitializationAndInheritance
    {
        private static int loggerInstancesCounter = 0;

        private static readonly Lazy<LoggerSingletonWithLazyInitializationAndInheritance> loggerSingletonWithLazyInitializationAndInheritanceInstance =
            new Lazy<LoggerSingletonWithLazyInitializationAndInheritance>(() => new LoggerSingletonWithLazyInitializationAndInheritance());

        private LoggerSingletonWithLazyInitializationAndInheritance()
        {
            loggerInstancesCounter++;
            Console.WriteLine($"Created instances: {loggerInstancesCounter}");
        }

        public static LoggerSingletonWithLazyInitializationAndInheritance LoggerSingletonWithLazyInitializationAndInheritanceInstance =>
            loggerSingletonWithLazyInitializationAndInheritanceInstance.Value;

        public void LogMessage(string message) => Console.WriteLine($"Message {message}");

        public class DerivedClass : LoggerSingletonWithLazyInitializationAndInheritance
        {

        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            NonSingletonLogger managerLogger = new NonSingletonLogger();
            managerLogger.LogMessage("Request message from Manager");

            NonSingletonLogger employeeLogger = new NonSingletonLogger();
            employeeLogger.LogMessage("Request message from Employee");

            Console.WriteLine(new string('-', 50));

            //LoggerSingleton managerLoggerSingleton = LoggerSingleton.LoggerSingletonInstance;
            //managerLoggerSingleton.LogMessage("Request message from Manager");

            //LoggerSingleton employeeLoggerSingleton = LoggerSingleton.LoggerSingletonInstance;
            //employeeLoggerSingleton.LogMessage("Request message from Employee");

            //Console.WriteLine(new string('-', 50));

            //Parallel.Invoke(actions: new Action[] { () => { LogManagerRequest(); }, () => { LogEmployeeRequest(); } });
            Parallel.Invoke(() => LogManagerRequest(), () => LogEmployeeRequest());
            Console.WriteLine(new string('-', 50));

            //Parallel.Invoke(() => LogManagerRequestWithLock(), () => LogEmployeeRequestWithLock());
            //Console.WriteLine(new string('-', 50));

            //Parallel.Invoke(() => LogManagerRequestWithDoubleCheckedLocking(), () => LogEmployeeRequestWithDoubleCheckedLocking());
            //Console.WriteLine(new string('-', 50));

            const int ParallelTasksIterations = 5000;

            Console.WriteLine($"Singleton with lock");
            RunParallelTask(ParallelTasksIterations, LogManagerRequestWithLock);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"Singleton with double checked locking");
            RunParallelTask(ParallelTasksIterations, LogManagerRequestWithDoubleCheckedLocking);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"Singleton with readonly");
            RunParallelTask(ParallelTasksIterations, LogManagerRequestWithReadonly);
            Console.WriteLine(new string('-', 50));

            Console.WriteLine($"Singleton with lazy initialization");
            RunParallelTask(ParallelTasksIterations, LogManagerRequestWithLazyInitialization);
            Console.WriteLine(new string('-', 50));

            Parallel.Invoke(
                () => LogManagerRequestWithLazyInitializationAndInheritance(), 
                () => LogEmployeeRequestWithLazyInitializationAndInheritance()
            );

            LoggerSingletonWithLazyInitializationAndInheritance.DerivedClass derivedLogger = 
                new LoggerSingletonWithLazyInitializationAndInheritance.DerivedClass();

            derivedLogger.LogMessage("Log request for derived class invocation");
        }

        private static void LogManagerRequest()
        {
            LoggerSingleton managerLoggerSingleton = LoggerSingleton.LoggerSingletonInstance;
            managerLoggerSingleton.LogMessage("Request message from Manager");
        }

        private static void LogEmployeeRequest()
        {
            LoggerSingleton employeeLoggerSingleton = LoggerSingleton.LoggerSingletonInstance;
            employeeLoggerSingleton.LogMessage("Request message from Employee");
        }

        private static void LogManagerRequestWithLock()
        {
            LoggerSingletonWithLock managerLoggerSingletonWithLock = LoggerSingletonWithLock.LoggerSingletonWithLockInstance;
            //managerLoggerSingletonWithLock.LogMessage("Request message from Manager");
        }

        private static void LogEmployeeRequestWithLock()
        {
            LoggerSingletonWithLock employeeLoggerSingletonWithLock = LoggerSingletonWithLock.LoggerSingletonWithLockInstance;
            employeeLoggerSingletonWithLock.LogMessage("Request message from Employee");
        }

        private static void LogManagerRequestWithDoubleCheckedLocking()
        {
            LoggerSingletonWithDoubleCheckedLocking managerLoggerSingletonWithDoubleCheckedLocking =
                LoggerSingletonWithDoubleCheckedLocking.LoggerSingletonWithDoubleCheckedLockingInstance;
            //managerLoggerSingletonWithDoubleCheckedLocking.LogMessage("Request message from Manager");
        }

        private static void LogEmployeeRequestWithDoubleCheckedLocking()
        {
            LoggerSingletonWithDoubleCheckedLocking employeeLoggerSingletonWithDoubleCheckedLocking =
                LoggerSingletonWithDoubleCheckedLocking.LoggerSingletonWithDoubleCheckedLockingInstance;
            employeeLoggerSingletonWithDoubleCheckedLocking.LogMessage("Request message from Employee");
        }

        private static void LogManagerRequestWithReadonly()
        {
            LoggerReadonlySingleton managerLoggerReadonlySingleton = LoggerReadonlySingleton.LoggerReadonlySingletonInstance;
            //managerLoggerReadonlySingleton.LogMessage("Request message from Manager");
        }

        private static void LogEmployeeRequestWithReadonly()
        {
            LoggerReadonlySingleton employeeLoggerReadonlySingleton = LoggerReadonlySingleton.LoggerReadonlySingletonInstance;
            employeeLoggerReadonlySingleton.LogMessage("Request message from Employee");
        }

        private static void LogManagerRequestWithLazyInitialization()
        {
            LoggerSingletonWithLazyInitialization managerLoggerSingletonWithLazyInitialization = 
                LoggerSingletonWithLazyInitialization.LoggerSingletonWithLazyInitializationInstance;
            //managerLoggerSingletonWithLazyInitialization.LogMessage("Request message from Manager");
        }

        private static void LogEmployeeRequestWithLazyInitialization()
        {
            LoggerSingletonWithLazyInitialization employeeLoggerSingletonWithLazyInitialization = 
                LoggerSingletonWithLazyInitialization.LoggerSingletonWithLazyInitializationInstance;
            employeeLoggerSingletonWithLazyInitialization.LogMessage("Request message from Employee");
        }

        private static void LogManagerRequestWithLazyInitializationAndInheritance()
        {
            LoggerSingletonWithLazyInitializationAndInheritance managerLoggerSingletonWithLazyInitializationAndInheritance =
                LoggerSingletonWithLazyInitializationAndInheritance.LoggerSingletonWithLazyInitializationAndInheritanceInstance;
            managerLoggerSingletonWithLazyInitializationAndInheritance.LogMessage("Request message from Manager");
        }

        private static void LogEmployeeRequestWithLazyInitializationAndInheritance()
        {
            LoggerSingletonWithLazyInitializationAndInheritance employeeLoggerSingletonWithLazyInitializationAndInheritance =
                LoggerSingletonWithLazyInitializationAndInheritance.LoggerSingletonWithLazyInitializationAndInheritanceInstance;
            employeeLoggerSingletonWithLazyInitializationAndInheritance.LogMessage("Request message from Employee");
        }

        private static void RunParallelTask(int iterations, params Action[] parallelActions)
        {
            var stopwatch = new Stopwatch();
            var percentageOfCompleteness = 0.000001;
            var time = 20 * 1000 / iterations;

            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = 4
            };

            bool isDone = false;

            Parallel.Invoke
            (() =>
            {
                stopwatch.Start();

                Parallel.For(0, iterations, parallelOptions, (i) =>
                {
                    Thread.Sleep(time);

                    lock (parallelOptions)
                    {
                        foreach (var parallelAction in parallelActions)
                        {
                            parallelAction();
                        }
                    }
                });

                stopwatch.Stop();
                isDone = true;
            },
            () =>
            {
                while (!isDone)
                {
                    Console.WriteLine(
                        Math.Round(percentageOfCompleteness * 100, 2) + " : " +
                        ((percentageOfCompleteness < 0.1) ? "oo" :
                        (stopwatch.ElapsedMilliseconds / percentageOfCompleteness / 1000.0).ToString())
                    );

                    Thread.Sleep(2000);
                }
            });

            Console.WriteLine(
                Math.Round(percentageOfCompleteness * 100, 2) + " : " +
                stopwatch.ElapsedMilliseconds / percentageOfCompleteness / 1000.0
            );
        }
    }
}
