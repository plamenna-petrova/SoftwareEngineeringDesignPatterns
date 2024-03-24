using System;
using System.Collections.Generic;

namespace StructuralCode
{
    public abstract class Flyweight
    {
        public abstract void ExecuteOperation(int extrinsicState);
    }

    public class ConcreteFlyweight : Flyweight
    {
        public override void ExecuteOperation(int extrinsicState)
        {
            Console.WriteLine($"ConcreteFlyweight: {extrinsicState}");
        }
    }

    public class UnsharedConcreteFlyweight : Flyweight
    {
        public override void ExecuteOperation(int extrinsicState)
        {
            Console.WriteLine($"UnsharedConcreteFlyweight : {extrinsicState}");
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> flyweights { get; set; } = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return flyweights[key];
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int extrinsicState = 22;

            FlyweightFactory flyweightFactory = new FlyweightFactory();

            Flyweight flyweightX = flyweightFactory.GetFlyweight("X");
            flyweightX.ExecuteOperation(--extrinsicState);

            Flyweight flyweightY = flyweightFactory.GetFlyweight("Y");
            flyweightY.ExecuteOperation(--extrinsicState);

            Flyweight flyweightZ = flyweightFactory.GetFlyweight("Z");
            flyweightZ.ExecuteOperation(--extrinsicState);

            UnsharedConcreteFlyweight unsharedConcreteFlyweight = new UnsharedConcreteFlyweight();

            unsharedConcreteFlyweight.ExecuteOperation(--extrinsicState);
        }
    }
}
