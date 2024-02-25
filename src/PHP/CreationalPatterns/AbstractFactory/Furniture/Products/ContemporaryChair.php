<?php

namespace CreationalPatterns\AbstractFactory\Furniture\Products;

use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurniture;

class ContemporaryChair implements IFurniture {
    public function showFurnitureStyle(): void
    {
        echo "I am a contemporary chair\n";
    }
}