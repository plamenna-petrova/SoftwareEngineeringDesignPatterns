using EraStyles.Abstraction;
using EraStyles.Client;
using EraStyles.ConcreteFactories;
using System;

namespace EraStyles
{
    public class Program
    {
        static void Main(string[] args)
        {
            int objectsCount = 1;

            Console.WriteLine($"Please select your object type number: {objectsCount}");
            Console.WriteLine("[H]House, [S]Ship, [C]Clothing");

            char objectType = Console.ReadKey().KeyChar;

            Console.WriteLine();

            while (objectType != 'E')
            {
                EraObjectStylesFactory factory = null;

                switch (objectType)
                {
                    case 'H':
                        factory = new HouseFactory();
                        break;
                    case 'S':
                        factory = new ShipFactory();
                        break;
                    case 'C':
                        factory = new ClothingFactory();
                        break;
                }

                Console.WriteLine("Enter era name: ");
                Console.WriteLine("[M]Medieval, [R]Renaissance, [V]Victorian Era");

                char eraCharacter = Console.ReadKey().KeyChar;

                Console.WriteLine();

                Era era = new Era(factory, eraCharacter);
                Console.Write($"Object Number #{objectsCount} ");
                era.Info();

                Console.WriteLine(new string('-', 50));

                Console.WriteLine($"Please select your object type: {++objectsCount}");
                Console.WriteLine("[H]House, [S]Ship, [C]Clothing");

                objectType = Console.ReadKey().KeyChar;

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
