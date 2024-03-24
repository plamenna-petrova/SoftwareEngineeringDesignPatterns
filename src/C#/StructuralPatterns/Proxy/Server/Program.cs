using System;

namespace Server
{
    public interface IServer
    {
        void TakeOrder(string order);

        string DeliverOrder();

        void ProcessPayment(string payment);
    }

    public class Server : IServer
    {
        private string order;

        public void TakeOrder(string order)
        {
            Console.WriteLine($"Server takes order for {order}.");
            this.order = order;
        }

        public string DeliverOrder() => order;

        public void ProcessPayment(string payment)
        {
            Console.WriteLine($"Payment for order ({payment}) processed.");
        }
    }

    public class ServerProxy : IServer
    {
        private string order;

        private readonly Server server = new Server();

        public void TakeOrder(string order)
        {
            Console.WriteLine($"New trainee server takes order for {order}.");
            this.order = order;
        }

        public string DeliverOrder() => order;

        public void ProcessPayment(string payment)
        {
            Console.WriteLine("New trainee cannot process payments yet!");
            server.ProcessPayment(payment);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ServerProxy serverProxy = new ServerProxy();
            serverProxy.TakeOrder("Order #1");
            serverProxy.ProcessPayment("via Credit Card");
            Console.WriteLine($"{serverProxy.DeliverOrder()} delivered successfully.");
        }
    }
}
