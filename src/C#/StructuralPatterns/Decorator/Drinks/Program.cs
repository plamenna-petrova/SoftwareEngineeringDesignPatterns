using System;
using System.Globalization;

namespace Drinks
{
    public interface IColdDrink
    {
        int GetPrice();

        string GetDescription();
    }

    public class CocaCola : IColdDrink
    {
        public int GetPrice() => 2;

        public string GetDescription() => "simple cola";
    }

    public abstract class ColdDrinkDecorator : IColdDrink
    {
        protected readonly IColdDrink coldDrink;

        public ColdDrinkDecorator(IColdDrink coldDrink)
        {
            this.coldDrink = coldDrink ?? throw new ArgumentNullException("cold drink", "cold drink should not be null");
        }

        public virtual int GetPrice() => coldDrink.GetPrice();

        public virtual string GetDescription() => coldDrink.GetDescription();
    }

    public class IceCola : ColdDrinkDecorator
    {
        public IceCola(IColdDrink coldDrink) : base(coldDrink)
        {

        }

        public override int GetPrice() => coldDrink.GetPrice() + 1;

        public override string GetDescription() 
        { 
            return string.Concat(coldDrink.GetDescription(), ", mixed up with ice cream"); 
        }
    }

    public class CubaLibreCocktail : ColdDrinkDecorator
    {
        public CubaLibreCocktail(IColdDrink coldDrink) : base(coldDrink)
        {
            
        }

        public override int GetPrice() => coldDrink.GetPrice() + 3;

        public override string GetDescription() 
        { 
            return string.Concat(coldDrink.GetDescription(), ", mixed up with some rum,\nice and lemon"); 
        }
    }

    public class ColaMilkshake : ColdDrinkDecorator
    {
        public ColaMilkshake(IColdDrink coldDrink) : base(coldDrink)
        {

        }

        public override int GetPrice() => coldDrink.GetPrice() + 2;

        public override string GetDescription()
        {
            return string.Concat(coldDrink.GetDescription(), ",\nand milk");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string drinkInfo = $"Print drink info =================================";

            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");

            var cocaCola = new CocaCola();
            Console.WriteLine(drinkInfo);
            Console.WriteLine($"Price : {string.Format(cultureInfo, "{0:C}", cocaCola.GetPrice())}");
            Console.WriteLine($"Description : {cocaCola.GetDescription()}");
            Console.WriteLine(new string('=', 50));

            var iceCola = new IceCola(cocaCola);
            Console.WriteLine(drinkInfo);
            Console.WriteLine($"Price : {string.Format(cultureInfo, "{0:C}", iceCola.GetPrice())}");
            Console.WriteLine($"Description : {iceCola.GetDescription()}");
            Console.WriteLine(new string('=', 50));

            var cubaLibreCocktail = new CubaLibreCocktail(cocaCola);
            Console.WriteLine(drinkInfo);
            Console.WriteLine($"Price : {string.Format(cultureInfo, "{0:C}", cubaLibreCocktail.GetPrice())}");
            Console.WriteLine($"Description : {cubaLibreCocktail.GetDescription()}");
            Console.WriteLine(new string('=', 50));

            var colaMilkShake = new ColaMilkshake(iceCola);
            Console.WriteLine(drinkInfo);
            Console.WriteLine($"Price : {string.Format(cultureInfo, "{0:C}", colaMilkShake)}");
            Console.WriteLine($"Description : {colaMilkShake.GetDescription()}");
        }
    }
}
