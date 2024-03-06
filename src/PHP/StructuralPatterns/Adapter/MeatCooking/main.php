<?php

class Meat
{
    protected string $meatName;
    protected float $safeCookingTemperatureInFahrenheit;
    protected float $safeCookingTemperatureInCelsius;
    protected int $caloriesPerOunce;
    protected float $caloriesPerGram;
    protected float $proteinPerOunce;
    protected float $proteinPerGram;

    public function __construct(string $meatName)
    {
        $this->meatName = $meatName;
    }

    public function loadData(): void
    {
        echo "\nMeat: {$this->meatName} " . str_repeat('-', 7) . PHP_EOL;
    }
}

class MeatDetails extends Meat
{
    private MeatDatabase $meatDatabase;

    public function __construct(string $meatName)
    {
        parent::__construct($meatName);
        $this->meatDatabase = new MeatDatabase();
    }

    public function loadData(): void
    {
        $this->safeCookingTemperatureInFahrenheit = $this->meatDatabase->getSafeCookingTemperature($this->meatName);
        $this->safeCookingTemperatureInCelsius = $this->fahrenheitToCelsius($this->safeCookingTemperatureInFahrenheit);
        $this->caloriesPerOunce = $this->meatDatabase->getCaloriesPerOunce($this->meatName);
        $this->caloriesPerGram = $this->poundsToGrams($this->caloriesPerOunce);
        $this->proteinPerOunce = $this->meatDatabase->getProteinPerOunce($this->meatName);
        $this->proteinPerGram = $this->poundsToGrams($this->proteinPerOunce);

        parent::loadData();

        $meatDetails = sprintf(
            " Safe Cooking Temperature (Fahrenheit) : %.2f\n Safe Cooking Temperature (Celsius) : %.2f\n Calories per Ounce: %.2f\n Calories per Gram: %.2f\n Protein per Ounce: %.2f\n Protein per Gram: %.2f\n",
            $this->safeCookingTemperatureInFahrenheit,
            $this->safeCookingTemperatureInCelsius,
            $this->caloriesPerOunce,
            $this->caloriesPerGram,
            $this->proteinPerOunce,
            $this->proteinPerGram
        );

        echo $meatDetails;
    }

    private function fahrenheitToCelsius(float $temperatureInFahrenheit): float
    {
        return ($temperatureInFahrenheit - 32) * 0.55555;
    }

    private function poundsToGrams(float $pounds): float
    {
        return $pounds * 0.0283 / 1000;
    }
}

class MeatDatabase
{
    public function getSafeCookingTemperature(string $meat): float
    {
        return match (strtolower($meat)) {
            "beef", "pork" => 145.0,
            "chicken", "turkey" => 165.0,
            default => 165.0,
        };
    }

    public function getCaloriesPerOunce(string $meat): int
    {
        return match (strtolower($meat)) {
            "beef" => 71,
            "pork" => 69,
            "chicken" => 66,
            "turkey" => 38,
            default => 0,
        };
    }

    public function getProteinPerOunce(string $meat): float
    {
        return match (strtolower($meat)) {
            "beef" => 7.33,
            "pork" => 7.67,
            "chicken" => 8.57,
            "turkey" => 8.5,
            default => 0.0,
        };
    }
}

$unknownBeef = new Meat("Beef");
$unknownBeef->loadData();

$beef = new MeatDetails("Beef");
$beef->loadData();

$chicken = new MeatDetails("Chicken");
$chicken->loadData();

$turkey = new MeatDetails("Turkey");
$turkey->loadData();