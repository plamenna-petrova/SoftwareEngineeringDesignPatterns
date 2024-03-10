using System;

namespace Cars
{
    public interface ICar
    {
        ICar Manufacture();
    }

    public class BMW : ICar
    {
        public string Body { get; set; }

        public string Doors { get; set; }

        public string Wheels { get; set; }

        public string Glass { get; set; }

        public string Engine { get; set; }

        public ICar Manufacture()
        {
            Body = "carbon fiber material";
            Doors = "4 car doors";
            Wheels = "4 MRF wheels";
            Glass = "6 car glasses";
            return this;
        }

        public override string ToString()
        {
            string bmwCarDetails = $"{GetType().Name} [Name = {GetType().Name}], Body = {Body}, Doors = {Doors}, " +
                $"Wheels: {Wheels}, Glass: {Glass}, Engine: {Engine ?? "n/a"}";

            return bmwCarDetails;
        }
    }

    public abstract class CarDecorator : ICar
    {
        protected ICar car;

        public CarDecorator(ICar car)
        {
            this.car = car;            
        }

        public virtual ICar Manufacture() => car.Manufacture();
    }

    public class DieselCarConcreteDecorator : CarDecorator
    {
        public DieselCarConcreteDecorator(ICar car) : base(car)
        {
                
        }

        public override ICar Manufacture()
        {
            base.Manufacture();
            AddEngine(car);
            return car;
        }

        public void AddEngine(ICar car)
        {
            if (car is BMW bmw)
            {
                bmw.Engine = "Diesel Engine";
                Console.WriteLine($"Added Diesel Engine to the Car: {car}");
            }
        }
    }

    public class PetrolCarConcreteDecorator : CarDecorator
    {
        public PetrolCarConcreteDecorator(ICar car) : base(car)
        {
                
        }

        public override ICar Manufacture()
        {
            base.Manufacture();
            AddEngine(car);
            return car;
        }

        public void AddEngine(ICar car)
        {
            if (car is BMW bmw)
            {
                bmw.Engine = "Petrol Engine";
                Console.WriteLine($"Added Petrol Engine to the Car: {car}");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ICar bmwX7 = new BMW();
            bmwX7.Manufacture();
            Console.WriteLine(bmwX7);

            Console.WriteLine();

            DieselCarConcreteDecorator dieselCarConcreteDecorator = new DieselCarConcreteDecorator(bmwX7);
            dieselCarConcreteDecorator.Manufacture();

            Console.WriteLine();

            ICar bmwX5 = new BMW();

            PetrolCarConcreteDecorator petrolCarConcreteDecorator = new PetrolCarConcreteDecorator(bmwX5);
            petrolCarConcreteDecorator.Manufacture();
        }
    }
}
