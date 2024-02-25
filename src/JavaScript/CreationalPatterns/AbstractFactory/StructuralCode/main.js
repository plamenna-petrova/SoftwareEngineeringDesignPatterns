
class AbstractFactory {
    createProductA() { }
    createProductB() { }
}

class ConcreteFactory1 extends AbstractFactory {
    createProductA() {
        return new ProductA1();
    }

    createProductB() {
        return new ProductB1();
    }
}

class ConcreteFactory2 extends AbstractFactory {
    createProductA() {
        return new ProductA2();
    }

    createProductB() {
        return new ProductB2();
    }
}

class AbstractProductA { }

class AbstractProductB {
    interact(abstractProductA) { }
}

class ProductA1 extends AbstractProductA { }

class ProductB1 extends AbstractProductB {
    interact(abstractProductA) {
        console.log(`${this.constructor.name} interacts with ${abstractProductA.constructor.name}`);
    }
}

class ProductA2 extends AbstractProductA { }

class ProductB2 extends AbstractProductB {
    interact(abstractProductA) {
        console.log(`${this.constructor.name} interacts with ${abstractProductA.constructor.name}`);
    }
}

class Client {
    constructor(abstractFactory) {
        this.abstractProductA = abstractFactory.createProductA();
        this.abstractProductB = abstractFactory.createProductB();
    }

    run() {
        this.abstractProductB.interact(this.abstractProductA);
    }
}

// Example usage
const concreteFactory1 = new ConcreteFactory1();
const client1 = new Client(concreteFactory1);
client1.run();

const concreteFactory2 = new ConcreteFactory2();
const client2 = new Client(concreteFactory2);
client2.run();