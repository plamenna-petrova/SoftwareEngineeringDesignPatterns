<?php

interface IServant {
    public function getName();
    public function getWage();
    public function getRole();
    public function getProductivity();
    public function getReliability();
}

class Housemaid implements IServant {
    private string $name;
    private float $wage;
    private string $role;
    private int $productivity;
    private int $reliability;

    public function __construct($name, $wage, $role, $productivity, $reliability) {
        $this->name = $name;
        $this->wage = $wage;
        $this->role = $role;
        $this->productivity = $productivity;
        $this->reliability = $reliability;
    }

    public function getName() {
        return $this->name;
    }

    public function getWage() {
        return $this->wage;
    }

    public function getRole() {
        return $this->role;
    }

    public function getProductivity() {
        return $this->productivity;
    }

    public function getReliability() {
        return $this->reliability;
    }
}

class Cook implements IServant {
    private string $name;
    private float $wage;
    private string $role;
    private int $productivity;
    private int $reliability;

    public function __construct($name, $wage, $role, $productivity, $reliability) {
        $this->name = $name;
        $this->wage = $wage;
        $this->role = $role;
        $this->productivity = $productivity;
        $this->reliability = $reliability;
    }

    public function getName() {
        return $this->name;
    }

    public function getWage() {
        return $this->wage;
    }

    public function getRole() {
        return $this->role;
    }

    public function getProductivity() {
        return $this->productivity;
    }

    public function getReliability() {
        return $this->reliability;
    }
}

class RoyalCourt {
    protected array $servants;

    public function __construct() {
        $this->servants = [];
    }

    public function addServant(IServant $servant): void
    {
        $this->servants[] = $servant;
    }

    public function removeServant(IServant $servant): void
    {
        if ($servant->getReliability() < 50) {
            echo "{$servant->getName()} will be fired\n";
            $this->servants = array_filter($this->servants, function ($s) use ($servant) {
                return $s !== $servant;
            });
        } else {
            echo "{$servant->getName()} won't be fired\n";
        }
    }

    public function getServantsWages(): int
    {
        return array_reduce($this->servants, function ($sum, $servant) {
            return $sum + $servant->getWage();
        }, 0);
    }

    public function getAverageProductivity(): float|int
    {
        $averageProductivity = array_reduce($this->servants, function ($sum, $servant) {
                return $sum + $servant->getProductivity();
            }, 0) / count($this->servants);

        if ($averageProductivity < 80) {
            echo "Servants need to put more effort into their tasks\n";
        } else {
            echo "Servants have done a great job so far...\n";
        }

        return $averageProductivity;
    }

    public function getMinimumReliability(): string
    {
        $minReliability = PHP_INT_MAX;
        $minReliabilityServant = null;

        foreach ($this->servants as $servant) {
            if ($servant->getReliability() < $minReliability) {
                $minReliability = $servant->getReliability();
                $minReliabilityServant = $servant;
            }
        }

        if ($minReliabilityServant !== null) {
            return "The servant {$minReliabilityServant->getName()} with role -- " .
                "{$minReliabilityServant->getRole()} -- has the minimum reliability of " .
                "{$minReliabilityServant->getReliability()} %";
        } else {
            return "No servants found";
        }
    }

    public function getMaximumReliability(): string
    {
        $maxReliability = PHP_INT_MIN;
        $maxReliabilityServant = null;

        foreach ($this->servants as $servant) {
            if ($servant->getReliability() > $maxReliability) {
                $maxReliability = $servant->getReliability();
                $maxReliabilityServant = $servant;
            }
        }

        if ($maxReliabilityServant !== null) {
            return "The servant {$maxReliabilityServant->getName()} with role -- " .
                "{$maxReliabilityServant->getRole()} -- has the maximum reliability of " .
                "{$maxReliabilityServant->getReliability()} %";
        } else {
            return "No servants found";
        }
    }

    public function toBePromoted(): string
    {
        $promotionList = '';

        foreach ($this->servants as $servant) {
            if ($servant->getProductivity() >= 60) {
                $newWage = $servant->getWage() + 50;
                $promotionList .= "{$servant->getName()} with role {$servant->getRole()} will be promoted with new wage of {$newWage}\n";
            }
        }

        return $promotionList;
    }
}

$firstHouseMaid = new Housemaid("Emma", 150, "cleans the hall", 65, 70);
$secondHouseMaid = new Housemaid("Isabella", 180, "cleans the kitchen", 70, 30);
$thirdHouseMaid = new Housemaid("Gilda", 200, "cleans the guest rooms", 50, 90);
$fourthHouseMaid = new Housemaid("Grace", 260, "cleans the bedrooms", 70, 80);

$firstCook = new Cook("Norman", 300, "prepares breakfast Mondays and Fridays", 80, 90);
$secondCook = new Cook("Ray", 280, "prepares dinner Wednesdays and Saturdays", 75, 40);
$thirdCook = new Cook("Don", 250, "prepares desserts", 60, 95);
$fourthCook = new Cook("Phil", 310, "prepares special meals", 90, 90);

$royalCourt = new RoyalCourt();

$royalCourt->addServant($firstHouseMaid);
$royalCourt->addServant($secondHouseMaid);
$royalCourt->addServant($thirdHouseMaid);
$royalCourt->addServant($fourthHouseMaid);
$royalCourt->addServant($firstCook);
$royalCourt->addServant($secondCook);
$royalCourt->addServant($thirdCook);
$royalCourt->addServant($fourthCook);

$royalCourt->removeServant($firstHouseMaid);
$royalCourt->removeServant($secondHouseMaid);
$royalCourt->removeServant($thirdHouseMaid);
$royalCourt->removeServant($fourthHouseMaid);
$royalCourt->removeServant($firstCook);
$royalCourt->removeServant($secondCook);
$royalCourt->removeServant($thirdCook);
$royalCourt->removeServant($fourthCook);

echo "The sum of servants' wages for all servants is: {$royalCourt->getServantsWages()}\n";
echo "The average productivity for all servants is: " . number_format($royalCourt->getAverageProductivity(), 2) . "\n";
echo "The minimum reliability among all servants is: {$royalCourt->getMinimumReliability()}\n";
echo "The maximum reliability among all servants is: {$royalCourt->getMaximumReliability()}\n";
echo "Servants to be promoted:\n{$royalCourt->toBePromoted()}";