<?php

use BehavioralPatterns\State\VendingMachine\VendingMachine;

require_once 'vendor/autoload.php';

$firstVendingMachine = new VendingMachine([
    new \BehavioralPatterns\State\VendingMachine\Product("SPCOM1", 1, 3),
    new \BehavioralPatterns\State\VendingMachine\Product("SPCOM2", 3, 1)
]);

$firstVendingMachine->selectProduct("SPCOM1");
$firstVendingMachine->insertMoney(1);

echo "========================== || ==========================\n";

$secondVendingMachine = new VendingMachine([
    new \BehavioralPatterns\State\VendingMachine\Product("SPCOM1", 1, 1),
    new \BehavioralPatterns\State\VendingMachine\Product("SPCOM2", 3, 1)
]);

$secondVendingMachine->insertMoney(1);
$secondVendingMachine->selectProduct("SPCOM1");
$secondVendingMachine->insertMoney(0.4);
$secondVendingMachine->insertMoney(1.2);
$secondVendingMachine->selectProduct("SPCOM2");
$secondVendingMachine->insertMoney(3.2);

$secondVendingMachine->refill([
    new \BehavioralPatterns\State\VendingMachine\Product("SPCOM1", 1, 3),
    new \BehavioralPatterns\State\VendingMachine\Product("SPCOM2", 3, 4)
]);

$secondVendingMachine->selectProduct("SPCOM2");
$secondVendingMachine->insertMoney(5.2);

echo "========================== || ==========================\n";

$thirdVendingMachine = new VendingMachine([
    new \BehavioralPatterns\State\VendingMachine\Product("SPCOM1", 1, 3),
    new \BehavioralPatterns\State\VendingMachine\Product("SPCOM2", 3, 1)
]);

$thirdVendingMachine->selectProduct("SPCOM1");
$thirdVendingMachine->insertMoney(1);