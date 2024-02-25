
class ContinentFactory {
    createHerbivore() { }
    createCarnivore() { }
}

class AfricaFactory extends ContinentFactory {
    createHerbivore() {
        return new WildeBeest();
    }

    createCarnivore() {
        return new Lion();
    }
}

class AmericaFactory extends ContinentFactory {
    createHerbivore() {
        return new Bison();
    }

    createCarnivore() {
        return new Wolf();
    }
}

class Herbivore {

}

class Carnivore {
    eat(herbivore) { }
}

class WildeBeest extends Herbivore { 

}

class Lion extends Carnivore {
    eat(herbivore) {
        console.log(`${this.constructor.name} eats ${herbivore.constructor.name}`);
    }
}

class Bison extends Herbivore { 

}

class Wolf extends Carnivore {
    eat(herbivore) {
        console.log(`${this.constructor.name} eats ${herbivore.constructor.name}`);
    }
}

class AnimalWorld {
    constructor(continentFactory) {
        this.herbivore = continentFactory.createHerbivore();
        this.carnivore = continentFactory.createCarnivore();
    }

    runFoodChain() {
        this.carnivore.eat(this.herbivore);
    }
}

const africaFactory = new AfricaFactory();
const africaAnimalWorld = new AnimalWorld(africaFactory);
africaAnimalWorld.runFoodChain();

const americaFactory = new AmericaFactory();
const americaAnimalWorld = new AnimalWorld(americaFactory);
americaAnimalWorld.runFoodChain();