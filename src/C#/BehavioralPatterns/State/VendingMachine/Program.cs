using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            VendingMachine firstVendingMachine = new VendingMachine(new List<Product>
            {
                new Product("SPCOM1", 1, 3),
                new Product("SPCOM2", 3, 1)
            });

            firstVendingMachine.SelectProduct("SPCOM1");
            firstVendingMachine.InsertMoney(1);

            Console.WriteLine("========================== || ==========================");

            VendingMachine secondVendingMachine = new VendingMachine(new List<Product>
            {
                new Product("SPCOM1", 1, 1),
                new Product("SPCOM2", 3, 1)
            });

            secondVendingMachine.InsertMoney(1);
            secondVendingMachine.SelectProduct("SPCOM1");
            secondVendingMachine.InsertMoney(0.4m);
            secondVendingMachine.InsertMoney(1.2m);
            secondVendingMachine.SelectProduct("SPCOM2");
            secondVendingMachine.InsertMoney(3.2m);

            secondVendingMachine.Refill(new List<Product>
            {
                new Product("SPCOM1", 1, 3),
                new Product("SPCOM2", 3, 4)
            });

            secondVendingMachine.SelectProduct("SPCOM2");
            secondVendingMachine.InsertMoney(5.2m);

            Console.WriteLine("========================== || ==========================");

            VendingMachine thirdVendingMachine = new VendingMachine(new List<Product>
            {
                new Product("SPCOM1", 1, 3),
                new Product("SPCOM2", 3, 1)
            });

            thirdVendingMachine.SelectProduct("SPCOM1");
            thirdVendingMachine.InsertMoney(1);
        }
    }
}
