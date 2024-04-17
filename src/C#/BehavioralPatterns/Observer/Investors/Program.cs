using System;
using System.Collections.Generic;

namespace Investors
{
    public abstract class Stock
    {
        private double price;

        private readonly List<IInvestor> investors = new List<IInvestor>();

        public Stock(string symbol, double price)
        {
            Symbol = symbol;
            this.price = price;
        }

        public string Symbol { get; }

        public double Price
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("");
        }
    }

    public class IBM : Stock
    {
        public IBM(string symbol, double price) : base(symbol, price)
        {

        }
    }

    public interface IInvestor
    {
        void Update(Stock stock);
    }

    public class Investor : IInvestor
    {
        private string name;

        private Stock stock;

        public Investor(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }

        public Stock Stock { get => stock; set => stock = value; }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s change to {2:C}", Name, stock.Symbol, stock.Price);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            IBM IBM = new IBM("IBM", 120.00);

            IBM.Attach(new Investor("Sorros"));
            IBM.Attach(new Investor("Berkshire"));

            IBM.Price = 120.10;
            IBM.Price = 121.00;
            IBM.Price = 120.50;
            IBM.Price = 120.75;
        }
    }
}
