using FastFoodRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodRestaurant.Commands
{
    public abstract class OrderCommand
    {
        public abstract void Execute(List<MenuItem> fastFoodOrderMenuItems, MenuItem menuItem);
    }
}
