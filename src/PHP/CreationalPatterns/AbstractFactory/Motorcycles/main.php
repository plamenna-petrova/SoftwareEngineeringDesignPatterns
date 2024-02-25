<?php

abstract class MotorcyclesFactory {
    abstract public function createScooter();
    abstract public function createSportsBike();
}

class HondaFactory extends MotorcyclesFactory {
    public function createScooter() {
        return new MaxiScooter();
    }

    public function createSportsBike() {
        return new SportsTourer();
    }
}

class YamahaFactory extends MotorcyclesFactory {
    public function createScooter() {
        return new VintageScooter();
    }

    public function createSportsBike() {
        return new TrackMotorbike();
    }
}

abstract class Scooter {

}

abstract class SportsBike {
    abstract public function overrun(Scooter $scooter);
}

class MaxiScooter extends Scooter {

}

class SportsTourer extends SportsBike {
    public function overrun(Scooter $scooter) {
        echo get_class($this) . " overruns " . get_class($scooter) . PHP_EOL;
    }
}

class VintageScooter extends Scooter {

}

class TrackMotorbike extends SportsBike {
    public function overrun(Scooter $scooter) {
        echo get_class($this) . " overruns " . get_class($scooter) . PHP_EOL;
    }
}

class MotorcyclesClient {
    private $scooter;
    private $sportsBike;

    public function __construct(MotorcyclesFactory $motorcyclesFactory) {
        $this->scooter = $motorcyclesFactory->createScooter();
        $this->sportsBike = $motorcyclesFactory->createSportsBike();
    }

    public function setRace() {
        $this->sportsBike->overrun($this->scooter);
    }
}

$hondaFactory = new HondaFactory();
$motorcyclesClient = new MotorcyclesClient($hondaFactory);
$motorcyclesClient->setRace();

$yamahaFactory = new YamahaFactory();
$motorcyclesClient = new MotorcyclesClient($yamahaFactory);
$motorcyclesClient->setRace();
