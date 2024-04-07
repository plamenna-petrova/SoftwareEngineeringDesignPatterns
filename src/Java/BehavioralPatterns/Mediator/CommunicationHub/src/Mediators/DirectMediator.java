package Mediators;

import Participants.Participant;

import java.util.List;

public class DirectMediator implements IMediator {
    @Override
    public void notify(Participant sender, Object senderArgs) {
        if (!(senderArgs instanceof List<?>)) {
            return;
        }

        List<?> argsList = (List<?>) senderArgs;

        if (argsList.size() < 2 || !(argsList.get(0) instanceof Participant)) {
            return;
        }

        Participant receiver = (Participant) argsList.get(0);
        receiver.receive(sender, argsList.get(1));
    }
}