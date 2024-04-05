using FastFoodRestaurant.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodRestaurant
{
    public class CommandFactory
    {
        public OrderCommand GetCommand(int commandOption)
        {
            switch (commandOption)
            {
                case 1:
                    return new AddMenuItemCommand();
                case 2:
                    return new ModifyMenuItemCommand();
                case 3:
                    return new RemoveMenuItemCommand();
                default:
                    return new AddMenuItemCommand();
            }
        }
    }
}
