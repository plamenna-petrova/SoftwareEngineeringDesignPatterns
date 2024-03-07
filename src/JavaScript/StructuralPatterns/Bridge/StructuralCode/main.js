
class Abstraction {
    constructor() {
        this._implementor = null;
    }

    set implementor(value) {
        this._implementor = value;
    }

    executeOperation() {
        this._implementor.executeOperation();
    }
}

class Implementor {
    executeOperation() {
        // To be implemented by concrete implementations
    }
}

class RefinedAbstraction extends Abstraction {
    executeOperation() {
        this._implementor.executeOperation();
    }
}

class ConcreteImplementorA extends Implementor {
    executeOperation() {
        console.log(`${this.constructor.name} Operation`);
    }
}

class ConcreteImplementorB extends Implementor {
    executeOperation() {
        console.log(`${this.constructor.name} Operation`);
    }
}

const abstraction = new RefinedAbstraction();

abstraction.implementor = new ConcreteImplementorA();
abstraction.executeOperation();

abstraction.implementor = new ConcreteImplementorB();
abstraction.executeOperation();