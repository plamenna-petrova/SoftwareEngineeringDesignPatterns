<?php

namespace BehavioralPatterns\Command\FastFoodRestaurant\Commands;

use BehavioralPatterns\Command\FastFoodRestaurant\Models\MenuItem;

class ModifyMenuItemCommand extends OrderCommand {
    public function execute(array &$fastFoodOrderMenuItems, MenuItem $menuItem): void
    {
        foreach ($fastFoodOrderMenuItems as &$fastFoodOrderMenuItem) {
            if ($fastFoodOrderMenuItem->name === $menuItem->name) {
                $fastFoodOrderMenuItem->price = $menuItem->price;
                $fastFoodOrderMenuItem->amount = $menuItem->amount;
                break;
            }
        }
    }
}
