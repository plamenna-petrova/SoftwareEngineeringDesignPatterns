package Mediators;

import Participants.Participant;
import Participants.Sensor;
import Participants.User;

import java.util.List;
import java.util.stream.Collectors;

public class SensorCommandMediator extends GroupMediator {
    @Override
    public void notify(Participant sender, Object senderArgs) {
        List<Group> groupsOfParticipant = getGroups().stream()
                .filter(group -> group.doesParticipantExist(sender))
                .collect(Collectors.toList());

        List<Participant> receivers = groupsOfParticipant.stream()
                .flatMap(group -> group.getParticipants().stream())
                .filter(p -> p != sender)
                .distinct()
                .collect(Collectors.toList());

        if (senderArgs.equals("measure")) {
            receivers = receivers.stream().filter(r -> !(r instanceof User)).collect(Collectors.toList());
        } else {
            receivers = receivers.stream().filter(r -> !(r instanceof Sensor)).collect(Collectors.toList());
        }

        receivers.forEach(r -> r.receive(sender, senderArgs));
    }
}
