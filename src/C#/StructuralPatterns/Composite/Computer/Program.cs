using System;
using System.Collections.Generic;

namespace Computer
{
    public interface IComponent
    {
        void DisplayPrice();
    }

    public class Part : IComponent
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Part(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public void DisplayPrice()
        {
            Console.WriteLine($"{Name} : {Price}");
        }
    }

    public class Composite : IComponent
    {
        private List<IComponent> components = new List<IComponent>();

        public string Name { get; set; }

        public Composite(string name)
        {
            Name = name;
        }

        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void DisplayPrice()
        {
            Console.WriteLine(Name);

            foreach (var component in components)
            {
                component.DisplayPrice();
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            IComponent hardDisk = new Part("Hard Disk", 2000);
            IComponent ram = new Part("RAM", 3000);
            IComponent cpu = new Part("CPU", 2000);
            IComponent mouse = new Part("Mouse", 2000);
            IComponent keyboard = new Part("Keyboard", 2000);

            Composite motherBoard = new Composite("Mother Board");
            Composite cabinet = new Composite("Cabinet");
            Composite peripherals = new Composite("Peripherals");
            Composite computer = new Composite("Computer");

            motherBoard.AddComponent(cpu);
            motherBoard.AddComponent(ram);

            cabinet.AddComponent(motherBoard);
            cabinet.AddComponent(hardDisk);

            peripherals.AddComponent(mouse);
            peripherals.AddComponent(keyboard);

            computer.AddComponent(cabinet);
            computer.AddComponent(peripherals);

            computer.DisplayPrice();
            Console.WriteLine();

            keyboard.DisplayPrice();
            Console.WriteLine();

            cabinet.DisplayPrice();
            Console.Read();
        }
    }
}
