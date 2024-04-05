using System;
using System.Collections.Generic;

namespace LightsSwitch
{
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is off");
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class FlipUpCommand : ICommand
    {
        private readonly Light light;

        public FlipUpCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
    }

    public class FlipDownCommand : ICommand
    {
        private readonly Light light;

        public FlipDownCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
        }
    }

    public class Switch
    {
        private readonly List<ICommand> commands = new List<ICommand>();

        public void StoreAndExecute(ICommand command)
        {
            commands.Add(command);
            command.Execute();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter commands (ON/OFF) : ");

            string command = Console.ReadLine();

            Light lamp = new Light();

            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);

            Switch @switch = new Switch();

            if (command == "ON")
            {
                @switch.StoreAndExecute(switchUp);
            }
            else if (command == "OFF")
            {
                @switch.StoreAndExecute(switchDown);
            }
            else
            {
                Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
            }
        }
    }
}
