using System;
using System.Collections.Generic;
using System.Text;

namespace ChainReaction
{
    public class Button : Participant
    {
        public Button(Mediator mediator) : base(mediator)
        {

        }

        public void Enable() => Console.WriteLine("Button is enabled.");

        public void Disable() => Console.WriteLine("Button is disabled.");
    }
}
