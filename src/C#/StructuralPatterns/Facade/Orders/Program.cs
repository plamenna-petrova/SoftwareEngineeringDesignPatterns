using System;
using System.Collections.Generic;

namespace Orders
{
    public class Order
    {
        public string DishName { get; set; }

        public double DishPrice { get; set; }

        public string User { get; set; }

        public string ShippingAddress { get; set; }

        public double ShippingPrice { get; set; }

        public override string ToString()
        {
            return string.Format("User {0} ordered {1}. The full price is {2} dollars.", User, DishName, DishPrice + ShippingPrice);
        }
    }

    public class OnlineRestaurant
    {
        private readonly List<Order> cart;

        public OnlineRestaurant()
        {
            cart = new List<Order>();
        }

        public void AddOrderToCart(Order order)
        {
            cart.Add(order);
        }

        public void CompleteOrders()
        {
            Console.WriteLine("Orders completed. Dispatch in progress...");
        }
    }

    public class ShippingService
    {
        public Order order;

        public void AcceptOrder(Order order)
        {
            this.order = order;
        }

        public void CalculateShippingExpenses()
        {
            order.ShippingPrice = 15.5;
        }

        public void ShipOrder()
        {
            Console.WriteLine(order.ToString());
            Console.WriteLine($"The order is being shipped to {order.ShippingAddress}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var restaurant = new OnlineRestaurant();
            var shippingService = new ShippingService();

            var fishAndChipsOrder = new Order()
            {
                DishName = "Fish & Chips",
                DishPrice = 20,
                User = "Jane",
                ShippingAddress = "Random Street 1"
            };

            var sushiOrder = new Order()
            {
                DishName = "Sushi Philadelphia",
                DishPrice = 45,
                User = "Ripley",
                ShippingAddress = "Alien Street 321"
            };

            restaurant.AddOrderToCart(fishAndChipsOrder);
            restaurant.AddOrderToCart(sushiOrder);
            restaurant.CompleteOrders();

            shippingService.AcceptOrder(fishAndChipsOrder);
            shippingService.CalculateShippingExpenses();
            shippingService.ShipOrder();

            shippingService.AcceptOrder(sushiOrder);
            shippingService.CalculateShippingExpenses();
            shippingService.ShipOrder();
        }
    }
}
