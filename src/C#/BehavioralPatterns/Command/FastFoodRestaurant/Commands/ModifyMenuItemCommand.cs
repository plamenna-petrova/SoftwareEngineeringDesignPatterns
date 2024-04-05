using FastFoodRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFoodRestaurant.Commands
{
    public class ModifyMenuItemCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> fastFoodOrderMenuItems, MenuItem menuItem)
        {
            var menuItemToModify = fastFoodOrderMenuItems.Where(mi => mi.Name == menuItem.Name).First();
            menuItemToModify.Price = menuItem.Price;
            menuItemToModify.Amount = menuItem.Amount;
        }
    }
}
