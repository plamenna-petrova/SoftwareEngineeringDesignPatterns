using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdPartyBillingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            ThirdPartyBillingSystemV1.Engine.Run();
            Console.WriteLine();
            ThirdPartyBillingSystemV2.Engine.Run();
        }
    }
}
