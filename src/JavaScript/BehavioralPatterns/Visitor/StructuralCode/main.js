
class Visitor {
    visitConcreteElementA(concreteElementA) {
        throw new Error('This method must be overridden.');
    }

    visitConcreteElementB(concreteElementB) {
        throw new Error('This method must be overridden.');
    }
}

class ConcreteVisitorA extends Visitor {
    visitConcreteElementA(concreteElementA) {
        console.log(`${concreteElementA.constructor.name} visited by ${this.constructor.name}`);
    }

    visitConcreteElementB(concreteElementB) {
        console.log(`${concreteElementB.constructor.name} visited by ${this.constructor.name}`);
    }
}

class ConcreteVisitorB extends Visitor {
    visitConcreteElementA(concreteElementA) {
        console.log(`${concreteElementA.constructor.name} visited by ${this.constructor.name}`);
    }

    visitConcreteElementB(concreteElementB) {
        console.log(`${concreteElementB.constructor.name} visited by ${this.constructor.name}`);
    }
}

class Element {
    accept(visitor) {
        throw new Error('This method must be overridden.');
    }
}

class ConcreteElementA extends Element {
    accept(visitor) {
        visitor.visitConcreteElementA(this);
    }

    operationA() {

    }
}

class ConcreteElementB extends Element {
    accept(visitor) {
        visitor.visitConcreteElementB(this);
    }

    operationB() {

    }
}

class ObjectStructure {
    constructor() {
        this.elements = [];
    }

    attach(element) {
        this.elements.push(element);
    }

    detach(element) {
        const elementIndexToDetach = this.elements.indexOf(element);

        if (elementIndexToDetach !== -1) {
            this.elements.splice(elementIndexToDetach, 1);
        }
    }

    accept(visitor) {
        this.elements.forEach(element => {
            element.accept(visitor);
        });
    }
}

const objectStructure = new ObjectStructure();

objectStructure.attach(new ConcreteElementA());
objectStructure.attach(new ConcreteElementB());

const concreteVisitorA = new ConcreteVisitorA();
const concreteVisitorB = new ConcreteVisitorB();

objectStructure.accept(concreteVisitorA);
objectStructure.accept(concreteVisitorB);
