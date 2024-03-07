<?php

interface IComponent
{
    public function displayPrice();
}

class Part implements IComponent
{
    private string $name;
    private float $price;

    public function __construct($name, $price)
    {
        $this->name = $name;
        $this->price = $price;
    }

    public function displayPrice(): void
    {
        echo "{$this->name} : {$this->price}" . PHP_EOL;
    }
}

class Composite implements IComponent
{
    private string $name;
    private array $components = array();

    public function __construct($name)
    {
        $this->name = $name;
    }

    public function addComponent(IComponent $component): void
    {
        $this->components[] = $component;
    }

    public function displayPrice(): void
    {
        echo $this->name . PHP_EOL;

        foreach ($this->components as $component) {
            $component->displayPrice();
        }
    }
}

$hardDisk = new Part("Hard Disk", 2000);
$ram = new Part("RAM", 3000);
$cpu = new Part("CPU", 2000);
$mouse = new Part("Mouse", 2000);
$keyboard = new Part("Keyboard", 2000);

$motherBoard = new Composite("Mother Board");
$cabinet = new Composite("Cabinet");
$peripherals = new Composite("Peripherals");
$computer = new Composite("Computer");

$motherBoard->addComponent($cpu);
$motherBoard->addComponent($ram);

$cabinet->addComponent($motherBoard);
$cabinet->addComponent($hardDisk);

$peripherals->addComponent($mouse);
$peripherals->addComponent($keyboard);

$computer->addComponent($cabinet);
$computer->addComponent($peripherals);

$computer->displayPrice();
echo PHP_EOL;

$keyboard->displayPrice();
echo PHP_EOL;

$cabinet->displayPrice();

