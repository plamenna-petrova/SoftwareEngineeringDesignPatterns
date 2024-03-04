abstract class AbstractFactory {
    public abstract AbstractProductA createProductA();

    public abstract AbstractProductB createProductB();
}

class ConcreteFactory1 extends AbstractFactory {
    @Override
    public AbstractProductA createProductA() {
        return new ProductA1();
    }

    @Override
    public AbstractProductB createProductB() {
        return new ProductB1();
    }
}

class ConcreteFactory2 extends AbstractFactory {
    @Override
    public AbstractProductA createProductA() {
        return new ProductA2();
    }

    @Override
    public AbstractProductB createProductB() {
        return new ProductB2();
    }
}

abstract class AbstractProductA {
}

abstract class AbstractProductB {
    public abstract void interact(AbstractProductA abstractProductA);
}

class ProductA1 extends AbstractProductA {
}

class ProductB1 extends AbstractProductB {
    @Override
    public void interact(AbstractProductA abstractProductA) {
        System.out.println(this.getClass().getSimpleName() + " interacts with " + abstractProductA.getClass().getSimpleName());
    }
}

class ProductA2 extends AbstractProductA {
}

class ProductB2 extends AbstractProductB {
    @Override
    public void interact(AbstractProductA abstractProductA) {
        System.out.println(this.getClass().getSimpleName() + " interacts with " + abstractProductA.getClass().getSimpleName());
    }
}

class Client {
    private AbstractProductA abstractProductA;
    private AbstractProductB abstractProductB;

    public Client(AbstractFactory abstractFactory) {
        abstractProductA = abstractFactory.createProductA();
        abstractProductB = abstractFactory.createProductB();
    }

    public void run() {
        abstractProductB.interact(abstractProductA);
    }
}

public class Main {
    public static void main(String[] args) {
        AbstractFactory concreteFactory1 = new ConcreteFactory1();
        Client client1 = new Client(concreteFactory1);
        client1.run();

        AbstractFactory concreteFactory2 = new ConcreteFactory2();
        Client client2 = new Client(concreteFactory2);
        client2.run();
    }
}