<?php

class Car {
    public string $owner;
    public ?string $number;
    public string $company;
    public string $model;
    public string $color;

    public function __construct($company, $model, $color, $number = null, $owner = "") {
        $this->company = $company;
        $this->model = $model;
        $this->color = $color;
        $this->number = $number;
        $this->owner = $owner;
    }

    public function __toString() {
        $info = "Company: {$this->company}, Model: {$this->model}, Color: {$this->color}";
        if (!empty($this->number) && !empty($this->owner)) {
            $info .= ", Number: {$this->number}, Owner: {$this->owner}";
        }
        return $info;
    }
}

class CarFlyweight {
    private Car $carSharedState;

    public function __construct($car) {
        $this->carSharedState = $car;
    }

    public function operation($car): void
    {
        echo "Flyweight - displaying shared state: " . $this->carSharedState . " and unique state: " . $car . " state.\n";
    }
}

class CarFlyweightFactory {
    private array $carFlyweights = [];

    public function __construct(...$cars) {
        foreach ($cars as $car) {
            $this->carFlyweights[$this->getCarKey($car)] = new CarFlyweight($car);
        }
    }

    public function getFlyweight($carSharedState) {
        $carKey = $this->getCarKey($carSharedState);

        if (!array_key_exists($carKey, $this->carFlyweights)) {
            echo "FlyweightFactory: Can't find a flyweight, creating new one.\n";
            $this->carFlyweights[$carKey] = new CarFlyweight($carSharedState);
        } else {
            echo "FlyweightFactory: Reusing existing flyweight.\n";
        }

        return $this->carFlyweights[$carKey];
    }

    public function listFlyweights(): void
    {
        $carFlyweightsCount = count($this->carFlyweights);
        echo "\nFlyweightFactory: Car flyweights count: {$carFlyweightsCount}\n";

        foreach ($this->carFlyweights as $carKey => $carFlyweight) {
            echo $carKey . "\n";
        }
    }

    private function getCarKey($car): string
    {
        $carCharacteristics = [
            $car->model,
            $car->color,
            $car->company
        ];

        if (!is_null($car->number) && !is_null($car->owner)) {
            $carCharacteristics[] = $car->number;
            $carCharacteristics[] = $car->owner;
        }

        sort($carCharacteristics);

        return implode("_", $carCharacteristics);
    }
}

$cars = [
    new Car("Chevrolet", "Camaro2018", "pink"),
    new Car("Mercedes Benz", "C300", "black"),
    new Car("Mercedes Benz", "C500", "red"),
    new Car("BMW", "M5", "red"),
    new Car("BMW", "X6", "white")
];

$carFlyweightFactory = new CarFlyweightFactory(...$cars);
$carFlyweightFactory->listFlyweights();

function addCarToPoliceDatabase($carFlyweightFactory, $car): void
{
    echo "\nClient: Adding a car to the police database.\n";

    $carFlyweight = $carFlyweightFactory->getFlyweight(new Car(
        $car->color,
        $car->model,
        $car->company,
        $car->number,
        $car->owner
    ));

    $carFlyweight->operation($car);
}

addCarToPoliceDatabase($carFlyweightFactory, new Car(
    "BMW",
    "M5",
    "red",
    "CL234IR",
    "James Doe"
));

addCarToPoliceDatabase($carFlyweightFactory, new Car(
    "BMW",
    "X1",
    "red",
    "CL234IR",
    "James Doe"
));

$carFlyweightFactory->listFlyweights();
