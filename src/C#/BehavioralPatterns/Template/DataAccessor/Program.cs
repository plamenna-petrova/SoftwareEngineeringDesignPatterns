using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessor
{
    public abstract class DataAccessor
    {
        public abstract void Connect();

        public abstract void Select();

        public abstract void Process(int top);

        public abstract void Disconnect();

        public void Run(int top)
        {
            Connect();
            Select();
            Process(top);
            Disconnect();
        }
    }

    public class Categories : DataAccessor
    {
        private List<string> categories;

        public override void Connect()
        {
            categories = new List<string>();
        }

        public override void Select()
        {
            categories.Add("Red");
            categories.Add("Green");
            categories.Add("Blue");
            categories.Add("Orange");
            categories.Add("Purple");
            categories.Add("White");
            categories.Add("Black");
        }

        public override void Process(int top)
        {
            Console.WriteLine("Categories ---- ");

            foreach (var category in categories.Take(top))
            {
                Console.WriteLine(category);
            }

            Console.WriteLine();
        }

        public override void Disconnect()
        {
            categories.Clear();
        }
    }

    public class Products : DataAccessor
    {
        private List<string> products;

        public override void Connect()
        {
            products = new List<string>();
        }

        public override void Select()
        {
            products.Add("Car");
            products.Add("Bike");
            products.Add("Boat");
            products.Add("Truck");
            products.Add("Moped");
            products.Add("Rollerskate");
            products.Add("Stroller");
        }

        public override void Process(int top)
        {
            Console.WriteLine("Products ---- ");

            foreach (var product in products.Take(top))
            {
                Console.WriteLine(product);
            }
        }

        public override void Disconnect()
        {
            products.Clear();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            DataAccessor categories = new Categories();
            categories.Run(5);

            DataAccessor products = new Products();
            products.Run(3);
        }
    }
}
