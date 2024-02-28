using System;

namespace StructuralCode
{
    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();

        public abstract AbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    public abstract class AbstractProductA
    {

    }

    public abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA abstractProductA);
    }

    public class ProductA1 : AbstractProductA
    {

    }

    public class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA abstractProductA)
        {
            Console.WriteLine($"{GetType().Name} interacts with {abstractProductA.GetType().Name}");
        }
    }

    public class ProductA2 : AbstractProductA
    {

    }

    public class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA abstractProductA)
        {
            Console.WriteLine($"{GetType().Name} interacts with {abstractProductA.GetType().Name}");
        }
    }

    public class Client
    {
        private AbstractProductA _abstractProductA;

        private AbstractProductB _abstractProductB;

        public Client(AbstractFactory abstractFactory)
        {
            _abstractProductA = abstractFactory.CreateProductA();
            _abstractProductB = abstractFactory.CreateProductB();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory concreteFactory1 = new ConcreteFactory1();
            Client client1 = new Client(concreteFactory1);
            client1.Run();

            AbstractFactory concreteFactory2 = new ConcreteFactory2();
            Client client2 = new Client(concreteFactory2);
            client2.Run();
        }
    }
}
