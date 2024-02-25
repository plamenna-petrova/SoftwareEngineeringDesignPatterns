using Furniture.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Products
{
    public class ClassicCabinet : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a classic cabinet");
        }
    }
}
