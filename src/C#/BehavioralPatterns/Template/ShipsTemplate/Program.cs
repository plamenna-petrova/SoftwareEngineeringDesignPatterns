using System;

namespace ShipsTemplate
{
    public abstract class MedievalShipTemplate
    {
        public void BuildMedievalShip()
        {
            BuildFoundation();
            BuildHull();
            BuildDeck();
            BuIldMasts();
            BuildCabins();
            BuildExteriorDetails();
            Console.WriteLine("The ship is built.");
        }

        protected abstract void BuildFoundation();

        protected abstract void BuildHull();

        protected abstract void BuildDeck();

        protected abstract void BuIldMasts();

        protected abstract void BuildCabins();

        protected abstract void BuildExteriorDetails();
    }

    public class Cog : MedievalShipTemplate
    {
        protected override void BuildFoundation()
        {
            Console.WriteLine("Building foundation with oak");
        }

        protected override void BuildHull()
        {
            Console.WriteLine("Building a double-ended hull");
        }

        protected override void BuildDeck()
        {
            Console.WriteLine("Building a small deck");
        }

        protected override void BuIldMasts()
        {
            Console.WriteLine("Building one mast");
        }

        protected override void BuildCabins()
        {
            Console.WriteLine("Building four cabins");
        }

        protected override void BuildExteriorDetails()
        {
            Console.WriteLine("Building a rear tower");
        }
    }

    public class Caravel : MedievalShipTemplate
    {
        protected override void BuildFoundation()
        {
            Console.WriteLine("Building foundation, using carvel method of construction");
        }

        protected override void BuildHull()
        {
            Console.WriteLine("Building a lateen rigged hull");
        }

        protected override void BuildDeck()
        {
            Console.WriteLine("Building a large deck");
        }

        protected override void BuIldMasts()
        {
            Console.WriteLine("Building three masts");
        }

        protected override void BuildCabins()
        {
            Console.WriteLine("Building eight cabins");
        }

        protected override void BuildExteriorDetails()
        {
            Console.WriteLine("Building templar flags ornaments");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building the medieval ship cog");

            MedievalShipTemplate medievalShipTemplate = new Cog();
            medievalShipTemplate.BuildMedievalShip();

            Console.WriteLine();

            Console.WriteLine("Building the medieval ship caravel");
            medievalShipTemplate = new Caravel();
            medievalShipTemplate.BuildMedievalShip();
        }
    }
}
