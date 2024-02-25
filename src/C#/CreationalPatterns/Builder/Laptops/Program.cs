using Laptops.Builder;
using Laptops.ConcreteBuilders;
using Laptops.Director;
using System;

namespace Laptops
{
    public class Program
    {
        static void Main(string[] args)
        {
            LaptopStore laptopStore = new LaptopStore();

            LaptopBuilder laptopBuilder = new ASUSConcreteBuilder();
            laptopStore.BuildLaptopConfiguration(laptopBuilder);
            laptopBuilder.Laptop.ShowDetails();

            laptopBuilder = new LenovoConcreteBuilder();
            laptopStore.BuildLaptopConfiguration(laptopBuilder);
            laptopBuilder.Laptop.ShowDetails();
        }
    }
}
