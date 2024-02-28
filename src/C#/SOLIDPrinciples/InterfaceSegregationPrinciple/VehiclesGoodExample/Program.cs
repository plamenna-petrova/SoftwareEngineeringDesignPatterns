using System;

namespace VehiclesGoodExample
{
    public interface ICar
    {
        void Drive();
    }

    public interface IAirplane
    {
        void Fly();
    }

    public interface IMultiFunctionalVehicle : ICar, IAirplane
    {

    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Driving a car");
        }
    }

    public class Airplane : IAirplane
    {
        public void Fly()
        {
            Console.WriteLine("Flying a plane");
        }
    }

    public class FuturisticCar : IMultiFunctionalVehicle
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
            ICar car = new Car();
            car.Drive();

            IAirplane airplane = new Airplane();
            airplane.Fly();

            IMultiFunctionalVehicle futuristicCar = new FuturisticCar();
            futuristicCar.Drive();
            futuristicCar.Fly();
        }
    }
}
