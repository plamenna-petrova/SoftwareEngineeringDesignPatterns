using System;
using System.Collections.Generic;

namespace LoadBalancerOptimized
{
    public class Server
    {
        public string Name { get; set; }

        public string IPAddress { get; set; }
    }

    public sealed class LoadBalancer
    {
        private readonly List<Server> servers;

        private readonly Random randomServer = new Random();

        private static readonly LoadBalancer loadBalancerInstance = new LoadBalancer();

        private LoadBalancer()
        {
            servers = new List<Server>
            {
                new Server { Name = "ServerI", IPAddress = "120.14.220.18"},
                new Server { Name = "ServerII", IPAddress = "120.14.220.19" },
                new Server { Name = "ServerIII", IPAddress = "120.14.220.20" },
                new Server { Name = "ServerIV", IPAddress = "120.14.220.21" },
                new Server { Name = "ServerV", IPAddress = "120.14.220.22" }
            };
        }

        public static LoadBalancer GetLoadBalancer() => loadBalancerInstance;

        public Server NextServer
        {
            get
            {
                int randomServerIndex = randomServer.Next(servers.Count);
                return servers[randomServerIndex];
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            LoadBalancer firstLoadBalancer = LoadBalancer.GetLoadBalancer();
            LoadBalancer secondLoadBalancer = LoadBalancer.GetLoadBalancer();
            LoadBalancer thirdLoadBalancer = LoadBalancer.GetLoadBalancer();
            LoadBalancer fourthLoadBalancer = LoadBalancer.GetLoadBalancer();

            if (firstLoadBalancer == secondLoadBalancer && secondLoadBalancer == thirdLoadBalancer 
                && thirdLoadBalancer == fourthLoadBalancer)
            {
                Console.WriteLine($"Same instance of all load balancers \n");
            }

            LoadBalancer fifthLoadBalancer = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                Server randomServer = fifthLoadBalancer.NextServer;
                Console.WriteLine($"Dispatch Request to: {randomServer.Name} at IP address: {randomServer.IPAddress}");
            }

            Console.ReadKey();
        }
    }
}
