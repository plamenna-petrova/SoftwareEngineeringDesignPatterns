<?php

abstract class HouseTemplate {
    public function buildHouse(): void
    {
        $this->buildFoundation();
        $this->buildPillars();
        $this->buildWalls();
        $this->buildWindows();
        echo "The house is built\n";
    }

    protected abstract function buildFoundation();

    protected abstract function buildPillars();

    protected abstract function buildWalls();

    protected abstract function buildWindows();
}

class ConcreteHouse extends HouseTemplate {
    protected function buildFoundation(): void
    {
        echo "Building foundation with cement, iron rods and sand\n";
    }

    protected function buildPillars(): void
    {
        echo "Building concrete pillars with cement and sand\n";
    }

    protected function buildWalls(): void
    {
        echo "Building concrete walls\n";
    }

    protected function buildWindows(): void
    {
        echo "Building concrete windows\n";
    }
}

class WoodenHouse extends HouseTemplate {
    protected function buildFoundation(): void
    {
        echo "Building foundation with cement, iron rods and sand\n";
    }

    protected function buildPillars(): void
    {
        echo "Building wood pillars with wood coating\n";
    }

    protected function buildWalls(): void
    {
        echo "Building wood walls\n";
    }

    protected function buildWindows(): void
    {
        echo "Building wood windows\n";
    }
}

echo "Building a concrete house\n";
$houseTemplate = new ConcreteHouse();
$houseTemplate->buildHouse();

echo "Building a wooden house\n";
$houseTemplate = new WoodenHouse();
$houseTemplate->buildHouse();
