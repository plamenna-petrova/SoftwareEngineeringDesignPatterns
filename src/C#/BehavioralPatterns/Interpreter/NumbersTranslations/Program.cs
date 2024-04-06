using System;

namespace NumbersTranslations
{
    public class NumberContext
    {
        public NumberContext(int number)
        {
            Number = number;
        }

        public int Number { get; set; }

        public string Result { get; set; } = string.Empty;
    }

    public interface INumberExpression
    {
        void Interpret(NumberContext context);
    }

    public class NumberExpression : INumberExpression
    {
        public void Interpret(NumberContext numberContext)
        {
            var numberString = numberContext.Number.ToString();

            var numberTranslations = new string[]
            {
                "Zero",
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine"
            };

            foreach (var character in numberString)
            {
                numberContext.Result += $"{numberTranslations[int.Parse(character.ToString())]}-";
            }

            numberContext.Result = numberContext.Result.Remove(numberContext.Result.Length - 1);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var numberExpression = new NumberExpression();
            var numberContext = new NumberContext(3456);

            numberExpression.Interpret(numberContext);

            string result = numberContext.Result;

            Console.WriteLine("The string is:");
            Console.WriteLine(result);
        }
    }
}
