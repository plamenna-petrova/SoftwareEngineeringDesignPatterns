using System;

namespace Motorcycles
{
    public abstract class MotorcyclesFactory
    {
        public abstract Scooter CreateScooter();

        public abstract SportsBike CreateSportsBike();
    }

    public class HondaFactory : MotorcyclesFactory
    {
        public override Scooter CreateScooter()
        {
            return new MaxiScooter();
        }

        public override SportsBike CreateSportsBike()
        {
            return new SportsTourer();
        }
    }

    public class YamahaFactory : MotorcyclesFactory
    {
        public override Scooter CreateScooter()
        {
            return new VintageScooter();
        }

        public override SportsBike CreateSportsBike()
        {
            return new TrackMotorbike();
        }
    }

    public abstract class Scooter
    {

    }

    public abstract class SportsBike
    {
        public abstract void Overrun(Scooter scooter);
    }

    public class MaxiScooter : Scooter
    {

    }

    public class SportsTourer : SportsBike
    {
        public override void Overrun(Scooter scooter)
        {
            Console.WriteLine($"{GetType().Name} overruns {scooter.GetType().Name}");
        }
    }

    public class VintageScooter : Scooter
    {

    }

    public class TrackMotorbike : SportsBike
    {
        public override void Overrun(Scooter scooter)
        {
            Console.WriteLine($"{GetType().Name} overruns {scooter.GetType().Name}");
        }
    }

    public class MotorcyclesClient
    {
        private Scooter _scooter;

        private SportsBike _sportsBike;

        public MotorcyclesClient(MotorcyclesFactory motorcyclesFactory)
        {
            _scooter = motorcyclesFactory.CreateScooter();
            _sportsBike = motorcyclesFactory.CreateSportsBike();
        }

        public void SetRace()
        {
            _sportsBike.Overrun(_scooter);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MotorcyclesFactory hondaFactory = new HondaFactory();
            MotorcyclesClient motorcyclesClient = new MotorcyclesClient(hondaFactory);
            motorcyclesClient.SetRace();

            MotorcyclesFactory yamahaFactory = new YamahaFactory();
            motorcyclesClient = new MotorcyclesClient(yamahaFactory);
            motorcyclesClient.SetRace();
        }
    }
}