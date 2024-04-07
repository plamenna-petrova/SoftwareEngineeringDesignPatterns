using System;
using System.Collections.Generic;

namespace FacebookGroupMediator
{
    public interface IFacebookGroupMediator
    {
        void SendMessage(string message, User user);

        void RegisterUser(User user);
    }

    public class ConcreteFacebookGroupMediator : IFacebookGroupMediator
    {
        private readonly List<User> usersInFacebookGroup = new List<User>();

        public void RegisterUser(User user)
        {
            usersInFacebookGroup.Add(user);
            user.FacebookGroupMediator = this;
        }

        public void SendMessage(string message, User user)
        {
            foreach (User userInFacebookGroup in usersInFacebookGroup)
            {
                if (userInFacebookGroup != user)
                {
                    userInFacebookGroup.ReceiveMessage(message);
                }
            }
        }
    }

    public abstract class User
    {
        protected string name;

        public User(string name)
        {
            this.name = name;
        }

        public string Name => name;

        public IFacebookGroupMediator FacebookGroupMediator { get; set; }

        public abstract void SendMessage(string message);

        public abstract void ReceiveMessage(string message);
    }

    public class ConcreteUser : User
    {
        public ConcreteUser(string name) : base(name)
        {

        }

        public override void SendMessage(string message)
        {
            Console.WriteLine($"{Name} sending message {message}\n");
            FacebookGroupMediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} received message: {message}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            IFacebookGroupMediator facebookGroupMediator = new ConcreteFacebookGroupMediator();

            User John = new ConcreteUser("John");
            User David = new ConcreteUser("David");
            User Sam = new ConcreteUser("Sam");
            User Richard = new ConcreteUser("Richard");
            User Lisa = new ConcreteUser("Lisa");
            User Jodie = new ConcreteUser("Jodie");
            User William = new ConcreteUser("William");
            User Harry = new ConcreteUser("Harry");

            List<User> usersToRegisterInFacebookGroup = new List<User>()
            {
                John,
                David,
                Sam,
                Richard,
                Lisa,
                Jodie,
                William,
                Harry
            };

            foreach (var userToRegisterInFacebookGroup in usersToRegisterInFacebookGroup)
            {
                facebookGroupMediator.RegisterUser(userToRegisterInFacebookGroup);
            }

            David.SendMessage("Good place to learn Design Patterns");
            Console.WriteLine();
            William.SendMessage("Dofactory");
        }
    }
}
