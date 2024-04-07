using CommunicationHub.Mediators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationHub.Participants
{
    public abstract class Participant
    {
        public IMediator Mediator { get; set; }

        public abstract void Receive(Participant sender, object args);
    }
}
