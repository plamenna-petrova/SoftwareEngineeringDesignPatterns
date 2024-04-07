using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CommunicationHub.Participants
{
    public class Sensor : Participant
    {
        public Sensor(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }

        public object LastValue { get; protected set; }

        public override void Receive(Participant sender, object args)
        {
            if (args == "measure")
            {
                LastValue = new Random().NextDouble();
                Mediator.Notify(this, LastValue);
            }
        }

        public virtual void ValueChanged(object value)
        {
            LastValue = value;
            Mediator.Notify(this, LastValue);
        }

        public override string ToString() => $"Sensor({Id})";
    }
}
