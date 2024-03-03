using System;

namespace StructuralCode
{
    public sealed class Singleton
    {
        private static Singleton instance;

        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            instance ??= new Singleton();

            return instance;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Singleton firstSingletonInstance = Singleton.GetInstance();
            Singleton secondSingletonInstance = Singleton.GetInstance();

            if (firstSingletonInstance == secondSingletonInstance)
            {
                Console.WriteLine("The objects share the same instance");
            }

            Console.ReadKey();
        }
    }
}
