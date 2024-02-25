using Furniture.Interfaces;
using Furniture.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.ConcreteFactories
{
    public class ContemporaryFurnitureFactory : IFurnitureFactory
    {
        public IFurniture CreateCabinet()
        {
            return new ContemporaryCabinet();
        }

        public IFurniture CreateChair()
        {
            return new ContemporaryChair();
        }

        public IFurniture CreateDiningTable()
        {
            return new ContemporaryDiningTable();
        }
    }
}
