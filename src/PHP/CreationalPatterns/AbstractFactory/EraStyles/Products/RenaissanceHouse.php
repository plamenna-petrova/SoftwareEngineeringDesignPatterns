<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\Products;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObject;
use CreationalPatterns\AbstractFactory\EraStyles\Constants\GlobalConstants;

class RenaissanceHouse extends EraObject {
    public function showDetails(): void
    {
        echo sprintf(GlobalConstants::HouseMessage, "Renaissance") . PHP_EOL;
    }
}