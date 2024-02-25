using Furniture.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Products
{
    public class ContemporaryChair : IFurniture
    {
        public void ShowFurnitureStyle()
        {
            Console.WriteLine("I am a contemporary chair");
        }
    }
}
