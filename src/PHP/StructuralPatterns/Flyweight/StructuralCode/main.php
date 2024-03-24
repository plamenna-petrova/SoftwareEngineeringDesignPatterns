<?php

abstract class Flyweight {
    public abstract function executeOperation($extrinsicState);
}

class ConcreteFlyweight extends Flyweight {
    public function executeOperation($extrinsicState): void
    {
        echo "ConcreteFlyweight: $extrinsicState\n";
    }
}

class UnsharedConcreteFlyweight extends Flyweight {
    public function executeOperation($extrinsicState): void
    {
        echo "UnsharedConcreteFlyweight: $extrinsicState\n";
    }
}

class FlyweightFactory {
    private array $flyweights = [];

    public function __construct() {
        $this->flyweights["X"] = new ConcreteFlyweight();
        $this->flyweights["Y"] = new ConcreteFlyweight();
        $this->flyweights["Z"] = new ConcreteFlyweight();
    }

    public function getFlyweight($key) {
        return $this->flyweights[$key];
    }
}

$extrinsicState = 22;
$flyweightFactory = new FlyweightFactory();

$flyweightX = $flyweightFactory->getFlyweight("X");
$flyweightX->executeOperation(--$extrinsicState);

$flyweightY = $flyweightFactory->getFlyweight("Y");
$flyweightY->executeOperation(--$extrinsicState);

$flyweightZ = $flyweightFactory->getFlyweight("Z");
$flyweightZ->executeOperation(--$extrinsicState);

$unsharedConcreteFlyweight = new UnsharedConcreteFlyweight();
$unsharedConcreteFlyweight->executeOperation(--$extrinsicState);

