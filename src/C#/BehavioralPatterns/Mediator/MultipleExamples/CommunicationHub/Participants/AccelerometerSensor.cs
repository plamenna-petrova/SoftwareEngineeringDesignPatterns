using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CommunicationHub.Participants
{
    public class AccelerometerSensor : Sensor
    {
        public AccelerometerSensor() : base("acceleration")
        {

        }

        public override void Receive(Participant sender, object args)
        {
            if (args == "measure")
            {
                LastValue = new Random().NextDouble();
                Mediator.Notify(this, "measure");
                Mediator.Notify(this, LastValue);
            }
        }

        public override void ValueChanged(object value)
        {
            LastValue = value;
            Mediator.Notify(this, "measure");
            Mediator.Notify(this, LastValue);
        }
    }
}
