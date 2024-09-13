<?php

interface IVisitor {
    public function visitRecipe(Recipe $recipe);

    public function visitButter(Butter $butter);

    public function visitSalt(Salt $salt);

    public function visitFlour(Flour $flour);

    public function visitSugar(Sugar $sugar);
}

class CaloriesCalculator implements IVisitor {
    private int $totalCalories;

    public function __construct() {
        $this->totalCalories = 0;
    }

    public function getTotalCalories(): int
    {
        return $this->totalCalories;
    }

    public function visitRecipe(Recipe $recipe): void
    {
        foreach ($recipe->getIngredients() as $ingredient) {
            $ingredient->accept($this);
        }
    }

    public function visitButter(Butter $butter): void
    {
        $calories = $butter->getFatContent() * $butter->getQuantity();
        $this->totalCalories += $calories;
    }

    public function visitSalt(Salt $salt) {

    }

    public function visitFlour(Flour $flour): void
    {
        $calories = 0;

        switch ($flour->getFlourType()) {
            case 'All-Purpose':
                $calories = 3.64 * $flour->getQuantity();
                break;
            case 'Whole Wheat':
                $calories = 3.39 * $flour->getQuantity();
                break;
        }

        $this->totalCalories += $calories;
    }

    public function visitSugar(Sugar $sugar): void
    {
        $calories = 4.0 * $sugar->getSweetnessLevel() * $sugar->getQuantity();
        $this->totalCalories += $calories;
    }
}

abstract class Element {
    abstract public function accept(IVisitor $visitor);
}

abstract class Ingredient extends Element {
    private string $name;
    private float $quantity;

    public function getName(): string
    {
        return $this->name;
    }

    public function setName($name): void
    {
        $this->name = $name;
    }

    public function getQuantity(): float
    {
        return $this->quantity;
    }

    public function setQuantity($quantity): void
    {
        $this->quantity = $quantity;
    }
}

class Butter extends Ingredient {
    private float $fatContent;

    public function getFatContent(): float
    {
        return $this->fatContent;
    }

    public function setFatContent($fatContent): void
    {
        $this->fatContent = $fatContent;
    }

    public function accept(IVisitor $visitor): void
    {
        $visitor->visitButter($this);
    }
}

class Salt extends Ingredient {
    private bool $isIodized;

    public function getIsIodized(): bool
    {
        return $this->isIodized;
    }

    public function setIsIodized($isIodized): void
    {
        $this->isIodized = $isIodized;
    }

    public function accept(IVisitor $visitor): void
    {
        $visitor->visitSalt($this);
    }
}

class Flour extends Ingredient {
    private string $flourType;

    public function getFlourType(): string
    {
        return $this->flourType;
    }

    public function setFlourType($flourType): void
    {
        $this->flourType = $flourType;
    }

    public function accept(IVisitor $visitor): void
    {
        $visitor->visitFlour($this);
    }
}

class Sugar extends Ingredient {
    private float $sweetnessLevel;

    public function getSweetnessLevel(): float
    {
        return $this->sweetnessLevel;
    }

    public function setSweetnessLevel($sweetnessLevel): void
    {
        $this->sweetnessLevel = $sweetnessLevel;
    }

    public function accept(IVisitor $visitor): void
    {
        $visitor->visitSugar($this);
    }
}

class Recipe extends Element {
    private array $ingredients = [];

    public function getIngredients(): array
    {
        return $this->ingredients;
    }

    public function setIngredients($ingredients): void
    {
        $this->ingredients = $ingredients;
    }

    public function accept(IVisitor $visitor): void
    {
        $visitor->visitRecipe($this);
    }
}

$recipe = new Recipe();

$butter = new Butter();
$butter->setName("Butter");
$butter->setQuantity(100);
$butter->setFatContent(0.81);

$salt = new Salt();
$salt->setName("Salt");
$salt->setQuantity(10);
$salt->setIsIodized(true);

$flour = new Flour();
$flour->setName("Flour");
$flour->setQuantity(500);
$flour->setFlourType("All-Purpose");

$sugar = new Sugar();
$sugar->setName("Sugar");
$sugar->setQuantity(200);
$sugar->setSweetnessLevel(0.5);

$ingredients = [
    $butter,
    $salt,
    $flour,
    $sugar
];

$recipe->setIngredients($ingredients);

$caloriesCalculator = new CaloriesCalculator();
$recipe->accept($caloriesCalculator);

echo "Total Calories: " . $caloriesCalculator->getTotalCalories() . "\n";