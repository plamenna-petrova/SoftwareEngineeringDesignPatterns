package Mediators;

import Participants.Participant;

public interface IMediator {
    void notify(Participant sender, Object senderArgs);
}

