import java.util.HashMap;
import java.util.Map;

class Alpha {
    public String description;

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}

class Bravo {
    public String name;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}

class FactoryBase<T> {
    protected T create() {
        return null; // Default implementation for demonstration purposes
    }
}

class AlphaFactory extends FactoryBase<Alpha> {
    @Override
    protected Alpha create() {
        Alpha alpha = new Alpha();
        alpha.setDescription("Alpha Here");
        return alpha;
    }
}

class BravoFactory extends FactoryBase<Bravo> {
    @Override
    protected Bravo create() {
        Bravo bravo = new Bravo();
        bravo.setName("Bravo");
        return bravo;
    }
}

class ServiceLocator {
    public static <T> FactoryBase<T> getFactory(Class<T> factoryClass) {
        if (factoryClass.equals(Alpha.class)) {
            return (FactoryBase<T>) new AlphaFactory();
        }

        if (factoryClass.equals(Bravo.class)) {
            return (FactoryBase<T>) new BravoFactory();
        }

        throw new IllegalArgumentException("No factory defined for type " + factoryClass);
    }
}

class Program {
    public static void main(String[] args) {
        FactoryBase<Alpha> alphaFactory = ServiceLocator.getFactory(Alpha.class);
        Alpha alphaObject = alphaFactory.create();
        System.out.println("Description: " + alphaObject.getDescription());

        FactoryBase<Bravo> bravoFactory = ServiceLocator.getFactory(Bravo.class);
        Bravo bravoObject = bravoFactory.create();
        System.out.println("Name: " + bravoObject.getName());
    }
}