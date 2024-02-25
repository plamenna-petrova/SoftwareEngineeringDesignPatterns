<?php

abstract class RecipeFactory {
    abstract public function createSandwich();
    abstract public function createDessert();
}

class AdultCuisine extends RecipeFactory {
    public function createSandwich() {
        return new BLT();
    }

    public function createDessert() {
        return new CremeBrule();
    }
}

class KidsCuisine extends RecipeFactory {
    public function createSandwich() {
        return new GrilledCheese();
    }

    public function createDessert() {
        return new IceCreamSundae();
    }
}

abstract class Sandwich {

}

abstract class Dessert {

}

class BLT extends Sandwich {

}

class CremeBrule extends Dessert {

}

class GrilledCheese extends Sandwich {

}

class IceCreamSundae extends Dessert {

}

echo "Who are you? (A)dult or (C)hild? ";
$input = trim(fgets(STDIN));

$recipeFactory = null;

switch (strtoupper($input)) {
    case 'A':
        $recipeFactory = new AdultCuisine();
        break;
    case 'C':
        $recipeFactory = new KidsCuisine();
        break;
    default:
        throw new Exception("Not implemented");
}

$sandwich = $recipeFactory->createSandwich();
$dessert = $recipeFactory->createDessert();

echo "\nSandwich: " . get_class($sandwich) . PHP_EOL;
echo "Dessert: " . get_class($dessert) . PHP_EOL;