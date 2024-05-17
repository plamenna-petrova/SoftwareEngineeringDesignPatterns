using System;
using System.Collections.Generic;
using System.Threading;

namespace MediatorExplanatoryCode
{
    public interface IMediator
    {
        void RegisterColleague(Colleague colleague);

        void SendMessageToColleague(string from, string to, string message);
    }

    public class ConcreteMediator : IMediator
    {
        private readonly Dictionary<string, Colleague> participatingColleagues = new Dictionary<string, Colleague>();

        public void RegisterColleague(Colleague colleague)
        {
            if (!participatingColleagues.ContainsValue(colleague))
            {
                participatingColleagues[colleague.Name] = colleague;
            }

            colleague.Mediator = this;
        }

        public void SendMessageToColleague(string from, string to, string message)
        {
            participatingColleagues[to].ReceiveMessage(from, message);
        }
    }

    public abstract class Colleague
    {
        public Colleague(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public IMediator Mediator { get; set; }

        public void SendMessage(string to, string message)
        {
            Mediator.SendMessageToColleague(Name, to, message);
        }

        public virtual void ReceiveMessage(string from, string message)
        {
            Console.WriteLine($"{Name} получава съобщение от {from} с текст \"{message}\"");
        }
    }

    public class FirstConcreteColleague : Colleague
    {
        public FirstConcreteColleague(string name) : base(name)
        {

        }

        public override void ReceiveMessage(string from, string message)
        {
            Console.Write("До участник от тип Колега 1: ");
            base.ReceiveMessage(from, message);
        }
    }

    public class SecondConcreteColleague : Colleague
    {
        public SecondConcreteColleague(string name) : base(name)
        {

        }

        public override void ReceiveMessage(string from, string message)
        {
            Console.Write("До участник от тип Колега 2: ");
            base.ReceiveMessage(from, message);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            IMediator mediator = new ConcreteMediator();

            Colleague exampleOfFirstConcreteColleague = new FirstConcreteColleague("Иван Георгиев");
            Colleague anotherExampleOfFirstConcreteColleague = new FirstConcreteColleague("Стефан Петров");
            Colleague exampleOfSecondConcreteColleague = new SecondConcreteColleague("Георги Христов");

            List<Colleague> colleaguesToAddToMediator = new List<Colleague>()
            {
                exampleOfFirstConcreteColleague,
                anotherExampleOfFirstConcreteColleague,
                exampleOfSecondConcreteColleague
            };

            foreach (var colleagueToAddToMediator in colleaguesToAddToMediator)
            {
                mediator.RegisterColleague(colleagueToAddToMediator);
            }

            exampleOfFirstConcreteColleague.SendMessage("Стефан Петров", "Примерно съобщение");
            Thread.Sleep(5000);
            anotherExampleOfFirstConcreteColleague.SendMessage("Георги Христов", "Друго примерно съобщение");
        }
    }
}
