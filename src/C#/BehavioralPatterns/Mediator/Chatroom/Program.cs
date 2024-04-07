using System;
using System.Collections.Generic;

namespace Chatroom
{
    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);

        public abstract void SendMessage(string from, string to, string message);
    }

    public class Chatroom : AbstractChatroom
    {
        private readonly Dictionary<string, Participant> participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!participants.ContainsValue(participant))
            {
                participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void SendMessage(string from, string to, string message)
        {
            participants[to]?.ReceiveMessage(from, message);
        }
    }

    public class Participant
    {
        private readonly string name;

        private Chatroom chatroom;

        public Participant(string name)
        {
            this.name = name;
        }

        public string Name => name;

        public Chatroom Chatroom { get => chatroom; set => chatroom = value; }

        public void Send(string to, string message)
        {
            chatroom.SendMessage(name, to, message);
        }

        public virtual void ReceiveMessage(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, Name, message);
        }
    }

    public class Beatle : Participant
    {
        public Beatle(string name) : base(name)
        {

        }

        public override void ReceiveMessage(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.ReceiveMessage(from, message);
        }
    }

    public class NonBeatle : Participant
    {
        public NonBeatle(string name) : base(name)
        {

        }

        public override void ReceiveMessage(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.ReceiveMessage(from, message);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Chatroom chatroom = new Chatroom();

            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new Beatle("Yoko");

            List<Participant> participantsToRegisterInChatroom = new List<Participant>()
            {
                George,
                Paul,
                Ringo,
                John,
                Yoko
            };

            foreach (var participantToRegisterInChatroom in participantsToRegisterInChatroom)
            {
                chatroom.Register(participantToRegisterInChatroom);
            }

            Yoko.Send("John", "Hi, John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");
        }
    }
}
