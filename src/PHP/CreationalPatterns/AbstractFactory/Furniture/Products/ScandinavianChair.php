<?php

namespace CreationalPatterns\AbstractFactory\Furniture\Products;

use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurniture;

class ScandinavianChair implements IFurniture {
    public function showFurnitureStyle(): void
    {
        echo "I am a Scandinavian chair\n";
    }
}