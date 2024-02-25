using Furniture.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Products
{
    public class ClassicChair : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a classic chair");
        }
    }
}
