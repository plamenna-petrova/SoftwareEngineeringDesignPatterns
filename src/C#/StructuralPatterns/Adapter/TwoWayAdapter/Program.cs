using System;

namespace TwoWayAdapter
{
    public interface IAircraft
    {
        bool Airborne { get; }

        void TakeOff();

        int Height { get; }
    }

    public sealed class Aircraft : IAircraft
    {
        private int height;

        private bool airborne;

        public Aircraft()
        {
            height = 0;
            airborne = false;
        }

        public bool Airborne => airborne;

        public int Height => height;

        public void TakeOff()
        {
            Console.WriteLine("Aircraft engine takeoff");
            height = 200;
            airborne = true;
        }
    }

    public interface ISeacraft
    {
        int Speed { get; }

        void IncreaseRevs();
    }

    public class Seacraft : ISeacraft
    {
        int speed = 0;

        public virtual void IncreaseRevs()
        {
            speed += 10;
            Console.WriteLine("Seacraft engine increases reves to " + speed + " knots");
        }

        public virtual int Speed => speed;
    }

    public class Seabird : Seacraft, IAircraft
    {
        int height = 0;

        public int Height => height;

        public bool Airborne => height > 50;

        public void TakeOff()
        {
            while (!Airborne)
            {
                IncreaseRevs();
            }
        }

        public override void IncreaseRevs()
        {
            base.IncreaseRevs();

            if (Speed > 40)
            {
                height += 100;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Experiment 1: test the aircraft's engine");
            IAircraft aircraft = new Aircraft();
            aircraft.TakeOff();

            if (aircraft.Airborne)
            {
                Console.WriteLine("The aircraft engine is fine, flying at " + aircraft.Height + " meters");
            }

            Console.WriteLine("\nExperiment 2: Use the engine in the Seabird");
            IAircraft seabird = new Seabird();
            seabird.TakeOff();
            Console.WriteLine("The Seabird took off");

            Console.WriteLine("\nExperiment 3: Increase the speed of the Seabird:");
            (seabird as ISeacraft).IncreaseRevs();
            (seabird as ISeacraft).IncreaseRevs();

            if (seabird.Airborne)
            {
                Console.WriteLine($"Seabird flying at height " + seabird.Height + " meters and speed " + (seabird as ISeacraft).Speed);
            }

            Console.WriteLine("Experiment successful; the Seabird flies!");
        }
    }
}
