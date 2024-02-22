using System;

namespace GenericFactory
{
    public class Alpha
    {
        public string Description { get; set; }
    }

    public class Bravo
    {
        public string Name { get; set; }
    }

    public class FactoryBase<T>
    {
        internal virtual T Create() => default;
    }

    public class AlphaFactory : FactoryBase<Alpha>
    {
        internal override Alpha Create() => new Alpha() { Description = "Alpha Here" };
    }

    public class BravoFactory : FactoryBase<Bravo>
    {
        internal override Bravo Create() => new Bravo() { Name = nameof(Bravo) };
    }

    public class ServiceLocator
    {
        public static FactoryBase<T> GetFactory<T>()
        {
            if (typeof(T) == typeof(Alpha))
            {
                return (FactoryBase<T>)(object)new AlphaFactory();
            }

            if (typeof(T) == typeof(Bravo))
            {
                return (FactoryBase<T>)(object)new BravoFactory();
            }

            throw new ArgumentException($"No factory defined for type {typeof(T)}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var alphaFactory = ServiceLocator.GetFactory<Alpha>();
                var alphaObject = alphaFactory.Create();
                Console.WriteLine($"Description: {alphaObject.Description}");

                var bravoFactory = ServiceLocator.GetFactory<Bravo>();
                var bravoObject = bravoFactory.Create();
                Console.WriteLine($"Name: {bravoObject.Name}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
