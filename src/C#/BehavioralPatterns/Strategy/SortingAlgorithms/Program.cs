using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> listOfStrings);
    }

    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> listOfStrings)
        {
            listOfStrings.Sort();
            Console.WriteLine("Quick-sorted list");
        }
    }

    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> listOfStrings)
        {
            // not-implemented
            Console.WriteLine("Shell-sorted list");
        }
    }

    public class MergeSort : SortStrategy
    {
        public override void Sort(List<string> listOfStrings)
        {
            // not-implemented
            Console.WriteLine("Merge-sorted list");
        }
    }

    public class SortedList
    {
        private List<string> namesList = new List<string>();

        private SortStrategy sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this.sortStrategy = sortStrategy;
        }

        public void Add(string name)
        {
            namesList.Add(name);
        }

        public void Sort()
        {
            sortStrategy.Sort(namesList);

            foreach (string name in namesList)
            {
                Console.WriteLine($" {name}");
            }

            Console.WriteLine();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            SortedList studentRecords = new SortedList();

            studentRecords.Add("Samuel");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();
        }
    }
}
