
class Prototype {
    constructor(id) {
        this.ID = id;
    }

    clone() {
        return Object.assign(Object.create(Object.getPrototypeOf(this)), this);
    }
}

class ConcretePrototype1 extends Prototype {
    constructor(id) {
        super(id);
    }

    clone() {
        return new ConcretePrototype1(this.ID);
    }
}

class ConcretePrototype2 extends Prototype {
    constructor(id) {
        super(id);
    }

    clone() {
        return new ConcretePrototype2(this.ID);
    }
}

let concretePrototype1 = new ConcretePrototype1("I");
let clonedConcretePrototype1 = concretePrototype1.clone();
console.log(`Cloned: ${clonedConcretePrototype1.ID}`);

let concretePrototype2 = new ConcretePrototype2("II");
let clonedConcretePrototype2 = concretePrototype2.clone();
console.log(`Cloned: ${clonedConcretePrototype2.ID}`);
