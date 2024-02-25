<?php

namespace CreationalPatterns\AbstractFactory\Furniture\ConcreteFactories;

use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurniture;
use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurnitureFactory;
use CreationalPatterns\AbstractFactory\Furniture\Products\ClassicCabinet;
use CreationalPatterns\AbstractFactory\Furniture\Products\ClassicChair;
use CreationalPatterns\AbstractFactory\Furniture\Products\ClassicDiningTable;

class ClassicFurnitureFactory implements IFurnitureFactory {
    public function createCabinet(): IFurniture {
        return new ClassicCabinet();
    }

    public function createChair(): IFurniture {
        return new ClassicChair();
    }

    public function createDiningTable(): IFurniture {
        return new ClassicDiningTable();
    }
}