<?php

namespace CreationalPatterns\Builder\Laptops\ConcreteBuilders;

use CreationalPatterns\Builder\Laptops\Builder\LaptopBuilder;
use CreationalPatterns\Builder\Laptops\Product\Laptop;

class LenovoConcreteBuilder extends LaptopBuilder
{
    public function __construct()
    {
        $this->laptop = new Laptop();
    }

    public function setModel(): void
    {
        echo "Enter Laptop Model: ";
        $this->laptop->model = readline();
    }

    public function setCPUSeries(): void
    {
        echo "Enter CPU Series: ";
        $this->laptop->cpuSeries = readline();
    }

    public function setGPUModel(): void
    {
        echo "Enter GPU Model: ";
        $this->laptop->gpuModel = readline();
    }

    public function setRAMType(): void
    {
        echo "Enter RAM Type: ";
        $this->laptop->ramType = readline();
    }

    public function setRAMSize(): void
    {
        echo "Enter RAM Size: ";
        $this->laptop->ramSize = floatval(readline());
    }

    public function setDisplayType(): void
    {
        echo "Enter Display Type: ";
        $this->laptop->displayType = readline();
    }

    public function setSSDType(): void
    {
        echo "Enter SSD Type: ";
        $this->laptop->ssdType = readline();
    }

    public function setSSDCapacity(): void
    {
        echo "Enter SSD Capacity: ";
        $this->laptop->ssdCapacity = floatval(readline());
    }

    public function setExtras(): void
    {
        echo "Add extra item (Exit with END): ";
        $extraItem = readline();

        while ($extraItem !== "END")
        {
            $this->laptop->extras[] = $extraItem;
            echo "Add extra item (Exit with END): ";
            $extraItem = readline();
        }
    }
}