using MultipleExamples.CommunicationHub.Participants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CommunicationHub.Mediators
{
    public class Group
    {
        public List<Participant> Participants { get; set; } = new List<Participant>();

        public bool DoesParticipantExist(Participant participant) => Participants.Contains(participant);
    }
}
