<?php

namespace CreationalPatterns\AbstractFactory\Furniture\Products;

use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurniture;

class ClassicChair implements IFurniture {
    public function showFurnitureStyle(): void
    {
        echo "I am a classic chair\n";
    }
}