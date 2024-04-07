using MultipleExamples.CommunicationHub.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleExamples.CommunicationHub.Mediators
{
    public class GroupMediator : IMediator
    {
        public List<Group> Groups { get; set; } = new List<Group>();

        public virtual void Notify(Participant sender, object senderArgs)
        {
            var groupsOfParticipant = Groups.Where(gr => gr.DoesParticipantExist(sender)).ToList();

            var receivers = groupsOfParticipant
                .SelectMany(gr => gr.Participants)
                .Where(p => p != sender)
                .Distinct()
                .ToList();

            receivers.ForEach(r => r.Receive(sender, senderArgs));
        }
    }
}
