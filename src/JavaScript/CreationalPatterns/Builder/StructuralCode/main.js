
class Builder {
    buildPartA() {
        throw new Error("Abstract method buildPartA must be overridden");
    }

    buildPartB() {
        throw new Error("Abstract method buildPartB must be overridden");
    }

    getResult() {
        throw new Error("Abstract method getResult must be overridden");
    }
}

class Product {
    constructor() {
        this.parts = [];
    }

    add(part) {
        this.parts.push(part);
    }

    show() {
        console.log(`\nProduct Parts${'-'.repeat(10)}`);
        
        this.parts.forEach(part => {
            console.log(part);
        });
    }
}

class ConcreteBuilder1 extends Builder {
    constructor() {
        super();
        this.product = new Product();
    }

    buildPartA() {
        this.product.add("PartA");
    }

    buildPartB() {
        this.product.add("PartB");
    }

    getResult() {
        return this.product;
    }
}

class ConcreteBuilder2 extends Builder {
    constructor() {
        super();
        this.product = new Product();
    }

    buildPartA() {
        this.product.add("PartX");
    }

    buildPartB() {
        this.product.add("PartY");
    }

    getResult() {
        return this.product;
    }
}

class Director {
    construct(builder) {
        builder.buildPartA();
        builder.buildPartB();
    }
}

const director = new Director();
const firstBuilder = new ConcreteBuilder1();
const secondBuilder = new ConcreteBuilder2();

director.construct(firstBuilder);
const firstProduct = firstBuilder.getResult();
firstProduct.show();

director.construct(secondBuilder);
const secondProduct = secondBuilder.getResult();
secondProduct.show();