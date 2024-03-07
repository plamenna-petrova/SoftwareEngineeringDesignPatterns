using System;

namespace RestaurantOrders
{
    public interface IRestaurant
    {
        void PlaceOrder(string orderName);
    }

    public class MiddleClassRestaurant : IRestaurant
    {
        public void PlaceOrder(string orderName)
        {
            Console.WriteLine($"Placing order for {orderName} at {GetType().Name}");
        }
    }

    public class FancyRestaurant : IRestaurant
    {
        public void PlaceOrder(string orderName)
        {
            Console.WriteLine($"Placing order for {orderName} at {GetType().Name}");
        }
    }

    public abstract class Order
    {
        public IRestaurant Restaurant { get; set; }

        public abstract void SendOrder();
    }

    public class DiaryFreeOrder : Order
    {
        public override void SendOrder()
        {
            Restaurant.PlaceOrder("Dairy-Free Meal");
        }
    }

    public class GlutenFreeOrder : Order
    {
        public override void SendOrder()
        {
            Restaurant.PlaceOrder("Gluten-Free Meal");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Order order = new DiaryFreeOrder();
            order.Restaurant = new MiddleClassRestaurant();
            order.SendOrder();

            order.Restaurant = new FancyRestaurant();
            order.SendOrder();

            order = new GlutenFreeOrder();
            order.Restaurant = new MiddleClassRestaurant();
            order.SendOrder();

            order.Restaurant = new FancyRestaurant();
            order.SendOrder();
        }
    }
}
