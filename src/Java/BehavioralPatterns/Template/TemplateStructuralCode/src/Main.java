abstract class AbstractClass {
    public void templateMethod() {
        primitiveOperationA();
        primitiveOperationB();
        System.out.println();
    }

    public abstract void primitiveOperationA();

    public abstract void primitiveOperationB();
}

class ConcreteClassA extends AbstractClass {
    @Override
    public void primitiveOperationA() {
        System.out.println("ConcreteClassA.primitiveOperationA");
    }

    @Override
    public void primitiveOperationB() {
        System.out.println("ConcreteClassA.primitiveOperationB");
    }
}

class ConcreteClassB extends AbstractClass {
    @Override
    public void primitiveOperationA() {
        System.out.println("ConcreteClassB.primitiveOperationA");
    }

    @Override
    public void primitiveOperationB() {
        System.out.println("ConcreteClassB.primitiveOperationB");
    }
}

public class Main {
    public static void main(String[] args) {
        AbstractClass concreteClassA = new ConcreteClassA();
        concreteClassA.templateMethod();

        AbstractClass concreteClassB = new ConcreteClassB();
        concreteClassB.templateMethod();
    }
}