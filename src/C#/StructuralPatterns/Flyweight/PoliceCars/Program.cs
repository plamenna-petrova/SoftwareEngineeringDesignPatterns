using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace PoliceCars
{
    public class CarFlyweight
    {
        private Car carSharedState;

        public CarFlyweight(Car car)
        {
            carSharedState = car;
        }

        public void Operation(Car car)
        {
            string serializedSharedCarStateJSONString = JsonConvert.SerializeObject(carSharedState, Formatting.Indented);
            string serializedUniqueCarStateJSONString = JsonConvert.SerializeObject(car, Formatting.Indented);
            Console.WriteLine($"Flyweight - displaying shared state: {serializedSharedCarStateJSONString} " +
                $"and unique state: {serializedUniqueCarStateJSONString} state.");
        }
    }

    public class CarFlyweightFactory
    {
        private readonly List<Tuple<CarFlyweight, string>> carFlyweights = new List<Tuple<CarFlyweight, string>>();

        public CarFlyweightFactory(params Car[] cars)
        {
            foreach (var car in cars)
            {
                carFlyweights.Add(new Tuple<CarFlyweight, string>(new CarFlyweight(car), GetCarKey(car)));
            }
        }

        public CarFlyweight GetFlyweight(Car carSharedState)
        {
            string carKey = GetCarKey(carSharedState);

            if (carFlyweights.Where(cf => cf.Item2 == carKey).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                carFlyweights.Add(new Tuple<CarFlyweight, string>(new CarFlyweight(carSharedState), carKey));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }

            return carFlyweights.Where(cf => cf.Item2 == carKey).FirstOrDefault().Item1;
        }

        public void ListFlyweights()
        {
            var carFlyweightsCount = carFlyweights.Count;

            Console.WriteLine($"\nFlyweightFactory: Car flyweights count: {carFlyweightsCount}");

            foreach (var carFlyweight in carFlyweights)
            {
                Console.WriteLine(carFlyweight.Item2);
            }
        }

        public string GetCarKey(Car car)
        {
            List<string> carCharacteristics = new List<string>
            {
                car.Model,
                car.Color,
                car.Company
            };

            if (car.Owner != null && car.Number != null)
            {
                carCharacteristics.Add(car.Number);
                carCharacteristics.Add(car.Owner);
            }

            carCharacteristics.Sort();

            return string.Join("_", carCharacteristics);
        }
    }

    public class Car
    {
        public string Owner { get; set; }

        public string Number { get; set; }

        public string Company { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var carFlyweightFactory = new CarFlyweightFactory(
                new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new Car { Company = "BMW", Model = "M5", Color = "red" },
                new Car { Company = "BMW", Model = "X6", Color = "white" }
            );

            carFlyweightFactory.ListFlyweights();

            AddCarToPoliceDatabase(carFlyweightFactory, new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            });

            AddCarToPoliceDatabase(carFlyweightFactory, new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            });

            carFlyweightFactory.ListFlyweights();
        }

        private static void AddCarToPoliceDatabase(CarFlyweightFactory carFlyweightFactory, Car car)
        {
            Console.WriteLine("\nClient: Adding a car to the police database.");

            var carFlyweight = carFlyweightFactory.GetFlyweight(new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            carFlyweight.Operation(car);
        }
    }
}
