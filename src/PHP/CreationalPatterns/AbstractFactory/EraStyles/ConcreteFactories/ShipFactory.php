<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\ConcreteFactories;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObjectStylesFactory;
use CreationalPatterns\AbstractFactory\EraStyles\Products\MedievalShip;
use CreationalPatterns\AbstractFactory\EraStyles\Products\RenaissanceShip;
use CreationalPatterns\AbstractFactory\EraStyles\Products\VictorianShip;

class ShipFactory extends EraObjectStylesFactory {
    public function CreateMedievalStyleObject(): MedievalShip
    {
        return new MedievalShip();
    }

    public function CreateRenaissanceStyleObject(): RenaissanceShip
    {
        return new RenaissanceShip();
    }

    public function CreateVictorianEraStyleObject(): VictorianShip
    {
        return new VictorianShip();
    }
}