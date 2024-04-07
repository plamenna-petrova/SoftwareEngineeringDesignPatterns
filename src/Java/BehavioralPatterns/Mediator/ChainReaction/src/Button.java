public class Button extends Participant {
    public Button(Mediator mediator) {
        super(mediator);
    }

    public void enable() {
        System.out.println("Button is enabled.");
    }

    public void disable() {
        System.out.println("Button is disabled.");
    }
}

