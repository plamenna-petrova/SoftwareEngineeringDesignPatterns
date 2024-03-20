
class Component {
    executeOperation() {
        
    }
}

class ConcreteComponent extends Component {
    executeOperation() {
        console.log("Called executeOperation() from Concrete Component");
    }
}

class Decorator extends Component {
    setComponent(component) {
        this.component = component;
    }

    executeOperation() {
        if (this.component !== null) {
            this.component.executeOperation();
        }
    }
}

class ConcreteDecoratorA extends Decorator {
    executeOperation() {
        super.executeOperation();
        console.log(`Called executeOperation() from ${this.constructor.name}`);
    }
}

class ConcreteDecoratorB extends Decorator {
    executeOperation() {
        super.executeOperation();
        this.addBehavior();
        console.log(`Called executeOperation() from ${this.constructor.name}`);
    }

    addBehavior() {
        console.log("Added Behavior");
    }
}

const concreteComponent = new ConcreteComponent();
const concreteDecoratorA = new ConcreteDecoratorA();
const concreteDecoratorB = new ConcreteDecoratorB();

concreteDecoratorA.setComponent(concreteComponent);
concreteDecoratorB.setComponent(concreteComponent);

concreteDecoratorB.executeOperation();