<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\ConcreteFactories;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObjectStylesFactory;
use CreationalPatterns\AbstractFactory\EraStyles\Products\MedievalClothing;
use CreationalPatterns\AbstractFactory\EraStyles\Products\RenaissanceClothing;
use CreationalPatterns\AbstractFactory\EraStyles\Products\VictorianClothing;

class ClothingFactory extends EraObjectStylesFactory {
    public function createMedievalStyleObject(): MedievalClothing
    {
        return new MedievalClothing();
    }

    public function createRenaissanceStyleObject(): RenaissanceClothing
    {
        return new RenaissanceClothing();
    }

    public function createVictorianEraStyleObject(): VictorianClothing
    {
        return new VictorianClothing();
    }
}