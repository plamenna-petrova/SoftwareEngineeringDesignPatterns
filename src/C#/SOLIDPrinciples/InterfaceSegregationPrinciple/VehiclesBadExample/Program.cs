using System;

namespace VehiclesBadExample
{
    public interface IVehicle
    {
        void Drive();

        void Fly();
    }

    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving a car");
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }
    }

    public class Airplane : IVehicle
    {
        public void Drive()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            Console.WriteLine("Flying a plane");
        }
    }

    public class FuturisticCar : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving a futuristic car");
        }

        public void Fly()
        {
            Console.WriteLine("Flying a futuristic car");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IVehicle car = new Car();
                car.Drive();
                car.Fly();

                IVehicle airplane = new Airplane();
                //airplane.Drive();
                airplane.Fly();

                IVehicle futuristicCar = new FuturisticCar();
                futuristicCar.Drive();
                futuristicCar.Fly();
            }
            catch (Exception exception) 
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
