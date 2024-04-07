using System;
using System.Collections.Generic;

namespace YieldExplanation
{
    public class Program
    {
        static readonly List<int> listOfIntegers = new List<int>();

        static void FillValues()
        {
            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Add(5);
        }

        static void Main(string[] args)
        {
            FillValues();

            foreach (var i in listOfIntegers)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            foreach (var i in Filter())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            foreach (var i in FilterWithYield())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            foreach (var i in RunningTotal())
            {
                Console.WriteLine(i);
            }
        }

        static IEnumerable<int> Filter()
        {
            List<int> temp = new List<int>();

            foreach (int i in listOfIntegers)
            {
                if (i > 3)
                {
                    temp.Add(i);
                }
            }

            return temp;
        }

        static IEnumerable<int> FilterWithYield()
        {
            foreach (int i in listOfIntegers)
            {
                if (i > 3)
                {
                    yield return i;
                }
            }
        }

        static IEnumerable<int> RunningTotal()
        {
            int runningTotal = 0;

            foreach (int i in listOfIntegers)
            {
                runningTotal += i;
                yield return runningTotal;
            }
        }
    }
}
