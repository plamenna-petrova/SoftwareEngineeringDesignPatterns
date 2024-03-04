abstract class Prototype implements Cloneable {
    private String id;

    public Prototype(String id) {
        this.id = id;
    }

    public String getID() {
        return id;
    }

    @Override
    public Prototype clone() {
        try {
            return (Prototype) super.clone();
        } catch (CloneNotSupportedException cloneNotSupportedException) {
            throw new RuntimeException(cloneNotSupportedException);
        }
    }
}

class ConcretePrototype1 extends Prototype {
    public ConcretePrototype1(String id) {
        super(id);
    }
}

class ConcretePrototype2 extends Prototype {
    public ConcretePrototype2(String id) {
        super(id);
    }
}

public class Main {
    public static void main(String[] args) {
        ConcretePrototype1 concretePrototype1 = new ConcretePrototype1("I");
        ConcretePrototype1 clonedConcretePrototype1 = (ConcretePrototype1) concretePrototype1.clone();
        System.out.println("Cloned: " + clonedConcretePrototype1.getID());

        ConcretePrototype2 concretePrototype2 = new ConcretePrototype2("II");
        ConcretePrototype2 clonedConcretePrototype2 = (ConcretePrototype2) concretePrototype2.clone();
        System.out.println("Cloned: " + clonedConcretePrototype2.getID());
    }
}
