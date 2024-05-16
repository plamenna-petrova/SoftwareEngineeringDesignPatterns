using System;
using System.Collections.Generic;

namespace ProductsInStock
{
    public interface IObserver
    {
        void Update(string availability);
    }

    public class Observer : IObserver
    {
        public Observer(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }

        public void AddSubscriber(ISubject subject)
        {
            subject.RegisterObserver(this);
        }

        public void RemoveSubscriber(ISubject subject)
        {
            subject.RemoveObserver(this);
        }

        public void Update(string productAvailability)
        {
            Console.WriteLine($"Hello {UserName}, Product is now {productAvailability} on Amazon");
        }
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);

        void RemoveObserver(IObserver observer);

        void NotifyObservers();
    }

    public class Subject : ISubject
    {
        private readonly List<IObserver> observers = new List<IObserver>();

        public Subject(string productName, int productPrice, string productAvailability)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductAvailability = productAvailability;
        }

        private string ProductName { get; set; }

        private int ProductPrice { get; set; }

        private string ProductAvailability { get; set; }

        public string GetProductAvailability()
        {
            return ProductAvailability;
        }

        public void SetProductAvailability(string productAvailability)
        {
            ProductAvailability = productAvailability;
            Console.WriteLine($"Availability changed from Out of Stock to {productAvailability}");
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine($"Observer added : {((Observer)observer).UserName}");
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Console.WriteLine($"Observer removed : {((Observer)observer).UserName}");
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            Console.WriteLine($"Product Name : {ProductName}, product price : {ProductPrice}. So, notifying all registered users.");
            Console.WriteLine();

            foreach (IObserver observer in observers)
            {
                observer.Update(ProductAvailability);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Subject XiaomiRedmi = new Subject("Xiaomi Redmi Mobile", 10000, "Out Of Stock");

            Observer firstObserver = new Observer("Axel");
            firstObserver.AddSubscriber(XiaomiRedmi);

            Observer secondObserver = new Observer("Pharrell");
            secondObserver.AddSubscriber(XiaomiRedmi);

            Observer thirdObserver = new Observer("Carl");
            thirdObserver.AddSubscriber(XiaomiRedmi);

            Console.WriteLine("Xiaomi Red Mi Mobile current state : " + XiaomiRedmi.GetProductAvailability());
            Console.WriteLine();

            thirdObserver.RemoveSubscriber(XiaomiRedmi);

            XiaomiRedmi.SetProductAvailability("Available");
        }
    }
}
