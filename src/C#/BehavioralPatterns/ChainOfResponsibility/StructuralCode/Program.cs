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

    public class FirstConcreteHandler : Handler
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

    public class SecondConcreteHandler : Handler
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

    public class ThirdConcreteHandler : Handler
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
            Handler firstConcreteHandler = new FirstConcreteHandler();
            Handler secondConcreteHandler = new SecondConcreteHandler();
            Handler thirdConcreteHandler = new ThirdConcreteHandler();

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
