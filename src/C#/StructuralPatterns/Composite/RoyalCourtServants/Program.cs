using System;
using System.Collections.Generic;
using System.Linq;

namespace RoyalCourtServants
{
    public interface IServant
    {
        string Name { get; }

        double Wage { get; }

        string Role { get; }

        int Productivity { get; }

        int Reliability { get; }
    }

    public class Housemaid : IServant
    {
        public Housemaid(string name, double wage, string role, int productivity, int reliability)
        {
            Name = name;
            Wage = wage;
            Role = role;
            Productivity = productivity;
            Reliability = reliability;
        }

        public string Name { get; set; }

        public double Wage { get; set; }

        public string Role { get; set; }

        public int Productivity { get; set; }

        public int Reliability { get; set; }
    }

    public class Cook : IServant
    {
        public Cook(string name, double wage, string role, int productivity, int reliability)
        {
            Name = name;
            Wage = wage;
            Role = role;
            Productivity = productivity;
            Reliability = reliability;
        }

        public string Name { get; set; }

        public double Wage { get; set; }

        public string Role { get; set; }

        public int Productivity { get; set; }

        public int Reliability { get; set; }
    }

    public class RoyalCourt
    {
        protected List<IServant> servants;

        public RoyalCourt()
        {
            servants = new List<IServant>();
        }

        public void AddServant(IServant servant)
        {
            servants.Add(servant);
        }

        public void RemoveServant(IServant servant)
        {
            if (servant.Reliability < 50)
            {
                Console.WriteLine($"{servant.Name} will be fired");
                servants.Remove(servant);
            }
            else
            {
                Console.WriteLine($"{servant.Name} won't be fired");
            }
        }

        public double GetServantsWages() => servants.Sum(s => s.Wage);

        public double GetAverageProductivity()
        {
            double averageProductivity = servants.Average(s => s.Productivity);

            if (averageProductivity < 80)
            {
                Console.WriteLine("Servants need to put more effort into their tasks");
            }
            else
            {
                Console.WriteLine("Servants have done great job so far...");
            }

            return averageProductivity;
        }

        public string GetMinimumReliability()
        {
            var servantWithMinimumReliability = servants.FirstOrDefault(x => x.Reliability == servants.Min(y => y.Reliability));

            return $"The servant {servantWithMinimumReliability.Name} with role -- " +
                $"{servantWithMinimumReliability.Role} -- has the minimum reliability of " +
                $"{servantWithMinimumReliability.Reliability} %";
        }

        public string GetMaximumReliability()
        {
            var servantWithMaximumReliability = servants.FirstOrDefault(x => x.Reliability == servants.Max(y => y.Reliability));

            return $"The servant {servantWithMaximumReliability.Name} with role -- " +
                $"{servantWithMaximumReliability.Role} -- has the maximum reliability of " +
                $"{servantWithMaximumReliability.Reliability} %";
        }

        public string ToBePromoted()
        {
            string promotionList = default;

            foreach (var servant in servants)
            {
                if (servant.Productivity >= 60)
                {
                    promotionList += $"{servant.Name} with role {servant.Role} will be promoted with " +
                        $"new wage of {servant.Wage + 50}\n";
                }
            }

            return promotionList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var firstHouseMaid = new Housemaid("Emma", 150, "cleans the hall", 65, 70);
            var secondHouseMaid = new Housemaid("Isabella", 180, "cleans the kitchen", 70, 30);
            var thirdHouseMaid = new Housemaid("Gilda", 200, "cleans the guest rooms", 50, 90);
            var fourthHouseMaid = new Housemaid("Grace", 260, "cleans the bedrooms", 70, 80);

            var firstCook = new Cook("Norman", 300, "prepares the breakfast Mondays and Fridays", 80, 90);
            var secondCook = new Cook("Ray", 280, "prepares the dinner Wednesdays and Saturdays", 75, 40);
            var thirdCook = new Cook("Don", 250, "prepares the desserts", 60, 95);
            var fourthCook = new Cook("Phil", 310, "prepares special meals", 90, 90);

            var royalCourt = new RoyalCourt();

            royalCourt.AddServant(firstHouseMaid);
            royalCourt.AddServant(secondHouseMaid);
            royalCourt.AddServant(thirdHouseMaid);
            royalCourt.AddServant(fourthHouseMaid);
            royalCourt.AddServant(firstCook);
            royalCourt.AddServant(secondCook);
            royalCourt.AddServant(thirdCook);
            royalCourt.AddServant(fourthCook);

            royalCourt.RemoveServant(firstHouseMaid);
            royalCourt.RemoveServant(secondHouseMaid);
            royalCourt.RemoveServant(thirdHouseMaid);
            royalCourt.RemoveServant(fourthHouseMaid);
            royalCourt.RemoveServant(firstCook);
            royalCourt.RemoveServant(secondCook);
            royalCourt.RemoveServant(thirdCook);
            royalCourt.RemoveServant(fourthCook);

            Console.WriteLine($"The sum of servants wages for all servants is : {royalCourt.GetServantsWages()}");
            Console.WriteLine($"The average productivity for all servants is : {royalCourt.GetAverageProductivity():N2}");
            Console.WriteLine($"The minimum reliability among all servants is : {royalCourt.GetMinimumReliability()}");
            Console.WriteLine($"The maximum reliability among all servants is : {royalCourt.GetMaximumReliability()}");
            Console.WriteLine($"Servants to be promoted : \n{royalCourt.ToBePromoted()}");
        }
    }
}