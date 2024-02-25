<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\Products;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObject;
use CreationalPatterns\AbstractFactory\EraStyles\Constants\GlobalConstants;

class VictorianShip extends EraObject {
    public function ShowDetails() {
        echo sprintf(GlobalConstants::ShipMessage, "Victorian Era") . PHP_EOL;
    }
}