import java.io.*;

class ReferenceTypeClass implements Serializable {
    public String ID;
}

abstract class Prototype<T> implements Serializable, Cloneable {
    @SuppressWarnings("unchecked")
    public T Clone() throws CloneNotSupportedException {
        return (T) this.clone();
    }

    public T DeepCopy() {
        try {
            ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
            ObjectOutputStream objectOutputStream = new ObjectOutputStream(byteArrayOutputStream);

            objectOutputStream.writeObject(this);

            ByteArrayInputStream byteArrayInputStream = new ByteArrayInputStream(byteArrayOutputStream.toByteArray());
            ObjectInputStream objectInputStream = new ObjectInputStream(byteArrayInputStream);

            @SuppressWarnings("unchecked")
            T deepCopy = (T) objectInputStream.readObject();

            objectOutputStream.close();
            objectInputStream.close();

            return deepCopy;
        } catch (IOException | ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
}

class ConcretePrototype extends Prototype<ConcretePrototype> {
    public String ValueType;
    public ReferenceTypeClass DummyReference;

    @Override
    public String toString() {
        return "Value type: " + ValueType + ", Dummy Reference ID: " + DummyReference.ID;
    }
}

public class Main {
    public static void main(String[] args) throws CloneNotSupportedException {
        ConcretePrototype firstConcretePrototype = new ConcretePrototype();
        firstConcretePrototype.ValueType = "1";
        firstConcretePrototype.DummyReference = new ReferenceTypeClass();
        firstConcretePrototype.DummyReference.ID = "1";

        ConcretePrototype secondConcretePrototype = firstConcretePrototype.Clone();
        ConcretePrototype thirdConcretePrototype = firstConcretePrototype.DeepCopy();

        secondConcretePrototype.ValueType = "2";
        secondConcretePrototype.DummyReference.ID = "2";

        System.out.println(firstConcretePrototype.toString());
        System.out.println(secondConcretePrototype.toString());
        System.out.println(thirdConcretePrototype.toString());
    }
}