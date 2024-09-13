<?php

abstract class MedievalShipTemplate {
    public function buildMedievalShip(): void
    {
        $this->buildFoundation();
        $this->buildHull();
        $this->buildDeck();
        $this->buildMasts();
        $this->buildCabins();
        $this->buildExteriorDetails();
        echo "The ship is built.\n";
    }

    protected abstract function buildFoundation();

    protected abstract function buildHull();

    protected abstract function buildDeck();

    protected abstract function buildMasts();

    protected abstract function buildCabins();

    protected abstract function buildExteriorDetails();
}

class Cog extends MedievalShipTemplate {

    protected function buildFoundation(): void
    {
        echo "Building foundation with oak\n";
    }

    protected function buildHull(): void
    {
        echo "Building a double-ended hull\n";
    }

    protected function buildDeck(): void
    {
        echo "Building a small deck\n";
    }

    protected function buildMasts(): void
    {
        echo "Building one mast\n";
    }

    protected function buildCabins(): void
    {
        echo "Building four cabins\n";
    }

    protected function buildExteriorDetails(): void
    {
        echo "Building a rear tower\n";
    }
}

class Caravel extends MedievalShipTemplate {
    protected function buildFoundation(): void
    {
        echo "Building foundation, using caravel method of construction\n";
    }

    protected function buildHull(): void
    {
        echo "Building a lateen rigged hull\n";
    }

    protected function buildDeck(): void
    {
        echo "Building a large deck\n";
    }

    protected function buildMasts(): void
    {
        echo "Building three masts\n";
    }

    protected function buildCabins(): void
    {
        echo "Building eight cabins\n";
    }

    protected function buildExteriorDetails(): void
    {
        echo "Building templar flags ornaments\n";
    }
}

echo "Building the medieval ship Cog\n";
$medievalShip = new Cog();
$medievalShip->buildMedievalShip();

echo "\n";

echo "Building the medieval ship Caravel\n";
$medievalShip = new Caravel();
$medievalShip->buildMedievalShip();
