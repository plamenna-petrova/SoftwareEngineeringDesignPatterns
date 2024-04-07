using MultipleExamples.CommunicationHub.Participants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CommunicationHub.Mediators
{
    public class BroadcastMediator : IMediator
    {
        public List<Participant> Participants { get; set; } = new List<Participant>();

        public void Notify(Participant sender, object senderArgs)
        {
            Participants.ForEach(p => p.Receive(sender, senderArgs));
        }
    }
}
