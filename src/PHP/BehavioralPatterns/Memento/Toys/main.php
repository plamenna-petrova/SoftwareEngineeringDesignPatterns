<?php

class ToyCarMemento
{
    private string $color;

    public function __construct($color)
    {
        $this->color = $color;
    }

    public function getColor(): string
    {
        return $this->color;
    }
}

class ToyCar
{
    private string $color;

    public function __construct()
    {
        $this->color = '';
    }

    public function getColor(): string
    {
        return $this->color;
    }

    public function setColor($color): void
    {
        $this->color = $color;
        echo "Car color changed to $color\n";
    }

    public function saveState(): ToyCarMemento
    {
        return new ToyCarMemento($this->color);
    }

    public function restoreState($toyCarMemento): void
    {
        $this->setColor($toyCarMemento->getColor());
    }
}

class ColorChanger
{
    private ToyCarMemento $toyCarMemento;

    public function changeColor($toyCar, $color): void
    {
        $this->toyCarMemento = $toyCar->saveState();
        $toyCar->setColor($color);
    }

    public function undoColorChange($toyCar): void
    {
        $toyCar->restoreState($this->toyCarMemento);
    }
}

$toyCar = new ToyCar();
$colorChanger = new ColorChanger();

$colorChanger->changeColor($toyCar, "Red");

$savedState = $toyCar->saveState();
$colorChanger->changeColor($toyCar, "Blue");
$colorChanger->changeColor($toyCar, "Green");

$colorChanger->undoColorChange($toyCar);
echo "Current car color: {$toyCar->getColor()}\n";

$toyCar->restoreState($savedState);
echo "Restored car color: {$toyCar->getColor()}\n";
