using System;
using System.Collections.Generic;

namespace Stars
{
    public interface IStar
    {
        void Print();
    }

    public class WhiteDwarf : IStar
    {
        public void Print()
        {
            Console.WriteLine("Print white dwarf");
        }
    }

    public class RedGiant : IStar
    {
        public void Print()
        {
            Console.WriteLine("Print red giant");
        }
    }

    public class StarsFactory
    {
        private readonly Dictionary<string, IStar> stars = new Dictionary<string, IStar>();

        public int StarsCount => stars.Count;

        public IStar GetStar(string starType)
        {
            IStar star;

            if (stars.TryGetValue(starType, out IStar value))
            {
                star = value;
            }
            else
            {
                if (starType == "White Dwarf")
                {
                    star = new WhiteDwarf();
                    stars.Add(starType, star);
                }
                else
                {
                    star = new RedGiant();
                    stars.Add(starType, star);
                }
            }

            return star;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StarsFactory starsFactory = new StarsFactory();

            IStar star = starsFactory.GetStar("White Dwarf");
            star.Print();
            star = starsFactory.GetStar("White Dwarf");
            star.Print();
            star = starsFactory.GetStar("White Dwarf");
            star.Print();

            Console.WriteLine("-------------------------------");
            star = starsFactory.GetStar("Red Giant");
            star.Print();
            star = starsFactory.GetStar("Red Giant");
            star.Print();
            star = starsFactory.GetStar("Red Giant");
            star.Print();

            Console.WriteLine($"Get shapes count : {starsFactory.StarsCount}");
        }
    }
}
