using Furniture.Interfaces;
using Furniture.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.ConcreteFactories
{
    public class ScandinavianFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ScandinavianCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ScandinavianChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ScandinavianDiningTable();
        }
    }
}
