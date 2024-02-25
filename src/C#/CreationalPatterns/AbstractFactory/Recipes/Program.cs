using System;

namespace Recipes
{
    public abstract class RecipeFactory
    {
        public abstract Sandwich CreateSandwich();

        public abstract Dessert CreateDessert();
    }

    public class AdultCuisine : RecipeFactory
    {
        public override Sandwich CreateSandwich()
        {
            return new BLT();
        }

        public override Dessert CreateDessert()
        {
            return new CremeBrule();
        }
    }

    public class KidsCuisine : RecipeFactory
    {
        public override Sandwich CreateSandwich()
        {
            return new GrilledCheese();
        }

        public override Dessert CreateDessert()
        {
            return new IceCreamSundae();
        }
    }

    public abstract class Sandwich
    {

    }

    public abstract class Dessert
    {

    }

    public class BLT : Sandwich
    {

    }

    public class CremeBrule : Dessert
    {

    }

    public class GrilledCheese : Sandwich
    {

    }

    public class IceCreamSundae : Dessert
    {

    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who are you? (A)dult or (C)hild?");
            char input = Console.ReadKey().KeyChar;

            RecipeFactory recipeFactory;

            switch (input)
            {
                case 'A':
                    recipeFactory = new AdultCuisine();
                    break;
                case 'C':
                    recipeFactory = new KidsCuisine();
                    break;
                default:
                    throw new NotImplementedException();
            }

            Sandwich sandwich = recipeFactory.CreateSandwich();
            Dessert dessert = recipeFactory.CreateDessert();

            Console.WriteLine($"\nSandwich: {sandwich.GetType().Name}");
            Console.WriteLine($"Dessert: {dessert.GetType().Name}");

            Console.ReadKey();
        }
    }
}
