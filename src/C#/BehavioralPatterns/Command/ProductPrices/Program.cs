using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductPrices
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public void IncreasePrice(double amount)
        {
            Price += amount;
            Console.WriteLine($"The for the {Name} has been increased by {amount}$.");
        }

        public bool DecreasePrice(double amount)
        {
            if (amount < Price)
            {
                Price -= amount;
                Console.WriteLine($"The price for the {Name} has been decreased by {amount}$.");
                return true;
            }

            return false;
        }

        public override string ToString() => $"The current price for the {Name} product is {Price}$.";
    }

    public interface ICommand
    {
        void ExecuteAction();

        void UndoAction();
    }

    public enum PriceAction
    {
        Increase,
        Decrease
    }

    public class ProductCommand : ICommand
    {
        private readonly Product product;

        private readonly PriceAction priceAction;

        private readonly double amount;

        public ProductCommand(Product product, PriceAction priceAction, double amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }

        public bool IsCommandExecuted { get; private set; }

        public void ExecuteAction()
        {
            if (priceAction == PriceAction.Increase)
            {
                product.IncreasePrice(amount);
                IsCommandExecuted = true;
            }
            else
            {
                IsCommandExecuted = product.DecreasePrice(amount);
            }
        }

        public void UndoAction()
        {
            if (!IsCommandExecuted)
            {
                return;
            }

            if (priceAction == PriceAction.Increase)
            {
                product.DecreasePrice(amount);
            }
            else
            {
                product.IncreasePrice(amount);
            }
        }
    }

    public class PriceModifier
    {
        private readonly List<ICommand> commands;

        private ICommand command;

        public PriceModifier()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => this.command = command;

        public void Invoke()
        {
            commands.Add(command);
            command.ExecuteAction();
        }

        public void UndoActions()
        {
            foreach (var command in Enumerable.Reverse(commands))
            {
                command.UndoAction();
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var priceModifier = new PriceModifier();

            var product = new Product("Phone", 500);

            Execute(priceModifier, new ProductCommand(product, PriceAction.Increase, 100));

            Execute(priceModifier, new ProductCommand(product, PriceAction.Increase, 50));

            Execute(priceModifier, new ProductCommand(product, PriceAction.Decrease, 25));

            Console.WriteLine(product);
            Console.WriteLine();

            priceModifier.UndoActions();

            Console.WriteLine(product);
        }

        private static void Execute(PriceModifier priceModifier, ICommand productCommand)
        {
            priceModifier.SetCommand(productCommand);
            priceModifier.Invoke();
        }
    }
}
