using System;

namespace StructuralCode
{
    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    public abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {

        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    public class Invoker
    {
        private Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command?.Execute();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }
}
