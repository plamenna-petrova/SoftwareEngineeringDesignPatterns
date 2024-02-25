<?php

namespace CreationalPatterns\AbstractFactory\Furniture\ConcreteFactories;

use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurniture;
use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurnitureFactory;
use CreationalPatterns\AbstractFactory\Furniture\Products\ScandinavianCabinet;
use CreationalPatterns\AbstractFactory\Furniture\Products\ScandinavianChair;
use CreationalPatterns\AbstractFactory\Furniture\Products\ScandinavianDiningTable;

class ScandinavianFurnitureFactory implements IFurnitureFactory {
    public function createCabinet(): IFurniture {
        return new ScandinavianCabinet();
    }

    public function createChair(): IFurniture {
        return new ScandinavianChair();
    }

    public function createDiningTable(): IFurniture {
        return new ScandinavianDiningTable();
    }
}