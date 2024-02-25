<?php

namespace CreationalPatterns\AbstractFactory\Furniture\Products;

use CreationalPatterns\AbstractFactory\Furniture\Interfaces\IFurniture;

class ScandinavianCabinet implements IFurniture {
    public function showFurnitureStyle(): void
    {
        echo "I am a Scandinavian cabinet\n";
    }
}