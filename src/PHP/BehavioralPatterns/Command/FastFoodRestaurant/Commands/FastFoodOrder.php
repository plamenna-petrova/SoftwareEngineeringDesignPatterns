<?php

namespace BehavioralPatterns\Command\FastFoodRestaurant\Commands;

use BehavioralPatterns\Command\FastFoodRestaurant\Models\MenuItem;

class FastFoodOrder {
    private array $fastFoodOrderMenuItems = [];

    public function __construct() {
        $this->fastFoodOrderMenuItems = [];
    }

    public function executeCommand(OrderCommand $orderCommand, MenuItem $menuItem): void {
        $orderCommand->execute($this->fastFoodOrderMenuItems, $menuItem);
    }

    public function showCurrentItems(): void {
        foreach ($this->fastFoodOrderMenuItems as $menuItem) {
            $menuItem->display();
        }
        echo str_repeat('-', 15) . PHP_EOL;
    }
}