<?php

class LEDTV
{
    private string $size;
    private float $price;
    private bool $hasUSBSupport;

    public function __construct($size, $price, $hasUSBSupport)
    {
        $this->size = $size;
        $this->price = $price;
        $this->hasUSBSupport = $hasUSBSupport;
    }

    public function getSize(): string
    {
        return $this->size;
    }

    public function getPrice(): float
    {
        return $this->price;
    }

    public function hasUSBSupport(): bool
    {
        return $this->hasUSBSupport;
    }

    public function getDetails(): string
    {
        return "LEDTV [Size = {$this->size}, Price = {$this->price}, USBSupport = " . ($this->hasUSBSupport ? "Yes" : "No") . "]";
    }
}

class LEDTVMemento
{
    private LEDTV $ledTV;

    public function __construct($ledTV)
    {
        $this->ledTV = $ledTV;
    }

    public function getLEDTV(): LEDTV
    {
        return $this->ledTV;
    }

    public function getDetails(): string
    {
        return "Memento [LedTV = " . $this->ledTV->getDetails() . "]";
    }
}

class Caretaker
{
    private array $ledTVs = [];

    public function addMemento($ledTVMemento): void
    {
        $this->ledTVs[] = $ledTVMemento;
        echo "LED TV's snapshots maintained by caretaker : " . $ledTVMemento->getDetails() . "\n";
    }

    public function getLEDTVMemento($index)
    {
        return $this->ledTVs[$index];
    }
}

class Originator
{
    private LEDTV $ledTV;

    public function setLEDTV($ledTV): void
    {
        $this->ledTV = $ledTV;
    }

    public function createLEDTVMemento(): LEDTVMemento
    {
        return new LEDTVMemento($this->ledTV);
    }

    public function setMemento($ledTVMemento): void
    {
        $this->ledTV = $ledTVMemento->getLEDTV();
    }

    public function getDetails(): string
    {
        return "Originator [LEDTV = " . $this->ledTV->getDetails() . "]";
    }
}

$originator = new Originator();
$originator->setLEDTV(new LEDTV("42-Inch", 60000, false));

$caretaker = new Caretaker();

$ledTVMemento = $originator->createLEDTVMemento();
$caretaker->addMemento($ledTVMemento);

$originator->setLEDTV(new LEDTV("46-Inch", 80000, true));

$ledTVMemento = $originator->createLEDTVMemento();
$caretaker->addMemento($ledTVMemento);

$originator->setLEDTV(new LEDTV("50-Inch", 100000, true));

echo "Originator's current state : " . $originator->getDetails() . "\n";

echo "\nOriginator restoring to 42-Inch LED TV\n";

$originator->setMemento($caretaker->getLEDTVMemento(0));

echo "\nOriginator current state: " . $originator->getDetails() . "\n";