<?php

interface IAircraft
{
    public function isAirborne(): bool;

    public function takeOff(): void;

    public function getHeight(): int;
}

class Aircraft implements IAircraft
{
    private int $height;
    private bool $airborne;

    public function __construct()
    {
        $this->height = 0;
        $this->airborne = false;
    }

    public function isAirborne(): bool
    {
        return $this->airborne;
    }

    public function takeOff(): void
    {
        echo "Aircraft engine takeoff\n";
        $this->height = 200;
        $this->airborne = true;
    }

    public function getHeight(): int
    {
        return $this->height;
    }
}

interface ISeacraft
{
    public function getSpeed(): int;

    public function increaseRevs(): void;
}

class Seacraft implements ISeacraft
{
    private int $speed = 0;

    public function increaseRevs(): void
    {
        $this->speed += 10;
        echo "Seacraft engine increases revs to " . $this->speed . " knots\n";
    }

    public function getSpeed(): int
    {
        return $this->speed;
    }
}

class Seabird extends Seacraft implements IAircraft
{
    private int $height = 0;

    public function getHeight(): int
    {
        return $this->height;
    }

    public function isAirborne(): bool
    {
        return $this->height > 50;
    }

    public function takeOff(): void
    {
        while (!$this->isAirborne()) {
            $this->increaseRevs();
        }
    }

    public function increaseRevs(): void
    {
        parent::increaseRevs();

        if ($this->getSpeed() > 40) {
            $this->height += 100;
        }
    }
}

echo "Experiment 1: test the aircraft's engine\n";
$aircraft = new Aircraft();
$aircraft->takeOff();

if ($aircraft->isAirborne()) {
    echo "The aircraft engine is fine, flying at " . $aircraft->getHeight() . " meters\n";
}

echo "\nExperiment 2: Use the engine in the Seabird\n";
$seabird = new Seabird();
$seabird->takeOff();
echo "The Seabird took off\n";

echo "\nExperiment 3: Increase the speed of the Seabird:\n";
$seacraft = $seabird;
$seacraft->increaseRevs();
$seacraft->increaseRevs();

if ($seabird->isAirborne()) {
    echo "Seabird flying at height " . $seabird->getHeight() . " meters and speed " . $seacraft->getSpeed() . "\n";
}

echo "Experiment successful; the Seabird flies!\n";
