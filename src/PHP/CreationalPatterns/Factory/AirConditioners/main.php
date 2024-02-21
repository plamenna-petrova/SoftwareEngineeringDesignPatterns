<?php

class Action
{
    const Cooling = 0;
    const Warming = 1;
}

class CoolingFactory
{
    public function createAirConditioner($temperature): CoolingManager
    {
        return new CoolingManager($temperature);
    }
}

class WarmingFactory
{
    public function createAirConditioner($temperature): WarmingManager
    {
        return new WarmingManager($temperature);
    }
}

interface IAirConditioner
{
    public function operate();
}

class CoolingManager implements IAirConditioner
{
    private float $temperature;

    public function __construct($temperature)
    {
        $this->temperature = $temperature;
    }

    public function operate(): void
    {
        echo "Cooling the room to the required temperature of {$this->temperature} degrees\n";
    }
}

class WarmingManager implements IAirConditioner
{
    private float $temperature;

    public function __construct($temperature)
    {
        $this->temperature = $temperature;
    }

    public function operate(): void
    {
        echo "Warming the room to the required temperature of {$this->temperature} degrees\n";
    }
}

class AirConditionersManager
{
    private array $airConditionerFactories = [];

    public function __construct()
    {
        $actionReflectionClass = new ReflectionClass(Action::class);
        $actionReflectionClassConstants = $actionReflectionClass->getConstants();
        $actionReflectionClassConstantsNames = array_keys($actionReflectionClassConstants);

        foreach ($actionReflectionClassConstantsNames as $actionReflectionClassConstantsName) {
            $airConditionerFactoryClassName = $actionReflectionClassConstantsName . "Factory";
            $airConditionerFactory = new $airConditionerFactoryClassName();
            $actionReflectionClassConstantValue = $actionReflectionClassConstants[$actionReflectionClassConstantsName];
            $this->airConditionerFactories[$actionReflectionClassConstantValue] = $airConditionerFactory;
        }
    }

    public function executeCreation($action, $temperature)
    {
        return $this->airConditionerFactories[$action]->createAirConditioner($temperature);
    }
}

$airConditionersManager = new AirConditionersManager();

$coolingAirConditioner = $airConditionersManager->executeCreation(Action::Cooling, 22.5);
$coolingAirConditioner->operate();

$warmingAirConditioner = $airConditionersManager->executeCreation(Action::Warming, 33.4);
$warmingAirConditioner->operate();
