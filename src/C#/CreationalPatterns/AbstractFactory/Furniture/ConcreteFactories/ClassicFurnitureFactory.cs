using Furniture.Interfaces;
using Furniture.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.ConcreteFactories
{
    public class ClassicFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ClassicCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ClassicChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ClassicDiningTable();
        }
    }
}
