using System;
using System.Threading;

namespace DeadLock
{
    public class Program
    {
        private static object firstLock = new object();

        private static object secondLock = new object();

        static void Main(string[] args)
        {
            Thread firstThread = new Thread(ExecuteFirstThread);
            Thread secondThread = new Thread(ExecuteSecondThread);

            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();

            Console.WriteLine("Main program has finished.");
        }

        private static void ExecuteFirstThread()
        {
            lock (firstLock)
            {
                Console.WriteLine("Thread 1: Holding lock1...");
                Thread.Sleep(100);

                Console.WriteLine("Thread 1: Waiting for lock2...");

                lock (secondLock)
                {
                    Console.WriteLine("Thread 1: Acquired lock2!");
                }
            }
        }

        private static void ExecuteSecondThread()
        {
            lock (secondLock)
            {
                Console.WriteLine("Thread 2: Holding lock2...");
                Thread.Sleep(100);

                Console.WriteLine("Thread 2: Waiting for lock1...");

                lock (firstLock)
                {
                    Console.WriteLine("Thread 2: Acquired lock1!");
                }
            }
        }
    }
}
