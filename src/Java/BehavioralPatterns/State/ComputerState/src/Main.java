interface State {
    void pressPowerButton(Computer computer);
}

class OnState implements State {
    @Override
    public void pressPowerButton(Computer computer) {
        System.out.println("Computer is already on. Going to sleep mode...");
        computer.setState(new SleepState());
    }
}

class OffState implements State {
    @Override
    public void pressPowerButton(Computer computer) {
        System.out.println("Turning on computer...");
        computer.setState(new OnState());
    }
}

class SleepState implements State {
    @Override
    public void pressPowerButton(Computer computer) {
        System.out.println("Waking up computer from sleep mode...");
        computer.setState(new OnState());
    }
}

class Computer {
    private State currentState;

    public Computer() {
        currentState = new OffState();
    }

    public void pressPowerButton() {
        currentState.pressPowerButton(this);
    }

    public void setState(State state) {
        currentState = state;
    }
}

public class Main {
    public static void main(String[] args) {
        Computer computer = new Computer();

        for (int i = 0; i < 3; i++) {
            computer.pressPowerButton();
        }
    }
}