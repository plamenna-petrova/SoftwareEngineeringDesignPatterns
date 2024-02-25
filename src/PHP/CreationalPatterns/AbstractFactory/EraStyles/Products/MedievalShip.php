<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\Products;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObject;
use CreationalPatterns\AbstractFactory\EraStyles\Constants\GlobalConstants;

class MedievalShip extends EraObject {
    public function showDetails(): void
    {
        echo sprintf(GlobalConstants::ShipMessage, "Medieval") . PHP_EOL;
    }
}