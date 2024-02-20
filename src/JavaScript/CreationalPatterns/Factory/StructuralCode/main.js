
class Product {
    constructor() { }
}

class ConcreteProductA extends Product {
    constructor() {
        super();
    }
}

class ConcreteProductB extends Product {
    constructor() {
        super();
    }
}

class Creator {
    createProduct() {
        throw new Error("Method 'createProduct' must be implemented.");
    }
}

class ConcreteCreatorA extends Creator {
    createProduct() {
        return new ConcreteProductA();
    }
}

class ConcreteCreatorB extends Creator {
    createProduct() {
        return new ConcreteProductB();
    }
}

const creators = [new ConcreteCreatorA(), new ConcreteCreatorB()];

creators.forEach((creator) => {
    const createdProduct = creator.createProduct();
    console.log(`Created: ${createdProduct.constructor.name}`);
});