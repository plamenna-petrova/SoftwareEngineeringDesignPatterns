using System;

namespace House
{
    public abstract class HouseTemplate
    {
        public void BuildHouse()
        {
            BuildFoundation();
            BuildPillars();
            BuildWalls();
            BuildWindows();
            Console.WriteLine("The house is built");
        }

        protected abstract void BuildFoundation();

        protected abstract void BuildPillars();

        protected abstract void BuildWalls();

        protected abstract void BuildWindows();
    }

    public class ConcreteHouse : HouseTemplate
    {
        protected override void BuildFoundation()
        {
            Console.WriteLine("Building foundation with cement, iron rods and sand");
        }

        protected override void BuildPillars()
        {
            Console.WriteLine("Building concrete pillars with cement and sand");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine("Building concrete walls");
        }

        protected override void BuildWindows()
        {
            Console.WriteLine("Building concrete windows");
        }
    }

    public class WoodenHouse : HouseTemplate
    {
        protected override void BuildFoundation()
        {
            Console.WriteLine("Building foundation with cement, iron rods and sand");
        }

        protected override void BuildPillars()
        {
            Console.WriteLine("Building wood pillars with wood coating");
        }

        protected override void BuildWalls()
        {
            Console.WriteLine("Building wood walls");
        }

        protected override void BuildWindows()
        {
            Console.WriteLine("Building wood windows");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building a concrete house\n");

            HouseTemplate houseTemplate = new ConcreteHouse();
            houseTemplate.BuildHouse();

            Console.WriteLine("Building a wooden house\n");

            houseTemplate = new WoodenHouse();
            houseTemplate.BuildHouse();
        }
    }
}
