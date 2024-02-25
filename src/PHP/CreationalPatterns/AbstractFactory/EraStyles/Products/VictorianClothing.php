<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\Products;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObject;
use CreationalPatterns\AbstractFactory\EraStyles\Constants\GlobalConstants;

class VictorianClothing extends EraObject {
    public function showDetails(): void
    {
        echo sprintf(GlobalConstants::ClothingMessage, "Victorian Era") . PHP_EOL;
    }
}