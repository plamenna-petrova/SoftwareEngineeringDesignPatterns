<?php

namespace CreationalPatterns\AbstractFactory\Furniture\ConcreteFactories;

use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurniture;
use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurnitureFactory;
use CreationalPatterns\AbstractFactory\Furniture\Products\ContemporaryCabinet;
use CreationalPatterns\AbstractFactory\Furniture\Products\ContemporaryChair;
use CreationalPatterns\AbstractFactory\Furniture\Products\ContemporaryDiningTable;

class ContemporaryFurnitureFactory implements IFurnitureFactory {
    public function createCabinet(): IFurniture {
        return new ContemporaryCabinet();
    }

    public function createChair(): IFurniture
    {
        return new ContemporaryChair();
    }

    public function createDiningTable(): IFurniture
    {
        return new ContemporaryDiningTable();
    }
}