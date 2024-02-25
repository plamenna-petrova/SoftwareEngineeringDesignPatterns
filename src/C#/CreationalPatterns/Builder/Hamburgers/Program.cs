using System;
using System.Collections.Generic;

namespace Hamburgers
{
    public class Hamburger
    {
        private string hamburgerName;

        private Dictionary<string, string> ingredients = new Dictionary<string, string>();

        public Hamburger(string hamburgerName)
        {
            this.hamburgerName = hamburgerName;
        }

        public string this[string key]
        {
            get { return ingredients[key]; }
            set { ingredients[key] = value; }
        }

        public void ShowIngredients()
        {
            Console.WriteLine($"\n{new string('-', 40)}");
            Console.WriteLine($"Hamburger: {hamburgerName}");
            Console.WriteLine($" Bun: {ingredients["bun"]}");
            Console.WriteLine($" Patty: {ingredients["patty"]}");
            Console.WriteLine($" Sauce: {ingredients["sauce"]}");
            Console.WriteLine($" Cheese: {ingredients["cheese"]}");
            Console.WriteLine($" Veggies: {ingredients["veggies"]}");
            Console.WriteLine($" Extras: {ingredients["extras"]}");
        }
    }

    public abstract class HamburgerBuilder
    {
        protected Hamburger hamburger;

        public Hamburger Hamburger => hamburger;

        public abstract void AddBun();

        public abstract void AddPatty();

        public abstract void AddSauce();

        public abstract void AddCheese();

        public abstract void AddVeggies();

        public abstract void AddExtras();
    }

    public class ClassicHamburgerBuilder : HamburgerBuilder
    {
        public ClassicHamburgerBuilder()
        {
            hamburger = new Hamburger("Classic Burger");
        }

        public override void AddBun()
        {
            hamburger["bun"] = "Regular sesame bun";
        }

        public override void AddPatty()
        {
            hamburger["patty"] = "Beef patty";
        }

        public override void AddSauce()
        {
            hamburger["sauce"] = "Ketchup and mustard";
        }

        public override void AddCheese()
        {
            hamburger["cheese"] = "American cheese";
        }

        public override void AddVeggies()
        {
            hamburger["veggies"] = "Lettuce, tomato, onion, pickles";
        }

        public override void AddExtras()
        {
            hamburger["extras"] = "Bacon";
        }
    }

    public class VeggieHamburgerBuilder : HamburgerBuilder
    {
        public VeggieHamburgerBuilder()
        {
            hamburger = new Hamburger("Veggie Burger");
        }

        public override void AddBun()
        {
            hamburger["bun"] = "Whole wheat bun";
        }

        public override void AddPatty()
        {
            hamburger["patty"] = "Vegetarian patty";
        }

        public override void AddSauce()
        {
            hamburger["sauce"] = "Mayonnaise";
        }

        public override void AddCheese()
        {
            hamburger["cheese"] = "Swiss cheese";
        }

        public override void AddVeggies()
        {
            hamburger["veggies"] = "Lettuce, tomato, onion, avocado";
        }

        public override void AddExtras()
        {
            hamburger["extras"] = "Grilled mushrooms";
        }
    }

    public class BurgerKing
    {
        public void MakeHamburger(HamburgerBuilder hamburgerBuilder)
        {
            hamburgerBuilder.AddBun();
            hamburgerBuilder.AddPatty();
            hamburgerBuilder.AddSauce();
            hamburgerBuilder.AddCheese();
            hamburgerBuilder.AddVeggies();
            hamburgerBuilder.AddExtras();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BurgerKing burgerKing = new BurgerKing();

            HamburgerBuilder classicHamburgerBuilder = new ClassicHamburgerBuilder();
            burgerKing.MakeHamburger(classicHamburgerBuilder);
            classicHamburgerBuilder.Hamburger.ShowIngredients();

            HamburgerBuilder veggieHamburgerBuilder = new VeggieHamburgerBuilder();
            burgerKing.MakeHamburger(veggieHamburgerBuilder);
            veggieHamburgerBuilder.Hamburger.ShowIngredients();

            Console.ReadKey();
        }
    }
}
