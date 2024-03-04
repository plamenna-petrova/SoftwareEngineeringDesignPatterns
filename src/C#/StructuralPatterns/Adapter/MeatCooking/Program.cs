using System;
using System.Text;

namespace MeatCooking
{
    public class Meat
    {
        public Meat(string meatName)
        {
            MeatName = meatName;
        }

        protected string MeatName { get; set; }

        protected double SafeCookingTemperatureInFahrenheit { get; set; }

        protected double SafeCookingTemperatureInCelsius { get; set; }

        protected double CaloriesPerOunce { get; set; }

        protected double CaloriesPerGram {  get; set; }

        protected double ProteinPerOunce { get; set; }

        protected double ProteinPerGram { get; set; }

        public virtual void LoadData() => Console.WriteLine($"\nMeat: {MeatName} {new string('-', 7)}");
    }

    public class MeatDetails : Meat
    {
        private MeatDatabase meatDatabase;

        public MeatDetails(string meatName) : base(meatName)
        {

        }

        public override void LoadData()
        {
            meatDatabase = new MeatDatabase();

            SafeCookingTemperatureInFahrenheit = meatDatabase.GetSafeCookingTemperature(MeatName);
            SafeCookingTemperatureInCelsius = FahrenheitToCelsius(SafeCookingTemperatureInFahrenheit);
            CaloriesPerOunce = meatDatabase.GetCaloriesPerOunce(MeatName);
            CaloriesPerGram = PoundsToGrams(CaloriesPerOunce);
            ProteinPerOunce = meatDatabase.GetProteinPerOunce(MeatName);
            ProteinPerGram = PoundsToGrams(ProteinPerOunce);

            base.LoadData();

            string meatDetails = new StringBuilder()
                .AppendLine($" Safe Cooking Temperature (Fahrenheit) : " +
                    $"{Math.Round(SafeCookingTemperatureInFahrenheit, 2)}")
                .AppendLine($" Safe Cooking Temperature (Celsius) : " +
                    $"{Math.Round(SafeCookingTemperatureInCelsius, 2)}")
                .AppendLine($" Calories per Ounce: " +
                    $"{Math.Round(CaloriesPerOunce, 2)}")
                .AppendLine($" Calories per Gram: " +
                    $"{Math.Round(CaloriesPerGram, 2)}")
                .AppendLine($" Protein per Ounce: " +
                    $"{Math.Round(ProteinPerOunce, 2)}")
                .AppendLine($" Protein per gram: " +
                    $"{Math.Round(ProteinPerGram, 2)}").ToString();

            Console.WriteLine(meatDetails);
        }

        private double FahrenheitToCelsius(double temperatureInFahrenheit) => (temperatureInFahrenheit - 32) * 0.55555;

        private double PoundsToGrams(double pounds) => pounds * 0.0283 / 1000;
    }

    public class MeatDatabase
    {
        public float GetSafeCookingTemperature(string meat)
        {
            switch (meat.ToLower())
            {
                case "beef":
                case "pork":
                    return 145f;
                case "chicken":
                case "turkey":
                    return 165f;
                default:
                    return 165f;
            }
        }

        public int GetCaloriesPerOunce(string meat)
        {
            switch (meat.ToLower())
            {
                case "beef":
                    return 71;
                case "pork":
                    return 69;
                case "chicken":
                    return 66;
                case "turkey":
                    return 38;
                default:
                    return 0;
            }
        }

        public double GetProteinPerOunce(string meat)
        {
            switch (meat.ToLower())
            {
                case "beef":
                    return 7.33f;
                case "pork":
                    return 7.67;
                case "chicken":
                    return 8.57;
                case "turkey":
                    return 8.5f;
                default:
                    return 0f;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Meat unknownBeef = new Meat("Beef");
            unknownBeef.LoadData();

            MeatDetails beef = new MeatDetails("Beef");
            beef.LoadData();

            MeatDetails chicken = new MeatDetails("Chicken");
            chicken.LoadData();

            MeatDetails turkey = new MeatDetails("Turkey");
            turkey.LoadData();
        }
    }
}
