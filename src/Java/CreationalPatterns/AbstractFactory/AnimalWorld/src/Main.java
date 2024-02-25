abstract class ContinentFactory {
    public abstract Herbivore createHerbivore();
    public abstract Carnivore createCarnivore();
}

class AfricaFactory extends ContinentFactory {
    @Override
    public Herbivore createHerbivore() {
        return new Wildebeest();
    }

    @Override
    public Carnivore createCarnivore() {
        return new Lion();
    }
}

class AmericaFactory extends ContinentFactory {
    @Override
    public Herbivore createHerbivore() {
        return new Bison();
    }

    @Override
    public Carnivore createCarnivore() {
        return new Wolf();
    }
}

abstract class Herbivore {
}

abstract class Carnivore {
    public abstract void eat(Herbivore herbivore);
}

class Wildebeest extends Herbivore {
}

class Lion extends Carnivore {
    @Override
    public void eat(Herbivore herbivore) {
        System.out.println(this.getClass().getSimpleName() + " eats " + herbivore.getClass().getSimpleName());
    }
}

class Bison extends Herbivore {
}

class Wolf extends Carnivore {
    @Override
    public void eat(Herbivore herbivore) {
        System.out.println(this.getClass().getSimpleName() + " eats " + herbivore.getClass().getSimpleName());
    }
}

class AnimalWorld {
    private Herbivore herbivore;
    private Carnivore carnivore;

    public AnimalWorld(ContinentFactory continentFactory) {
        herbivore = continentFactory.createHerbivore();
        carnivore = continentFactory.createCarnivore();
    }

    public void runFoodChain() {
        carnivore.eat(herbivore);
    }
}

public class Main {
    public static void main(String[] args) {
        ContinentFactory africaFactory = new AfricaFactory();
        AnimalWorld africaAnimalWorld = new AnimalWorld(africaFactory);
        africaAnimalWorld.runFoodChain();

        ContinentFactory americaFactory = new AmericaFactory();
        AnimalWorld americaAnimalWorld = new AnimalWorld(americaFactory);
        americaAnimalWorld.runFoodChain();
    }
}