<?php

namespace BehavioralPatterns\Command\FastFoodRestaurant;

use BehavioralPatterns\Command\FastFoodRestaurant\Commands\FastFoodOrder;
use BehavioralPatterns\Command\FastFoodRestaurant\Commands\OrderCommand;
use BehavioralPatterns\Command\FastFoodRestaurant\Models\MenuItem;

class Patron {
    private OrderCommand $orderCommand;
    private MenuItem $menuItem;
    private FastFoodOrder $fastFoodOrder;

    public function __construct() {
        $this->fastFoodOrder = new FastFoodOrder();
    }

    public function setCommand(int $commandOption): void {
        $commandFactory = new CommandFactory();
        $this->orderCommand = $commandFactory->getCommand($commandOption);
    }

    public function setMenuItem(MenuItem $menuItem): void {
        $this->menuItem = $menuItem;
    }

    public function executeFastFoodOrderCommand(): void {
        $this->fastFoodOrder->executeCommand($this->orderCommand, $this->menuItem);
    }

    public function showCurrentOrder(): void {
        $this->fastFoodOrder->showCurrentItems();
    }
}