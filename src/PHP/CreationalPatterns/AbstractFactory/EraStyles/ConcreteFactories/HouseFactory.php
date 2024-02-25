<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\ConcreteFactories;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObjectStylesFactory;
use CreationalPatterns\AbstractFactory\EraStyles\Products\MedievalHouse;
use CreationalPatterns\AbstractFactory\EraStyles\Products\RenaissanceHouse;
use CreationalPatterns\AbstractFactory\EraStyles\Products\VictorianHouse;

class HouseFactory extends EraObjectStylesFactory {
    public function createMedievalStyleObject(): MedievalHouse
    {
        return new MedievalHouse();
    }

    public function createRenaissanceStyleObject(): RenaissanceHouse
    {
        return new RenaissanceHouse();
    }

    public function createVictorianEraStyleObject(): VictorianHouse
    {
        return new VictorianHouse();
    }
}