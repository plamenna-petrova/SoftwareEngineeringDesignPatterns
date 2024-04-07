using MultipleExamples.CommunicationHub.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleExamples.CommunicationHub.Mediators
{
    public class SensorCommandMediator : GroupMediator
    {
        public override void Notify(Participant sender, object senderArgs)
        {
            var groupsOfParticipant = Groups.Where(gr => gr.DoesParticipantExist(sender)).ToList();

            var receivers = groupsOfParticipant
                .SelectMany(gr => gr.Participants)
                .Where(p => p != sender)
                .Distinct()
                .ToList();

            if (senderArgs == "measure")
            {
                receivers = receivers.Where(r => !(r is User)).ToList();
            }
            else
            {
                receivers = receivers.Where(r => !(r is Sensor)).ToList();
            }

            receivers.ForEach(r => r.Receive(sender, senderArgs));
        }
    }
}
