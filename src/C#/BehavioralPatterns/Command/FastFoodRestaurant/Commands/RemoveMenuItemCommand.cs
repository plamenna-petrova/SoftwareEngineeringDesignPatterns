using FastFoodRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFoodRestaurant.Commands
{
    public class RemoveMenuItemCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> fastFoodOrderMenuItems, MenuItem menuItem)
        {
            var menuItemToRemove = fastFoodOrderMenuItems.FirstOrDefault(mi => mi.Name == menuItem.Name);

            if (menuItemToRemove != null)
            {
                fastFoodOrderMenuItems.Remove(menuItemToRemove);
            }
        }
    }
}
