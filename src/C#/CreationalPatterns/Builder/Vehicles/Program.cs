using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class Vehicle
    {
        private string vehicleType;

        private Dictionary<string, string> parts = new Dictionary<string, string>();

        public Vehicle(string vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        public string this[string key]
        {
            get => parts[key];
            set => parts[key] = value;
        }

        public void Show()
        {
            Console.WriteLine("\n" + new string('-', 25));
            Console.WriteLine($"Vehicle Type: {vehicleType}");
            Console.WriteLine($" Frame : {this["frame"]}");
            Console.WriteLine($" Engine : {this["engine"]}");
            Console.WriteLine($" #Wheels: {this["wheels"]}");
            Console.WriteLine($" #Doors: {this["doors"]}");
        }
    }

    public abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; set; }

        public abstract void BuildFrame();

        public abstract void BuildEngine();

        public abstract void BuildWheels();

        public abstract void BuildDoors();
    }

    public class MotorcycleBuilder : VehicleBuilder
    {
        public MotorcycleBuilder()
        {
            Vehicle = new Vehicle("MotorCycle");
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Motorcycle Frame";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "500 cc";
        }

        public override void BuildWheels()
        {
            Vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle["doors"] = "0";
        }
    }

    public class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            Vehicle = new Vehicle("Car");
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels()
        {
            Vehicle["wheels"] = "4";
        }

        public override void BuildDoors()
        {
            Vehicle["doors"] = "4";
        }
    }

    public class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            Vehicle = new Vehicle("Scooter");
        }

        public override void BuildFrame()
        {
            Vehicle["frame"] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            Vehicle["engine"] = "50 cc";
        }

        public override void BuildWheels()
        {
            Vehicle["wheels"] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle["doors"] = "0";
        }
    }

    public class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            VehicleBuilder vehicleBuilder = new ScooterBuilder();

            shop.Construct(vehicleBuilder);
            vehicleBuilder.Vehicle.Show();

            vehicleBuilder = new CarBuilder();
            shop.Construct(vehicleBuilder);
            vehicleBuilder.Vehicle.Show();

            vehicleBuilder = new MotorcycleBuilder();
            shop.Construct(vehicleBuilder);
            vehicleBuilder.Vehicle.Show();

            Console.ReadKey();
        }
    }
}
