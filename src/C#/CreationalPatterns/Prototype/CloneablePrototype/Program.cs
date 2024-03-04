using System;
using System.Collections.Generic;

namespace CloneablePrototype
{
    public class Prototype : ICloneable
    {
        public Prototype(int x)
        {
            X = x;
        }

        public int X { get; set; }

        public void PrintData()
        {
            Console.WriteLine($"with value : " + X);
        }

        public object Clone() => MemberwiseClone();
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Prototype prototype = new Prototype(10);

            Dictionary<string, Prototype> clonesDictionary = new Dictionary<string, Prototype>();

            string name = "Object";

            for (int i = 1; i < 11; i++)
            {
                string identifier = name + i.ToString();
                clonesDictionary[identifier] = prototype.Clone() as Prototype;
                clonesDictionary[identifier].X *= i;
                Console.Write("{0} ", identifier);
                clonesDictionary[identifier].PrintData();
            }
        }
    }
}
