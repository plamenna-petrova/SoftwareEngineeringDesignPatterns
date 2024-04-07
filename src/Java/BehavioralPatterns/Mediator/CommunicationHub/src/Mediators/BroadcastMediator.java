package Mediators;

import Participants.Participant;

import java.util.ArrayList;
import java.util.List;

public class BroadcastMediator implements IMediator {
    private List<Participant> participants;

    public BroadcastMediator() {
        this.participants = new ArrayList<>();
    }

    public void setParticipants(List<Participant> participants) {
        this.participants = participants;
    }

    @Override
    public void notify(Participant sender, Object senderArgs) {
        for (Participant participant : participants) {
            participant.receive(sender, senderArgs);
        }
    }
}
