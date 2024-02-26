<?php

class Hamburger
{
    private string $hamburgerName;
    private array $ingredients = [];

    public function __construct($hamburgerName)
    {
        $this->hamburgerName = $hamburgerName;
    }

    public function __get($key)
    {
        return $this->ingredients[$key];
    }

    public function __set($key, $value)
    {
        $this->ingredients[$key] = $value;
    }

    public function showIngredients(): void
    {
        echo "\n" . str_repeat('-', 40);
        echo "\nHamburger: {$this->hamburgerName}";
        echo "\n Bun: {$this->ingredients['bun']}";
        echo "\n Patty: {$this->ingredients['patty']}";
        echo "\n Sauce: {$this->ingredients['sauce']}";
        echo "\n Cheese: {$this->ingredients['cheese']}";
        echo "\n Veggies: {$this->ingredients['veggies']}";
        echo "\n Extras: {$this->ingredients['extras']}";
    }
}

abstract class HamburgerBuilder
{
    protected Hamburger $hamburger;

    public function getHamburger(): Hamburger
    {
        return $this->hamburger;
    }

    public abstract function addBun();

    public abstract function addPatty();

    public abstract function addSauce();

    public abstract function addCheese();

    public abstract function addVeggies();

    public abstract function addExtras();
}

class ClassicHamburgerBuilder extends HamburgerBuilder
{
    public function __construct()
    {
        $this->hamburger = new Hamburger("Classic Burger");
    }

    public function addBun(): void
    {
        $this->hamburger->bun = "Regular sesame bun";
    }

    public function addPatty(): void
    {
        $this->hamburger->patty = "Beef patty";
    }

    public function addSauce(): void
    {
        $this->hamburger->sauce = "Ketchup and mustard";
    }

    public function addCheese(): void
    {
        $this->hamburger->cheese = "American cheese";
    }

    public function addVeggies(): void
    {
        $this->hamburger->veggies = "Lettuce, tomato, onion, pickles";
    }

    public function addExtras(): void
    {
        $this->hamburger->extras = "Bacon";
    }
}

class VeggieHamburgerBuilder extends HamburgerBuilder
{
    public function __construct()
    {
        $this->hamburger = new Hamburger("Veggie Burger");
    }

    public function addBun(): void
    {
        $this->hamburger->bun = "Whole wheat bun";
    }

    public function addPatty(): void
    {
        $this->hamburger->patty = "Vegetarian patty";
    }

    public function addSauce(): void
    {
        $this->hamburger->sauce = "Mayonnaise";
    }

    public function addCheese(): void
    {
        $this->hamburger->cheese = "Swiss cheese";
    }

    public function addVeggies(): void
    {
        $this->hamburger->veggies = "Lettuce, tomato, onion, avocado";
    }

    public function addExtras(): void
    {
        $this->hamburger->extras = "Grilled mushrooms";
    }
}

class BurgerKing
{
    public function makeHamburger(HamburgerBuilder $hamburgerBuilder): void
    {
        $hamburgerBuilder->addBun();
        $hamburgerBuilder->addPatty();
        $hamburgerBuilder->addSauce();
        $hamburgerBuilder->addCheese();
        $hamburgerBuilder->addVeggies();
        $hamburgerBuilder->addExtras();
    }
}

$burgerKing = new BurgerKing();

$classicHamburgerBuilder = new ClassicHamburgerBuilder();
$burgerKing->makeHamburger($classicHamburgerBuilder);
$classicHamburgerBuilder->getHamburger()->showIngredients();

$veggieHamburgerBuilder = new VeggieHamburgerBuilder();
$burgerKing->makeHamburger($veggieHamburgerBuilder);
$veggieHamburgerBuilder->getHamburger()->showIngredients();