abstract class State {
    abstract void handle(Context context);
}

class ConcreteStateA extends State {
    @Override
    void handle(Context context) {
        context.setState(new ConcreteStateB());
    }
}

class ConcreteStateB extends State {
    @Override
    void handle(Context context) {
        context.setState(new ConcreteStateA());
    }
}

class Context {
    private State state;

    Context(State state) {
        setState(state);
    }

    State getState() {
        return state;
    }

    void setState(State state) {
        this.state = state;
        System.out.println("State: " + state.getClass().getSimpleName());
    }

    void request() {
        state.handle(this);
    }
}

public class Main {
    public static void main(String[] args) {
        Context context = new Context(new ConcreteStateA());

        for (int i = 0; i < 4; i++) {
            context.request();
        }
    }
}