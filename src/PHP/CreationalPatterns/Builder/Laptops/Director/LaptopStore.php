<?php

namespace CreationalPatterns\Builder\Laptops\Director;

use CreationalPatterns\Builder\Laptops\Builder\LaptopBuilder;

class LaptopStore
{
    public function buildLaptopConfiguration(LaptopBuilder $laptopBuilder): void
    {
        $laptopBuilder->setModel();
        $laptopBuilder->setCPUSeries();
        $laptopBuilder->setGPUModel();
        $laptopBuilder->setRAMType();
        $laptopBuilder->setRAMSize();
        $laptopBuilder->setDisplayType();
        $laptopBuilder->setSSDType();
        $laptopBuilder->setSSDCapacity();
        $laptopBuilder->setExtras();
    }
}