<?php

namespace BehavioralPatterns\Command\FastFoodRestaurant\Commands;

use BehavioralPatterns\Command\FastFoodRestaurant\Models\MenuItem;

class RemoveMenuItemCommand extends OrderCommand {
    public function execute(array &$fastFoodOrderMenuItems, MenuItem $menuItem): void
    {
        foreach ($fastFoodOrderMenuItems as $key => $fastFoodOrderMenuItem) {
            if ($fastFoodOrderMenuItem->name === $menuItem->name) {
                unset($fastFoodOrderMenuItems[$key]);
                break;
            }
        }

        $fastFoodOrderMenuItems = array_values($fastFoodOrderMenuItems);
    }
}