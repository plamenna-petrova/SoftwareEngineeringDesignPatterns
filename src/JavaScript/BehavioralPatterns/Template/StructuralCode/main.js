
class AbstractClass {
    templateMethod() {
        this.primitiveOperationA();
        this.primitiveOperationB();
        console.log();
    }

    primitiveOperationA() {
        throw new Error("Abstract method primitiveOperationA() must be implemented.");
    }

    primitiveOperationB() {
        throw new Error("Abstract method primitiveOperationB() must be implemented.");
    }
}

class ConcreteClassA extends AbstractClass {
    primitiveOperationA() {
        console.log("ConcreteClassA.PrimitiveOperationA");
    }

    primitiveOperationB() {
        console.log("ConcreteClassA.PrimitiveOperationB");
    }
}

class ConcreteClassB extends AbstractClass {
    primitiveOperationA() {
        console.log("ConcreteClassB.PrimitiveOperationA");
    }

    primitiveOperationB() {
        console.log("ConcreteClassB.PrimitiveOperationB");
    }
}

let concreteClassA = new ConcreteClassA();
concreteClassA.templateMethod();

let concreteClassB = new ConcreteClassB();
concreteClassB.templateMethod();