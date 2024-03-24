import java.util.HashMap;
import java.util.Map;

abstract class Flyweight {
    public abstract void executeOperation(int extrinsicState);
}

class ConcreteFlyweight extends Flyweight {
    @Override
    public void executeOperation(int extrinsicState) {
        System.out.println("ConcreteFlyweight: " + extrinsicState);
    }
}

class UnsharedConcreteFlyweight extends Flyweight {
    @Override
    public void executeOperation(int extrinsicState) {
        System.out.println("UnsharedConcreteFlyweight : " + extrinsicState);
    }
}

class FlyweightFactory {
    private final Map<String, Flyweight> flyweights = new HashMap<>();

    public FlyweightFactory() {
        flyweights.put("X", new ConcreteFlyweight());
        flyweights.put("Y", new ConcreteFlyweight());
        flyweights.put("Z", new ConcreteFlyweight());
    }

    public Flyweight getFlyweight(String key) {
        return flyweights.get(key);
    }
}

public class Main {
    public static void main(String[] args) {
        int extrinsicState = 22;

        FlyweightFactory flyweightFactory = new FlyweightFactory();

        Flyweight flyweightX = flyweightFactory.getFlyweight("X");
        flyweightX.executeOperation(--extrinsicState);

        Flyweight flyweightY = flyweightFactory.getFlyweight("Y");
        flyweightY.executeOperation(--extrinsicState);

        Flyweight flyweightZ = flyweightFactory.getFlyweight("Z");
        flyweightZ.executeOperation(--extrinsicState);

        UnsharedConcreteFlyweight unsharedConcreteFlyweight = new UnsharedConcreteFlyweight();

        unsharedConcreteFlyweight.executeOperation(--extrinsicState);
    }
}