using Furniture.ConcreteFactories;
using Furniture.Interfaces;
using System;

namespace Furniture
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select your furniture style:");
            Console.WriteLine("[1]Classic, [2]Contemporary, [3]Scandinavian");

            if (int.TryParse(Console.ReadLine(), out int furnitureStyle))
            {
                IFurnitureFactory furnitureFactory = null;

                switch (furnitureStyle)
                {
                    case 1:
                        furnitureFactory = new ClassicFurnitureFactory();
                        break;
                    case 2:
                        furnitureFactory = new ContemporaryFurnitureFactory();
                        break;
                    case 3:
                        furnitureFactory = new ScandinavianFurnitureFactory();
                        break;
                }

                Console.WriteLine("Please select your furniture type:");
                Console.WriteLine("[1]Cabinet, [2]Chair, [3]Dining Table");

                if (int.TryParse(Console.ReadLine(), out int furnitureType))
                {
                    IFurniture furniture = null;

                    switch (furnitureType)
                    {
                        case 1:
                            furniture = furnitureFactory.CreateCabinet();
                            break;
                        case 2:
                            furniture = furnitureFactory.CreateChair();
                            break;
                        case 3:
                            furniture = furnitureFactory.CreateDiningTable();
                            break;
                    }

                    furniture.ShowFurnitureStyle();
                }
            }
        }
    }
}
