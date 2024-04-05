using FastFoodRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodRestaurant.Commands
{
    public class AddMenuItemCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> fastFoodOrderMenuItems, MenuItem menuItem)
        {
            fastFoodOrderMenuItems.Add(menuItem);
        }
    }
}
