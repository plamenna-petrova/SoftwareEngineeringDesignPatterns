package Mediators;

import Participants.Participant;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

public class GroupMediator implements IMediator {
    private List<Group> groups = new ArrayList<>();

    public void notify(Participant sender, Object senderArgs) {
        List<Participant> receivers = groups.stream()
                .filter(group -> group.doesParticipantExist(sender))
                .flatMap(group -> group.getParticipants().stream())
                .filter(p -> p != sender)
                .distinct()
                .collect(Collectors.toList());

        receivers.forEach(r -> r.receive(sender, senderArgs));
    }

    public List<Group> getGroups() {
        return groups;
    }

    public void setGroups(List<Group> groups) {
        this.groups = groups;
    }
}
