using Laptops.Builder;
using Laptops.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laptops.ConcreteBuilders
{
    public class ASUSConcreteBuilder : LaptopBuilder
    {
        public ASUSConcreteBuilder()
        {
            Laptop = new Laptop();
        }

        public override void SetModel()
        {
            Console.Write("Enter Laptop Model: ");
            Laptop.Model = Console.ReadLine();
        }

        public override void SetCPUSeries()
        {
            Console.Write("Enter CPU Series: ");
            Laptop.CPUSeries = Console.ReadLine();
        }

        public override void SetGPUModel()
        {
            Console.Write("Enter GPU Model: ");
            Laptop.GPUModel = Console.ReadLine();
        }

        public override void SetRAMType()
        {
            Console.Write("Enter RAM Type: ");
            Laptop.RAMType = Console.ReadLine();
        }

        public override void SetRAMSize()
        {
            Console.Write("Enter RAM Size: ");
            Laptop.RAMSize = int.Parse(Console.ReadLine());
        }

        public override void SetDisplayType()
        {
            Console.Write("Enter Display Type: ");
            Laptop.DisplayType = Console.ReadLine();
        }

        public override void SetSSDType()
        {
            Console.Write("Enter SSD Type: ");
            Laptop.SSDType = Console.ReadLine();
        }

        public override void SetSSDCapacity()
        {
            Console.Write("Enter SSD Capacity: ");
            Laptop.SSDCapacity = int.Parse(Console.ReadLine());
        }

        public override void SetExtras()
        {
            Console.Write("Add extra item (Exit with END): ");
            string extraItem = Console.ReadLine();

            while (extraItem != "END")
            {
                Laptop.Extras.Add(extraItem);
                Console.Write("Add extra item (Exit with END): ");
                extraItem = Console.ReadLine();
            }
        }
    }
}
