<?php

namespace BehavioralPatterns\Command\FastFoodRestaurant\Commands;

use BehavioralPatterns\Command\FastFoodRestaurant\Models\MenuItem;

class AddMenuItemCommand extends OrderCommand {
    public function execute(array &$fastFoodOrderMenuItems, MenuItem $menuItem): void
    {
        $fastFoodOrderMenuItems[] = $menuItem;
    }
}
