package Mediators;

import Participants.Participant;

import java.util.ArrayList;
import java.util.List;

public class Group {
    private List<Participant> participants = new ArrayList<>();

    public boolean doesParticipantExist(Participant participant) {
        return participants.contains(participant);
    }

    public List<Participant> getParticipants() {
        return participants;
    }

    public void setParticipants(List<Participant> participants) {
        this.participants = participants;
    }
}
