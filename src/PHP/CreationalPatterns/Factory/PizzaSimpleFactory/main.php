
<?php

interface IPizza
{
    public function showDetails(): string;
}

class Neapolitan implements IPizza
{
    public function showDetails(): string
    {
        return "Neapolitan is the original pizza. This delicious pie dates all " .
            "the way back to the 18th century in Naples, Italy. ";
    }
}

class Funghi implements IPizza
{
    public function showDetails(): string
    {
        return "A pizza funghi, or better known as a mushroom pizza is a world-famous pizza. " .
            "It doesn't need many ingredients, recipe for 2 pizzas.";
    }
}

class Pepperoni implements IPizza
{
    public function showDetails(): string
    {
        return "Pepperoni is a variety of spicy salami made from cured pork and beef seasoned " .
            "with paprika and chili peppers.";
    }
}

class PizzaType
{
    const Neapolitan = 0;
    const Pepperoni = 1;
    const Funghi = 2;
}

interface IPizzaFactory
{
    public function createPizza(int $pizzaType): IPizza;
}

class PizzaFactory implements IPizzaFactory
{
    public function createPizza(int $pizzaType): IPizza
    {
        return match ($pizzaType) {
            PizzaType::Neapolitan => new Neapolitan(),
            PizzaType::Pepperoni => new Pepperoni(),
            PizzaType::Funghi => new Funghi(),
            default => throw new InvalidArgumentException("Invalid pizza type"),
        };
    }
}

try {
    $pizzaFactory = new PizzaFactory();
    $pepperoniPizza = $pizzaFactory->createPizza(PizzaType::Pepperoni);
    echo $pepperoniPizza->showDetails();
} catch (Exception $exception) {
    echo $exception->getMessage();
}

