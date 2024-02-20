using System;

namespace PizzaSimpleFactory
{
    public interface IPizza
    {
        string ShowDetails();
    }

    public class Neapolitan : IPizza
    {
        public string ShowDetails() => "Neapolitan is the original pizza. This delicious pie dates all " +
           "the way back to the 18th century in Naples, Italy. ";
    }

    public class Funghi : IPizza
    {
        public string ShowDetails() => "A pizza funghi, or better known as a mushroom pizza is a world famous pizza. " +
           "It doesn't need many ingredients, recipe for 2 pizzas.";
    }

    public class Pepperoni : IPizza
    {
        public string ShowDetails() => "Pepperoni is a variety of spicy salami made from cured pork and beef seasoned " +
           "with paprika and chili peppers.";
    }

    public enum PizzaType
    {
        Neapolitan,
        Pepperoni,
        Funghi
    }

    public interface IPizzaFactory
    {
        public IPizza CreatePizza(PizzaType pizzaType);
    }

    public class PizzaFactory
    {
        public IPizza CreatePizza(PizzaType pizzaType)
        {
            return pizzaType switch
            {
                PizzaType.Neapolitan => new Neapolitan(),
                PizzaType.Pepperoni => new Pepperoni(),
                PizzaType.Funghi => new Funghi(),
                _ => throw new ArgumentException("Invalid pizza type")
            };
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PizzaFactory pizzaFactory = new PizzaFactory();
                IPizza pepperoniPizza = pizzaFactory.CreatePizza(PizzaType.Pepperoni);
                Console.WriteLine(pepperoniPizza.ShowDetails());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
