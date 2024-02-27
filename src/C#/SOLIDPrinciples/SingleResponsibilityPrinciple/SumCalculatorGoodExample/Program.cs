using System;
using System.Linq;

namespace SumCalculatorGoodExample
{
    public abstract class SumCalculator
    {
        protected readonly int[] _numbers;

        public SumCalculator(int[] numbers)
        {
            _numbers = numbers;       
        }

        public abstract int Calculate();
    }

    public class FullSumCalculator : SumCalculator
    {
        public FullSumCalculator(int[] numbers)
            : base(numbers)
        {
            
        }

        public override int Calculate() => _numbers.Sum();
    }

    public class EvenNumbersSumCalculator : SumCalculator
    {
        public EvenNumbersSumCalculator(int[] numbers)
            : base(numbers)
        {
            
        }

        public override int Calculate() => _numbers.Where(num => num % 2 == 0).Sum();
    }

    public class OddNumbersSumCalculator : SumCalculator
    {
        public OddNumbersSumCalculator(int[] numbers)
            : base(numbers)
        {

        }

        public override int Calculate() => _numbers.Where(num => num % 2 != 0).Sum();
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };

            SumCalculator fullSumCalculator = new FullSumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers is: {fullSumCalculator.Calculate()}");

            Console.WriteLine();

            SumCalculator evenNumbersSumCalculator = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers is: {evenNumbersSumCalculator.Calculate()}");

            SumCalculator oddNumbersSumCalculator = new OddNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the odd numbers is: {oddNumbersSumCalculator.Calculate()}");
        }
    }
}
