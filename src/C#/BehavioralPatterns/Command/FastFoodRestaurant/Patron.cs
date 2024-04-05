using FastFoodRestaurant.Commands;
using FastFoodRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodRestaurant
{
    public class Patron
    {
        private OrderCommand orderCommand;

        private MenuItem menuItem;

        private readonly FastFoodOrder fastFoodOrder;

        public Patron()
        {
            fastFoodOrder = new FastFoodOrder();
        }

        public void SetCommand(int commandOption)
        {
            orderCommand = new CommandFactory().GetCommand(commandOption);
        }

        public void SetMenuItem(MenuItem menuItem)
        {
            this.menuItem = menuItem;
        }

        public void ExecuteFastFoodOrderCommand()
        {
            fastFoodOrder.ExecuteCommand(orderCommand, menuItem);
        }

        public void ShowCurrentOrder()
        {
            fastFoodOrder.ShowCurrentItems();
        }
    }
}
