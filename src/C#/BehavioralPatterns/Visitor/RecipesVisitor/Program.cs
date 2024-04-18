using System;
using System.Collections.Generic;

namespace RecipesVisitor
{
    public interface IVisitor
    {
        void VisitRecipe(Recipe recipe);

        void VisitButter(Butter butter);

        void VisitSalt(Salt salt);

        void VisitFlour(Flour flour);

        void VisitSugar(Sugar sugar);
    }

    public class CaloriesCalculator : IVisitor
    {
        public CaloriesCalculator()
        {
            TotalCalories = 0;
        }

        public double TotalCalories { get; private set; }

        public void VisitRecipe(Recipe recipe)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Accept(this);
            }
        }

        public void VisitButter(Butter butter)
        {
            double calories = butter.FatContent * butter.Quantity;
            TotalCalories += calories;
        }

        public void VisitSalt(Salt salt)
        {

        }

        public void VisitFlour(Flour flour)
        {
            double calories = 0;

            switch (flour.FlourType)
            {
                case "All-Purpose":
                    calories = 3.64 * flour.Quantity;
                    break;
                case "Whole Wheat":
                    calories = 3.39 * flour.Quantity;
                    break;
            }

            TotalCalories += calories;
        }

        public void VisitSugar(Sugar sugar)
        {
            double calories = 4.0 * sugar.SweetnessLevel * sugar.Quantity;
            TotalCalories += calories;
        }
    }

    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    public abstract class Ingredient : Element
    {
        public string Name { get; set; }

        public double Quantity { get; set; }
    }

    public class Butter : Ingredient
    {
        public double FatContent { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitButter(this);
        }
    }

    public class Salt : Ingredient
    {
        public bool IsIodized { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitSalt(this);
        }
    }

    public class Flour : Ingredient
    {
        public string FlourType { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitFlour(this);
        }
    }

    public class Sugar : Ingredient
    {
        public double SweetnessLevel { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitSugar(this);
        }
    }

    public class Recipe : Element
    {
        public List<Ingredient> Ingredients { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitRecipe(this);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var recipe = new Recipe()
            {
                Ingredients = new List<Ingredient>()
                {
                    new Butter { Name = "Butter", Quantity = 100, FatContent = 0.81 },
                    new Salt { Name = "Salt", Quantity = 10, IsIodized  = true },
                    new Flour { Name = "Flour", Quantity = 500, FlourType = "All-Purpose" },
                    new Sugar { Name = "Sugar", Quantity = 200, SweetnessLevel = 0.5 }
                }
            };

            var caloriesCalculator = new CaloriesCalculator();
            recipe.Accept(caloriesCalculator);

            Console.WriteLine(caloriesCalculator.TotalCalories);
        }
    }
}
