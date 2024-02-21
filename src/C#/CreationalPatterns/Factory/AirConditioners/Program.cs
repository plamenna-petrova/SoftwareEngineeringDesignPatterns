using System;
using System.Collections.Generic;

namespace AirConditioners
{
    public interface IAirConditioner
    {
        void Operate();
    }

    public class CoolingManger : IAirConditioner
    {
        private readonly double temperature;

        public CoolingManger(double temperature)
        {
            this.temperature = temperature;
        }

        public void Operate()
        {
            Console.WriteLine($"Cooling the room to the required temperature of {temperature} degrees");
        }
    }

    public class WarmingManager : IAirConditioner
    {
        private readonly double temperature;

        public WarmingManager(double temperature)
        {
            this.temperature = temperature;
        }

        public void Operate()
        {
            Console.WriteLine($"Warming the room to the required temperature of {temperature} degrees");
        }
    }

    public abstract class AirConditionerFactory
    {
        public abstract IAirConditioner CreateAirConditioner(double temperature);
    }

    public class CoolingFactory : AirConditionerFactory
    {
        public override IAirConditioner CreateAirConditioner(double temperature) => new CoolingManger(temperature);
    }

    public class WarmingFactory : AirConditionerFactory
    {
        public override IAirConditioner CreateAirConditioner(double temperature) => new WarmingManager(temperature);
    }

    public enum Action
    {
        Cooling,
        Warming
    }

    public class AirConditionersManager
    {
        private readonly Dictionary<Action, AirConditionerFactory> _airConditionerFactories;

        public AirConditionersManager()
        {
            _airConditionerFactories = new Dictionary<Action, AirConditionerFactory>();

            foreach (Action action in Enum.GetValues(typeof(Action)))
            {
                var airConditionerFactory = (AirConditionerFactory)Activator.CreateInstance(
                    Type.GetType($"AirConditioners.{Enum.GetName(typeof(Action), action)}Factory")
                );

                _airConditionerFactories.Add(action, airConditionerFactory);
            }
        }

        public IAirConditioner ExecuteCreation(Action action, double temperature)
            => _airConditionerFactories[action].CreateAirConditioner(temperature);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var airConditionersManager = new AirConditionersManager();

            var coolingAirConditioner = airConditionersManager.ExecuteCreation(Action.Cooling, 22.5);
            coolingAirConditioner.Operate();

            var warmingAirConditioner = airConditionersManager.ExecuteCreation(Action.Warming, 33.4);
            warmingAirConditioner.Operate();
        }
    }
}
