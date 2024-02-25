<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\Products;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObject;
use CreationalPatterns\AbstractFactory\EraStyles\Constants\GlobalConstants;

class MedievalHouse extends EraObject {
    public function showDetails(): void
    {
        echo sprintf(GlobalConstants::HouseMessage, "Medieval") . PHP_EOL;
    }
}