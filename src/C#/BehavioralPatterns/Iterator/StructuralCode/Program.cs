using System;
using System.Collections.Generic;

namespace StructuralCode
{
    public abstract class Iterator
    {
        public abstract object GetFirstItem();

        public abstract object GetNextItem();

        public abstract bool IsIterationDone();

        public abstract object GetCurrentItem();
    }

    public class ConcreteIterator : Iterator
    {
        private readonly ConcreteAggregate concreteAggregate;

        private int currentItemIndex = 0;

        public ConcreteIterator(ConcreteAggregate concreteAggregate)
        {
            this.concreteAggregate = concreteAggregate;
        }

        public override object GetFirstItem()
        {
            return concreteAggregate[0];
        }

        public override object GetNextItem()
        {
            object nextItem = null;

            if (currentItemIndex < concreteAggregate.Count - 1)
            {
                nextItem = concreteAggregate[++currentItemIndex];
            }

            return nextItem;
        }

        public override object GetCurrentItem()
        {
            return concreteAggregate[currentItemIndex];
        }

        public override bool IsIterationDone()
        {
            return currentItemIndex >= concreteAggregate.Count;
        }
    }

    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    public class ConcreteAggregate : Aggregate
    {
        private readonly List<object> items = new List<object>();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public object this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items.Insert(index, value);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate concreteAggregate = new ConcreteAggregate();

            concreteAggregate[0] = "Item A";
            concreteAggregate[1] = "Item B";
            concreteAggregate[2] = "Item C";
            concreteAggregate[3] = "Item D";

            Iterator iterator = concreteAggregate.CreateIterator();

            Console.WriteLine("Iterating over collection: ");

            object currentItem = iterator.GetFirstItem();

            while (currentItem != null)
            {
                Console.WriteLine(currentItem);
                currentItem = iterator.GetNextItem();
            }
        }
    }
}
