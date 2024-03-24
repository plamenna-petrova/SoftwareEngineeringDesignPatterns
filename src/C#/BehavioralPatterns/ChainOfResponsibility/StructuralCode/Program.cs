using System;

namespace StructuralCode
{
    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}", GetType().Name, request);
            }
            else
            {
                successor?.HandleRequest(request);
            }
        }
    }

    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}", GetType().Name, request);
            }
            else
            {
                successor?.HandleRequest(request);
            }
        }
    }

    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}", GetType().Name, request);
            }
            else
            {
                successor?.HandleRequest(request);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Handler firstConcreteHandler = new ConcreteHandler1();
            Handler secondConcreteHandler = new ConcreteHandler2();
            Handler thirdConcreteHandler = new ConcreteHandler3();

            firstConcreteHandler.SetSuccessor(secondConcreteHandler);
            secondConcreteHandler.SetSuccessor(thirdConcreteHandler);

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                firstConcreteHandler.HandleRequest(request);
            }
        }
    }
}
