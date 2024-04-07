using MultipleExamples.CommunicationHub.Participants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CommunicationHub.Mediators
{
    public interface IMediator
    {
        void Notify(Participant sender, object senderArgs);
    }
}
