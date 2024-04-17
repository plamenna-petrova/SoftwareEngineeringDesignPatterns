
class Memento {
    constructor(state) {
        this.state = state;
    }

    getState() {
        return this.state;
    }
}

class Originator {
    constructor() {
        this.state = '';
    }

    getState() {
        return this.state;
    }

    setState(state) {
        this.state = state;
        console.log("State = " + this.state);
    }

    createMemento() {
        return new Memento(this.state);
    }

    setMemento(memento) {
        console.log("Restoring state...");
        this.setState(memento.getState());
    }
}

class Caretaker {
    constructor() {
        this.memento = null;
    }

    getMemento() {
        return this.memento;
    }

    setMemento(memento) {
        this.memento = memento;
    }
}

const originator = new Originator();
originator.setState("On");

const caretaker = new Caretaker();
caretaker.setMemento(originator.createMemento());

originator.setState("Off");

originator.setMemento(caretaker.getMemento());