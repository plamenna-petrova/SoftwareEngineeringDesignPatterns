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
        public abstract void Overrun(Scooter s);
    }

    public class MaxiScooter : Scooter
    {

    }

    public class SportsTourer : SportsBike
    {
        public override void Overrun(Scooter s)
        {
            Console.WriteLine($"{this.GetType().Name} overruns {s.GetType().Name}");
        }
    }

    public class VintageScooter : Scooter
    {

    }

    public class TrackMotorbike : SportsBike
    {
        public override void Overrun(Scooter s)
        {
            Console.WriteLine($"{this.GetType().Name} overruns {s.GetType().Name}");
        }
    }

    public class MotorcyclesClient
    {
        private Scooter scooter;
        private SportsBike sportsBike;

        public MotorcyclesClient(MotorcyclesFactory motorcyclesFactory)
        {
            scooter = motorcyclesFactory.CreateScooter();
            sportsBike = motorcyclesFactory.CreateSportsBike();
        }

        public void SetRace()
        {
            sportsBike.Overrun(scooter);
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
