<?php

class Vehicle {
    private string $vehicleType;
    private array $parts = array();

    public function __construct($vehicleType) {
        $this->vehicleType = $vehicleType;
    }

    public function __get($key) {
        return $this->parts[$key];
    }

    public function __set($key, $value) {
        $this->parts[$key] = $value;
    }

    public function show(): void
    {
        echo "\n" . str_repeat('-', 25) . PHP_EOL;
        echo "Vehicle Type: {$this->vehicleType}" . PHP_EOL;
        echo " Frame : {$this->frame}" . PHP_EOL;
        echo " Engine : {$this->engine}" . PHP_EOL;
        echo " #Wheels: {$this->wheels}" . PHP_EOL;
        echo " #Doors: {$this->doors}" . PHP_EOL;
    }
}

abstract class VehicleBuilder {
    protected Vehicle $vehicle;

    public function getVehicle(): Vehicle
    {
        return $this->vehicle;
    }

    public abstract function buildFrame();

    public abstract function buildEngine();

    public abstract function buildWheels();

    public abstract function buildDoors();
}

class MotorcycleBuilder extends VehicleBuilder {
    public function __construct() {
        $this->vehicle = new Vehicle("MotorCycle");
    }

    public function buildFrame(): void
    {
        $this->vehicle->frame = "Motorcycle Frame";
    }

    public function buildEngine(): void
    {
        $this->vehicle->engine = "500 cc";
    }

    public function buildWheels(): void
    {
        $this->vehicle->wheels = "2";
    }

    public function buildDoors(): void
    {
        $this->vehicle->doors = "0";
    }
}

class CarBuilder extends VehicleBuilder {
    public function __construct() {
        $this->vehicle = new Vehicle("Car");
    }

    public function buildFrame(): void
    {
        $this->vehicle->frame = "Car Frame";
    }

    public function buildEngine(): void
    {
        $this->vehicle->engine = "2500 cc";
    }

    public function buildWheels(): void
    {
        $this->vehicle->wheels = "4";
    }

    public function buildDoors(): void
    {
        $this->vehicle->doors = "4";
    }
}

class ScooterBuilder extends VehicleBuilder {
    public function __construct() {
        $this->vehicle = new Vehicle("Scooter");
    }

    public function buildFrame(): void
    {
        $this->vehicle->frame = "Scooter Frame";
    }

    public function buildEngine(): void
    {
        $this->vehicle->engine = "50 cc";
    }

    public function buildWheels(): void
    {
        $this->vehicle->wheels = "2";
    }

    public function buildDoors(): void
    {
        $this->vehicle->doors = "0";
    }
}

class Shop {
    public function construct(VehicleBuilder $vehicleBuilder) {
        $vehicleBuilder->buildFrame();
        $vehicleBuilder->buildEngine();
        $vehicleBuilder->buildWheels();
        $vehicleBuilder->buildDoors();
    }
}

$shop = new Shop();
$vehicleBuilder = new ScooterBuilder();

$shop->construct($vehicleBuilder);
$vehicleBuilder->getVehicle()->show();

$vehicleBuilder = new CarBuilder();
$shop->construct($vehicleBuilder);
$vehicleBuilder->getVehicle()->show();

$vehicleBuilder = new MotorcycleBuilder();
$shop->construct($vehicleBuilder);
$vehicleBuilder->getVehicle()->show();