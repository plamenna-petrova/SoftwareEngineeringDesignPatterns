using System;

namespace ComputerState
{
    public interface State
    {
        void PressPowerButton(Computer computer);
    }

    public class OnState : State
    {
        public void PressPowerButton(Computer computer)
        {
            Console.WriteLine("Computer is already on. Going to sleep mode...");
            computer.SetState(new SleepState());
        }
    }

    public class OffState : State
    {
        public void PressPowerButton(Computer computer)
        {
            Console.WriteLine("Turning on computer...");
            computer.SetState(new OnState());
        }
    }

    public class SleepState : State
    {
        public void PressPowerButton(Computer computer)
        {
            Console.WriteLine("Waking up computer from sleep mode...");
            computer.SetState(new OnState());
        }
    }

    public class Computer
    {
        private State currentState;

        public Computer()
        {
            currentState = new OffState();
        }

        public void PressPowerButton()
        {
            currentState.PressPowerButton(this);
        }

        public void SetState(State state)
        {
            currentState = state;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();

            for (int i = 0; i < 3; i++)
            {
                computer.PressPowerButton();
            }
        }
    }
}
