<?php

interface ICar {
    public function manufacture();
}

class Bmw implements ICar {
    public string $body;
    public string $doors;
    public string $wheels;
    public string $glass;
    public string $engine;

    public function manufacture(): static
    {
        $this->body = "carbon fiber material";
        $this->doors = "4 car doors";
        $this->wheels = "4 MRF wheels";
        $this->glass = "6 car glasses";
        return $this;
    }

    public function __toString() {
        return sprintf("%s [Name = %s], Body = %s, Doors = %s, Wheels: %s, Glass: %s, Engine: %s",
            get_class($this), get_class($this), $this->body, $this->doors, $this->wheels, $this->glass, $this->engine ?? "n/a");
    }
}

abstract class CarDecorator implements ICar {
    protected ICar $car;

    public function __construct(ICar $car) {
        $this->car = $car;
    }

    public function manufacture() {
        return $this->car->manufacture();
    }
}

class DieselCarConcreteDecorator extends CarDecorator {
    public function __construct(ICar $car) {
        parent::__construct($car);
    }

    public function manufacture(): ICar
    {
        parent::manufacture();
        $this->addEngine($this->car);
        return $this->car;
    }

    private function addEngine(ICar $car): void
    {
        if ($car instanceof Bmw) {
            $bmw = $car;
            $bmw->engine = "Diesel Engine";
            echo "Added Diesel Engine to the Car: " . $car . "\n";
        }
    }
}

class PetrolCarConcreteDecorator extends CarDecorator {
    public function __construct(ICar $car) {
        parent::__construct($car);
    }

    public function manufacture(): ICar
    {
        parent::manufacture();
        $this->addEngine($this->car);
        return $this->car;
    }

    private function addEngine(ICar $car): void
    {
        if ($car instanceof Bmw) {
            $bmw = $car;
            $bmw->engine = "Petrol Engine";
            echo "Added Petrol Engine to the Car: " . $car . "\n";
        }
    }
}

$bmwX7 = new Bmw();
$bmwX7->manufacture();
echo $bmwX7 . PHP_EOL;

echo PHP_EOL;

$dieselCarConcreteDecorator = new DieselCarConcreteDecorator($bmwX7);
$dieselCarConcreteDecorator->manufacture();

echo PHP_EOL;

$bmwX5 = new Bmw();

$petrolCarConcreteDecorator = new PetrolCarConcreteDecorator($bmwX5);
$petrolCarConcreteDecorator->manufacture();