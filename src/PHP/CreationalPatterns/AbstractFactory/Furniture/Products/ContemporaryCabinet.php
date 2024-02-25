<?php

namespace CreationalPatterns\AbstractFactory\Furniture\Products;

use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurniture;

class ContemporaryCabinet implements IFurniture {
    public function showFurnitureStyle(): void
    {
        echo "I am a contemporary cabinet\n";
    }
}