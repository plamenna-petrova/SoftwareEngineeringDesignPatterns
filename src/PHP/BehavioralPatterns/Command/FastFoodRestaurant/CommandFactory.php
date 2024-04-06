<?php

namespace BehavioralPatterns\Command\FastFoodRestaurant;

use BehavioralPatterns\Command\FastFoodRestaurant\Commands\AddMenuItemCommand;
use BehavioralPatterns\Command\FastFoodRestaurant\Commands\ModifyMenuItemCommand;
use BehavioralPatterns\Command\FastFoodRestaurant\Commands\OrderCommand;
use BehavioralPatterns\Command\FastFoodRestaurant\Commands\RemoveMenuItemCommand;

class CommandFactory {
    public function getCommand(int $commandOption): OrderCommand {
        return match ($commandOption) {
            2 => new ModifyMenuItemCommand(),
            3 => new RemoveMenuItemCommand(),
            default => new AddMenuItemCommand(),
        };
    }
}