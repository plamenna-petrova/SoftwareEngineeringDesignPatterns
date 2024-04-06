using FastFoodRestaurant.Models;
using System;

namespace FastFoodRestaurant
{
    public class Program
    {
        static void Main(string[] args)
        {
            Patron patron = new Patron();

            patron.SetCommand(1);
            patron.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
            patron.ExecuteFastFoodOrderCommand();

            patron.SetCommand(1);
            patron.SetMenuItem(new MenuItem("Hamburger", 2, 2.59));
            patron.ExecuteFastFoodOrderCommand();

            patron.SetCommand(1);
            patron.SetMenuItem(new MenuItem("Drink", 2, 1.20));
            patron.ExecuteFastFoodOrderCommand();

            patron.ShowCurrentOrder();

            patron.SetCommand(3);
            patron.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
            patron.ExecuteFastFoodOrderCommand();

            patron.ShowCurrentOrder();

            patron.SetCommand(2);
            patron.SetMenuItem(new MenuItem("Hamburger", 4, 2.59));
            patron.ExecuteFastFoodOrderCommand();

            patron.ShowCurrentOrder();
        }
    }
}
