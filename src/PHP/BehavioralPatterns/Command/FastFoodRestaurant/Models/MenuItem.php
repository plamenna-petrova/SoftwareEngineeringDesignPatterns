<?php

namespace BehavioralPatterns\Command\FastFoodRestaurant\Models;

class MenuItem {
    public string $name;
    public float $amount;
    public float $price;

    public function __construct($name, $amount, $price) {
        $this->name = $name;
        $this->amount = $amount;
        $this->price = $price;
    }

    public function display(): void
    {
        echo "\nName: " . $this->name . "\n";
        echo "Amount: " . $this->amount . "\n";
        echo "Price: $" . $this->price . "\n";
    }
}