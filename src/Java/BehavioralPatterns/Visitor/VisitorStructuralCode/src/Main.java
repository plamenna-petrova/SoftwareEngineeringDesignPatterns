import java.util.ArrayList;
import java.util.List;

abstract class Visitor {
    public abstract void visitConcreteElementA(ConcreteElementA concreteElementA);
    public abstract void visitConcreteElementB(ConcreteElementB concreteElementB);
}

class ConcreteVisitorA extends Visitor {
    @Override
    public void visitConcreteElementA(ConcreteElementA concreteElementA) {
        System.out.printf("%s visited by %s\n", concreteElementA.getClass().getSimpleName(), this.getClass().getSimpleName());
    }

    @Override
    public void visitConcreteElementB(ConcreteElementB concreteElementB) {
        System.out.printf("%s visited by %s\n", concreteElementB.getClass().getSimpleName(), this.getClass().getSimpleName());
    }
}

class ConcreteVisitorB extends Visitor {
    @Override
    public void visitConcreteElementA(ConcreteElementA concreteElementA) {
        System.out.printf("%s visited by %s\n", concreteElementA.getClass().getSimpleName(), this.getClass().getSimpleName());
    }

    @Override
    public void visitConcreteElementB(ConcreteElementB concreteElementB) {
        System.out.printf("%s visited by %s\n", concreteElementB.getClass().getSimpleName(), this.getClass().getSimpleName());
    }
}

abstract class Element {
    public abstract void accept(Visitor visitor);
}

class ConcreteElementA extends Element {
    @Override
    public void accept(Visitor visitor) {
        visitor.visitConcreteElementA(this);
    }

    public void operationA() {
    }
}

class ConcreteElementB extends Element {
    @Override
    public void accept(Visitor visitor) {
        visitor.visitConcreteElementB(this);
    }

    public void operationB() {
    }
}

class ObjectStructure {
    private final List<Element> elements = new ArrayList<>();

    public void attach(Element element) {
        elements.add(element);
    }

    public void detach(Element element) {
        elements.remove(element);
    }

    public void accept(Visitor visitor) {
        for (Element element : elements) {
            element.accept(visitor);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        ObjectStructure objectStructure = new ObjectStructure();

        objectStructure.attach(new ConcreteElementA());
        objectStructure.attach(new ConcreteElementB());

        ConcreteVisitorA concreteVisitorA = new ConcreteVisitorA();
        ConcreteVisitorB concreteVisitorB = new ConcreteVisitorB();

        objectStructure.accept(concreteVisitorA);
        objectStructure.accept(concreteVisitorB);
    }
}