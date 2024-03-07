class Abstraction {
    protected Implementor implementor;

    public void setImplementor(Implementor implementor) {
        this.implementor = implementor;
    }

    public void executeOperation() {
        implementor.executeOperation();
    }
}

abstract class Implementor {
    public abstract void executeOperation();
}

class RefinedAbstraction extends Abstraction {
    @Override
    public void executeOperation() {
        implementor.executeOperation();
    }
}

class ConcreteImplementorA extends Implementor {
    @Override
    public void executeOperation() {
        System.out.println(getClass().getSimpleName() + " Operation");
    }
}

class ConcreteImplementorB extends Implementor {
    @Override
    public void executeOperation() {
        System.out.println(getClass().getSimpleName() + " Operation");
    }
}

class Program {
    public static void main(String[] args) {
        Abstraction abstraction = new RefinedAbstraction();

        abstraction.setImplementor(new ConcreteImplementorA());
        abstraction.executeOperation();

        abstraction.setImplementor(new ConcreteImplementorB());
        abstraction.executeOperation();
    }
}