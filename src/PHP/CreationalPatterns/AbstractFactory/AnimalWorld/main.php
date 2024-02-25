<?php

abstract class ContinentFactory {
    abstract public function createHerbivore();
    abstract public function createCarnivore();
}

class AfricaFactory extends ContinentFactory {
    public function createHerbivore() {
        return new WildeBeest();
    }

    public function createCarnivore() {
        return new Lion();
    }
}

class AmericaFactory extends ContinentFactory {
    public function createHerbivore() {
        return new Bison();
    }

    public function createCarnivore() {
        return new Wolf();
    }
}

abstract class Herbivore {

}

abstract class Carnivore {
    abstract public function eat(Herbivore $herbivore);
}

class WildeBeest extends Herbivore {

}

class Lion extends Carnivore {
    public function eat(Herbivore $herbivore) {
        echo $this::class . " eats " . $herbivore::class . PHP_EOL;
    }
}

class Bison extends Herbivore {

}

class Wolf extends Carnivore {
    public function eat(Herbivore $herbivore) {
        echo $this::class . " eats " . $herbivore::class . PHP_EOL;
    }
}

class AnimalWorld {
    private $herbivore;
    private $carnivore;

    public function __construct(ContinentFactory $continentFactory) {
        $this->herbivore = $continentFactory->createHerbivore();
        $this->carnivore = $continentFactory->createCarnivore();
    }

    public function runFoodChain() {
        $this->carnivore->eat($this->herbivore);
    }
}

$africaFactory = new AfricaFactory();
$africaAnimalWorld = new AnimalWorld($africaFactory);
$africaAnimalWorld->runFoodChain();

$americaFactory = new AmericaFactory();
$americaAnimalWorld = new AnimalWorld($americaFactory);
$americaAnimalWorld->runFoodChain();
