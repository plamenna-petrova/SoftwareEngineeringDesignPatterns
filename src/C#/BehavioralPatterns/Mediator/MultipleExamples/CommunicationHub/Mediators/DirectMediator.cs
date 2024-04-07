using MultipleExamples.CommunicationHub.Participants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CommunicationHub.Mediators
{
    public class DirectMediator : IMediator
    {
        public void Notify(Participant sender, object senderArgs)
        {
            if (!(senderArgs is List<object> argsList))
            {
                return;
            }

            if (!(argsList[0] is Participant receiver))
            {
                return;
            }

            receiver.Receive(sender, argsList[1]);
        }
    }
}
