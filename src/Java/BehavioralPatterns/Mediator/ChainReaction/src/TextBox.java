public class TextBox extends Participant {
    private boolean isEnabled = false;

    public TextBox(Mediator mediator) {
        super(mediator);
    }

    public boolean isEnabled() {
        return isEnabled;
    }

    public void enable() {
        isEnabled = true;
        System.out.println("TextBox is enabled.");
        getMediator().onStateChanged(this);
    }

    public void disable() {
        isEnabled = false;
        System.out.println("TextBox is disabled.");
        getMediator().onStateChanged(this);
    }
}
