<?php

abstract class ColorPrototype {
    abstract public function clone();
}

class ColorConcretePrototype extends ColorPrototype {
    private int $red;
    private int $green;
    private int $blue;

    public function __construct($red, $green, $blue) {
        $this->red = $red;
        $this->green = $green;
        $this->blue = $blue;
    }

    public function clone(): ColorPrototype|static
    {
        return clone $this;
    }

    public function __toString() {
        return sprintf("Cloned color RGB: %3d,%3d,%3d", $this->red, $this->green, $this->blue);
    }
}

class ColorManager {
    private array $colors = [];

    public function __get($key) {
        return $this->colors[$key];
    }

    public function __set($key, $value) {
        $this->colors[$key] = $value;
    }
}

$colorManager = new ColorManager();

$colorManager->red = new ColorConcretePrototype(255, 0, 0);
$colorManager->green = new ColorConcretePrototype(0, 255, 0);
$colorManager->blue = new ColorConcretePrototype(0, 0, 255);

$colorManager->angry = new ColorConcretePrototype(255, 54, 0);
$colorManager->peace = new ColorConcretePrototype(128, 211, 128);
$colorManager->flame = new ColorConcretePrototype(211, 34, 20);

$redColor = clone $colorManager->red;
$peaceColor = clone $colorManager->peace;
$flameColor = clone $colorManager->flame;

echo $redColor . PHP_EOL;
echo $peaceColor . PHP_EOL;
echo $flameColor . PHP_EOL;