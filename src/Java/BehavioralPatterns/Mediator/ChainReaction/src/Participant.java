public abstract class Participant {
    protected Mediator mediator;

    protected Participant(Mediator mediator) {
        this.mediator = mediator;
    }

    protected Mediator getMediator() {
        return mediator;
    }
}