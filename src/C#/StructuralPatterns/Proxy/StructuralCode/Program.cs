using System;

namespace StructuralCode
{
    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    public class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            realSubject ??= new RealSubject();

            realSubject.Request();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }
}
