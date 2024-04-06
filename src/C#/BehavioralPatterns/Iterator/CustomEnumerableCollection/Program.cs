using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomEnumerableCollection
{
    public class CustomEnumerableList : IEnumerable<int>
    {
        private readonly int[] frequencyArray;

        private readonly int arrayCapacity;

        public CustomEnumerableList(int arrayCapacity)
        {
            this.arrayCapacity = arrayCapacity;
            frequencyArray = new int[arrayCapacity];
        }

        public int[] FrequencyArray => frequencyArray;

        public int ArrayCapacity => arrayCapacity;

        public void Add(int i)
        {
            frequencyArray[i]++;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new CustomListEnumerator(this);

            //for (int i = 0; i < arrayCapacity; ++i)
            //{
            //    for (int j = frequencyArray[i]; j > 0; --j)
            //    {
            //        yield return i;
            //    }
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class CustomListEnumerator : IEnumerator<int>
    {
        private readonly CustomEnumerableList customEnumerableList;

        private int currentItemIndex;

        private int itemsCount;

        public CustomListEnumerator(CustomEnumerableList customEnumerableList)
        {
            this.customEnumerableList = customEnumerableList;
            Reset();
        }

        public int Current => currentItemIndex;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (itemsCount > 0)
            {
                itemsCount--;
                return true;
            }

            do
            {
                currentItemIndex++;
            }
            while (currentItemIndex < customEnumerableList.ArrayCapacity &&
                customEnumerableList.FrequencyArray[currentItemIndex] == 0);

            if (currentItemIndex == customEnumerableList.ArrayCapacity)
            {
                return false;
            }

            itemsCount = customEnumerableList.FrequencyArray[currentItemIndex] - 1;

            return true;
        }

        public void Reset()
        {
            currentItemIndex = -1;
            itemsCount = 0;
        }

        public void Dispose() { }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var numbersCollection = new CustomEnumerableList(4) { 1, 2, 2, 3 };

            foreach (var number in numbersCollection)
            {
                Console.WriteLine(number);
            }
        }
    }
}
