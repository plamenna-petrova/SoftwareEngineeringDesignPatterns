using System;
using System.Collections.Generic;
using System.Text;

namespace Furniture.Interfaces
{
    public interface IFurnitureFactory
    {
        IFurniture CreateCabinet();

        IFurniture CreateChair();

        IFurniture CreateDiningTable();
    }
}
