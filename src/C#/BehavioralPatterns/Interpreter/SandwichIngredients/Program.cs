using System;
using System.Collections.Generic;

namespace SandwichIngredients
{
    public class Context
    {
        public string Output { get; set; }
    }

    public interface IExpression
    {
        void Interpret(Context context);
    }

    public interface ICondiment : IExpression
    {

    }

    public interface IIngredient : IExpression
    {

    }

    public class KetchupCondiment : ICondiment
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Ketchup");
        }
    }

    public class MayonnaiseCondiment : ICondiment
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Mayonnaise");
        }
    }

    public class MustardCondiment : ICondiment
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Mustard");
        }
    }

    public class CondimentsList : IExpression
    {
        private List<ICondiment> condiments;

        public CondimentsList(List<ICondiment> condiments)
        {
            this.condiments = condiments;
        }

        public void Interpret(Context context)
        {
            foreach (var condiment in condiments)
            {
                condiment.Interpret(context);
            }
        }
    }

    public class LettuceIngredient : IIngredient
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Lettuce");
        }
    }

    public class ChickenIngredient : IIngredient
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Chicken");
        }
    }

    public class IngredientsList : IExpression
    {
        private List<IIngredient> ingredients;

        public IngredientsList(List<IIngredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public void Interpret(Context context)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Interpret(context);
            }
        }
    }

    public interface IBread : IExpression
    {

    }

    public class WheatBread : IBread
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "Wheat-Bread");
        }
    }

    public class WhiteBread : IBread
    {
        public void Interpret(Context context)
        {
            context.Output += string.Format(" {0} ", "White-Bread");
        }
    }

    public class Sandwich : IExpression
    {
        private readonly IBread topBread;

        private readonly CondimentsList topCondiments;

        private readonly IngredientsList ingredients;

        private readonly CondimentsList bottomCondiments;

        private readonly IBread bottomBread;

        public Sandwich(
            IBread topBread,
            CondimentsList topCondiments,
            IngredientsList ingredients,
            CondimentsList bottomCondiments,
            IBread bottomBread
        )
        {
            this.topBread = topBread;
            this.topCondiments = topCondiments;
            this.ingredients = ingredients;
            this.bottomCondiments = bottomCondiments;
            this.bottomBread = bottomBread;
        }

        public void Interpret(Context context)
        {
            context.Output += "|";
            topBread.Interpret(context);
            context.Output += "|";
            context.Output += "<--";
            topCondiments.Interpret(context);
            context.Output += "-";
            ingredients.Interpret(context);
            context.Output += "-";
            bottomCondiments.Interpret(context);
            context.Output += "-->";
            context.Output += "|";
            bottomBread.Interpret(context);
            context.Output += "|";
            Console.WriteLine(context.Output);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Sandwich sandwich = new Sandwich(
                new WheatBread(),
                new CondimentsList(new List<ICondiment> { new MayonnaiseCondiment(), new MustardCondiment() }),
                new IngredientsList(new List<IIngredient> { new LettuceIngredient(), new ChickenIngredient() }),
                new CondimentsList(new List<ICondiment> { new KetchupCondiment() }),
                new WhiteBread()
            );

            sandwich.Interpret(new Context());
        }
    }
}
