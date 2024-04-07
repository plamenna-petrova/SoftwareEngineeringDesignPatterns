using System;

namespace StructuralCode
{
    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    public class ConcreteMediator : Mediator
    {
        private FirstConcreteColleague firstConcreteColleague;

        private SecondConcreteColleague secondConcreteColleague;

        public FirstConcreteColleague FirstConcreteColleague
        {
            set => firstConcreteColleague = value;
        }

        public SecondConcreteColleague SecondConcreteColleague
        {
            set => secondConcreteColleague = value;
        }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == firstConcreteColleague)
            {
                secondConcreteColleague.GetNotification(message);
            }
            else
            {
                firstConcreteColleague.GetNotification(message);
            }
        }
    }

    public abstract class Colleague
    {
        protected Mediator mediator;

        protected Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    public class FirstConcreteColleague : Colleague
    {
        public FirstConcreteColleague(Mediator mediator)
            : base(mediator)
        {

        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void GetNotification(string message)
        {
            Console.WriteLine("Colleague #1 gets message: " + message);
        }
    }

    public class SecondConcreteColleague : Colleague
    {
        public SecondConcreteColleague(Mediator mediator)
            : base(mediator)
        {

        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void GetNotification(string message)
        {
            Console.WriteLine("Colleague #2 gets message: " + message);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ConcreteMediator concreteMediator = new ConcreteMediator();

            FirstConcreteColleague firstConcreteColleague = new FirstConcreteColleague(concreteMediator);
            SecondConcreteColleague secondConcreteColleague = new SecondConcreteColleague(concreteMediator);

            concreteMediator.FirstConcreteColleague = firstConcreteColleague;
            concreteMediator.SecondConcreteColleague = secondConcreteColleague;

            firstConcreteColleague.Send("How are you?");
            secondConcreteColleague.Send("Fine, thanks");
        }
    }
}
