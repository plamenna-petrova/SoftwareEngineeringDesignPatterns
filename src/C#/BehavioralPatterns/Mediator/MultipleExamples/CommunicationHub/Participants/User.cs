using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CommunicationHub.Participants
{
    public class User : Participant
    {
        public User(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override void Receive(Participant sender, object args)
        {
            if (args is List<object> listOfObjectsArgs)
            {
                Console.WriteLine($"User:{this}, received from: {sender}, message: {listOfObjectsArgs[1]}");
            }
            else
            {
                Console.WriteLine($"User:{this}, received from: {sender}, message: {args}");
            }
        }

        public void Send(Participant receiver, object args)
        {
            Mediator.Notify(this, new List<object>() { receiver, args });
        }

        public override string ToString() => Name;
    }
}
