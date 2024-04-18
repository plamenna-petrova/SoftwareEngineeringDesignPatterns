using System;

namespace StructuralCode
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            PrimitiveOperationA();
            PrimitiveOperationB();
            Console.WriteLine();
        }

        public abstract void PrimitiveOperationA();

        public abstract void PrimitiveOperationB();
    }

    public class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperationA()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperationA");
        }

        public override void PrimitiveOperationB()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperationB");
        }
    }

    public class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperationA()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperationA");
        }

        public override void PrimitiveOperationB()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperationB");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            AbstractClass concreteClassA = new ConcreteClassA();
            concreteClassA.TemplateMethod();

            AbstractClass concreteClassB = new ConcreteClassB();
            concreteClassB.TemplateMethod();
        }
    }
}
