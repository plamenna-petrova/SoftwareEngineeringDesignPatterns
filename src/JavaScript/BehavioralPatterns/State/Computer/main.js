
class State {
    pressPowerButton(computer) {
        throw new Error("Method 'pressPowerButton' must be implemented.");
    }
}

class OnState extends State {
    pressPowerButton(computer) {
        console.log("Computer is already on. Going to sleep mode...");
        computer.setState(new SleepState());
    }
}

class OffState extends State {
    pressPowerButton(computer) {
        console.log("Turning on computer...");
        computer.setState(new OnState());
    }
}

class SleepState extends State {
    pressPowerButton(computer) {
        console.log("Waking up computer from sleep mode...");
        computer.setState(new OnState());
    }
}

class Computer {
    constructor() {
        this.currentState = new OffState();
    }

    pressPowerButton() {
        this.currentState.pressPowerButton(this);
    }

    setState(state) {
        this.currentState = state;
    }
}

const computer = new Computer();

for (let i = 0; i < 3; i++) {
    computer.pressPowerButton();
}