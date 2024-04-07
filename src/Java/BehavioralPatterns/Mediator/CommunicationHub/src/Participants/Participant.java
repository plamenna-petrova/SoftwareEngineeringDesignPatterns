package Participants;

import Mediators.IMediator;

public abstract class Participant {
    protected IMediator mediator;

    public IMediator getMediator() {
        return mediator;
    }

    public void setMediator(IMediator mediator) {
        this.mediator = mediator;
    }

    public abstract void receive(Participant sender, Object args);
}

