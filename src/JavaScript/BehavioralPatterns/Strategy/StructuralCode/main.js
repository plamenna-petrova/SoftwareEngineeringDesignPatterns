
class Strategy {
    AlgorithmInterface() {}
}

class ConcreteStrategyA extends Strategy {
    AlgorithmInterface() {
        console.log("Called ConcreteStrategyA.AlgorithmInterface()");
    }
}

class ConcreteStrategyB extends Strategy {
    AlgorithmInterface() {
        console.log("Called ConcreteStrategyB.AlgorithmInterface()");
    }
}

class ConcreteStrategyC extends Strategy {
    AlgorithmInterface() {
        console.log("Called ConcreteStrategyC.AlgorithmInterface()");
    }
}

class Context {
    constructor(strategy) {
        this.strategy = strategy;
    }

    ContextInterface() {
        this.strategy.AlgorithmInterface();
    }
}

let context;

context = new Context(new ConcreteStrategyA());
context.ContextInterface();

context = new Context(new ConcreteStrategyB());
context.ContextInterface();

context = new Context(new ConcreteStrategyC());
context.ContextInterface();