<?php

interface IColdDrink {
    public function getPrice();
    public function getDescription();
}

class CocaCola implements IColdDrink {
    public function getPrice(): int
    {
        return 2;
    }

    public function getDescription(): string
    {
        return "simple cola";
    }
}

abstract class ColdDrinkDecorator implements IColdDrink {
    protected IColdDrink $coldDrink;

    public function __construct(IColdDrink $coldDrink) {
        $this->coldDrink = $coldDrink;
    }

    public function getPrice() {
        return $this->coldDrink->getPrice();
    }

    public function getDescription() {
        return $this->coldDrink->getDescription();
    }
}

class IceCola extends ColdDrinkDecorator {
    public function __construct(IColdDrink $coldDrink) {
        parent::__construct($coldDrink);
    }

    public function getPrice() {
        return $this->coldDrink->getPrice() + 1;
    }

    public function getDescription(): string
    {
        return $this->coldDrink->getDescription() . ", mixed up with ice cream";
    }
}

class CubaLibreCocktail extends ColdDrinkDecorator {
    public function __construct(IColdDrink $coldDrink) {
        parent::__construct($coldDrink);
    }

    public function getPrice() {
        return $this->coldDrink->getPrice() + 3;
    }

    public function getDescription(): string
    {
        return $this->coldDrink->getDescription() . ", mixed up with some rum,\nice and lemon";
    }
}

class ColaMilkshake extends ColdDrinkDecorator {
    public function __construct(IColdDrink $coldDrink) {
        parent::__construct($coldDrink);
    }

    public function getPrice() {
        return $this->coldDrink->getPrice() + 2;
    }

    public function getDescription(): string
    {
        return $this->coldDrink->getDescription() . ",\nand milk";
    }
}

$drinkInfo = "Print drink info =================================\n";

$cocaCola = new CocaCola();
echo $drinkInfo;
echo "Price : " . number_format($cocaCola->getPrice(), 2) . "\n";
echo "Description : " . $cocaCola->getDescription() . "\n";
echo str_repeat('=', 50) . "\n";

$iceCola = new IceCola($cocaCola);
echo $drinkInfo;
echo "Price : " . number_format($iceCola->getPrice(), 2) . "\n";
echo "Description : " . $iceCola->getDescription() . "\n";
echo str_repeat('=', 50) . "\n";

$cubaLibreCocktail = new CubaLibreCocktail($cocaCola);
echo $drinkInfo;
echo "Price : " . number_format($cubaLibreCocktail->getPrice(), 2) . "\n";
echo "Description : " . $cubaLibreCocktail->getDescription() . "\n";
echo str_repeat('=', 50) . "\n";

$colaMilkShake = new ColaMilkshake($iceCola);
echo $drinkInfo;
echo "Price : " . number_format($colaMilkShake->getPrice(), 2) . "\n";
echo "Description : " . $colaMilkShake->getDescription() . "\n";