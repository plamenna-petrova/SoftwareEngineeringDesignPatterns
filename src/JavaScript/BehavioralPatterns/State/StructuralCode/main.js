
class State {
    handle(context) {
        throw new Error("This method must be overridden");
    }
}

class ConcreteStateA extends State {
    handle(context) {
        context.state = new ConcreteStateB();
    }
}

class ConcreteStateB extends State {
    handle(context) {
        context.state = new ConcreteStateA();
    }
}

class Context {
    constructor(state) {
        this.state = state;
    }

    get state() {
        return this._state;
    }

    set state(newState) {
        this._state = newState;
        console.log(`State: ${this._state.constructor.name}`);
    }

    request() {
        this.state.handle(this);
    }
}

const context = new Context(new ConcreteStateA());

for (let i = 0; i < 4; i++) {
    context.request();
}