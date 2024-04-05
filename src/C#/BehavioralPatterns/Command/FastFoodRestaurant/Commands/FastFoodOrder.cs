using FastFoodRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodRestaurant.Commands
{
    public class FastFoodOrder
    {
        public List<MenuItem> FastFoodOrderMenuItems { get; private set; } = new List<MenuItem>();

        public void ExecuteCommand(OrderCommand orderCommand, MenuItem menuItem)
        {
            orderCommand.Execute(FastFoodOrderMenuItems, menuItem);
        }

        public void ShowCurrentItems()
        {
            foreach (var fastFoodOrderMenuItem in FastFoodOrderMenuItems)
            {
                fastFoodOrderMenuItem.Display();
            }

            Console.WriteLine(new string('-', 15));
        }
    }
}
