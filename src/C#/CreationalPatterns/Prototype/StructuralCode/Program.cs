using System;

namespace StructuralCode
{
    public abstract class Prototype
    {
        public Prototype(string id)
        {
            ID = id;
        }

        public string ID { get; set; }

        public abstract Prototype Clone();
    }

    public class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id) : base(id)
        {

        }

        public override Prototype Clone() => (Prototype)MemberwiseClone();
    }

    public class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(string id) : base(id)
        {

        }

        public override Prototype Clone() => (Prototype)MemberwiseClone();
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ConcretePrototype1 concretePrototype1 = new ConcretePrototype1("I");
            ConcretePrototype1 clonedConcretePrototype1 = (ConcretePrototype1)concretePrototype1.Clone();
            Console.WriteLine($"Cloned: {clonedConcretePrototype1.ID}");

            ConcretePrototype2 concretePrototype2 = new ConcretePrototype2("II");
            ConcretePrototype2 clonedConcretePrototype2 = (ConcretePrototype2)concretePrototype2.Clone();
            Console.WriteLine($"Cloned: {clonedConcretePrototype2.ID}");
        }
    }
}
