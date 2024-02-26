<?php

use CreationalPatterns\Builder\Laptops\ConcreteBuilders\ASUSConcreteBuilder;
use CreationalPatterns\Builder\Laptops\ConcreteBuilders\LenovoConcreteBuilder;
use CreationalPatterns\Builder\Laptops\Director\LaptopStore;

require_once 'vendor/autoload.php';

$laptopStore = new LaptopStore();

$laptopBuilder = new ASUSConcreteBuilder();
$laptopStore->buildLaptopConfiguration($laptopBuilder);
$laptopBuilder->laptop->showDetails();

$laptopBuilder = new LenovoConcreteBuilder();
$laptopStore->buildLaptopConfiguration($laptopBuilder);
$laptopBuilder->laptop->showDetails();