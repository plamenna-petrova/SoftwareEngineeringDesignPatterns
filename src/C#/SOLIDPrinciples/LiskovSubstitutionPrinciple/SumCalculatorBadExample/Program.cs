using System;
using System.Linq;

namespace SumCalculatorBadExample
{
    public class SumCalculator
    {
        protected readonly int[] _numbers;

        public SumCalculator(int[] numbers)
        {
            _numbers = numbers;
        }

        public virtual int Calculate() => _numbers.Sum();
    }

    public class EvenNumbersSumCalculator : SumCalculator
    {
        public EvenNumbersSumCalculator(int[] numbers)
            : base(numbers)
        {
            
        }

        public override int Calculate() => _numbers.Where(num => num % 2 == 0).Sum();
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };

            SumCalculator sumCalculator = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers is : {sumCalculator.Calculate()}");

            Console.WriteLine();

            EvenNumbersSumCalculator evenNumbersSumCalculator = new EvenNumbersSumCalculator(numbers);
            //SumCalculator evenNumbersSumCalculator = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers is: {evenNumbersSumCalculator.Calculate()}");
        }
    }
}
