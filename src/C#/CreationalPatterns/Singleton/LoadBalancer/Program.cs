using System;
using System.Collections.Generic;

namespace LoadBalancer
{
    public sealed class LoadBalancer
    {
        private List<string> servers = new List<string>();

        private Random randomServer = new Random();

        private static LoadBalancer loadBalancerInstance;

        private static object lockObject = new object();

        private LoadBalancer()
        {
            servers.Add("ServerI");
            servers.Add("ServerII");
            servers.Add("ServerIII");
            servers.Add("ServerIV");
            servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            if (loadBalancerInstance == null)
            {
                lock (lockObject)
                {
                    loadBalancerInstance ??= new LoadBalancer();
                }
            }

            return loadBalancerInstance;
        }

        public string NextServer
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

            if (firstLoadBalancer == secondLoadBalancer && secondLoadBalancer == thirdLoadBalancer && 
                thirdLoadBalancer == fourthLoadBalancer)
            {
                Console.WriteLine($"Same instance of all load balancers \n");
            }

            LoadBalancer fifthLoadBalancer = LoadBalancer.GetLoadBalancer();

            for (int i = 0; i < 15; i++)
            {
                string randomServer = fifthLoadBalancer.NextServer;
                Console.WriteLine("Dispatch Request to: " + randomServer);
            }

            Console.ReadKey();
        }
    }
}
