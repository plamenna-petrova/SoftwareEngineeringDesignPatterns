<?php

namespace CreationalPatterns\Builder\Laptops\Builder;

use CreationalPatterns\Builder\Laptops\Product\Laptop;

abstract class LaptopBuilder
{
    public Laptop $laptop;

    public function __construct()
    {
        $this->laptop = new Laptop();
    }

    abstract public function setModel();

    abstract public function setCPUSeries();

    abstract public function setGPUModel();

    abstract public function setRAMType();

    abstract public function setRAMSize();

    abstract public function setDisplayType();

    abstract public function setSSDType();

    abstract public function setSSDCapacity();

    abstract public function setExtras();
}