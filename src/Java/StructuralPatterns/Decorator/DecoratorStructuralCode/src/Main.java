abstract class Component {
    public abstract void executeOperation();
}

class ConcreteComponent extends Component {
    @Override
    public void executeOperation() {
        System.out.println("Called executeOperation() from Concrete Component");
    }
}

abstract class Decorator extends Component {
    protected Component component;

    public void setComponent(Component component) {
        this.component = component;
    }

    @Override
    public void executeOperation() {
        if (component != null) {
            component.executeOperation();
        }
    }
}

class ConcreteDecoratorA extends Decorator {
    @Override
    public void executeOperation() {
        super.executeOperation();
        System.out.println("Called executeOperation() from " + getClass().getSimpleName());
    }
}

class ConcreteDecoratorB extends Decorator {
    @Override
    public void executeOperation() {
        super.executeOperation();
        addBehavior();
        System.out.println("Called executeOperation() from " + getClass().getSimpleName());
    }

    public void addBehavior() {
        System.out.println("Added Behavior");
    }
}

public class Main {
    public static void main(String[] args) {
        ConcreteComponent concreteComponent = new ConcreteComponent();

        ConcreteDecoratorA concreteDecoratorA = new ConcreteDecoratorA();
        ConcreteDecoratorB concreteDecoratorB = new ConcreteDecoratorB();

        concreteDecoratorA.setComponent(concreteComponent);
        concreteDecoratorB.setComponent(concreteComponent);

        concreteDecoratorB.executeOperation();
    }
}