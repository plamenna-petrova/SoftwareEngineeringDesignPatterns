using System;

namespace StructuralCode
{
    public class Target
    {
        public virtual void ExecuteRequest() => Console.WriteLine("Called Target ExecuteRequest()");
    }

    public class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void ExecuteRequest() => adaptee.ExecuteSpecificRequest();
    }

    public class Adaptee
    {
        public void ExecuteSpecificRequest() => Console.WriteLine("Called ExecuteSpecificRequest()");
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Target target = new Adapter();
            target.ExecuteRequest();
        }
    }
}
