<?php

namespace BehavioralPatterns\Command\FastFoodRestaurant\Commands;

use BehavioralPatterns\Command\FastFoodRestaurant\Models\MenuItem;

abstract class OrderCommand {
    public abstract function execute(array &$fastFoodOrderMenuItems, MenuItem $menuItem);
}
