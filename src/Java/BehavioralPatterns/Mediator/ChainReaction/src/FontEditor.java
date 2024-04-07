public class FontEditor extends Participant {
    public FontEditor(Mediator mediator) {
        super(mediator);
    }

    public void enable() {
        System.out.println("FontEditor is enabled.");
    }

    public void disable() {
        System.out.println("FontEditor is disabled.");
    }
}