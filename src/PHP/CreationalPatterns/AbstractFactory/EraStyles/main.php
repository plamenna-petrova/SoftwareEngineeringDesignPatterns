<?php

use CreationalPatterns\AbstractFactory\EraStyles\Client\Era;
use CreationalPatterns\AbstractFactory\EraStyles\ConcreteFactories\ClothingFactory;
use CreationalPatterns\AbstractFactory\EraStyles\ConcreteFactories\HouseFactory;
use CreationalPatterns\AbstractFactory\EraStyles\ConcreteFactories\ShipFactory;

require_once 'vendor/autoload.php';

$objectsCount = 1;

echo "Please select your object type number: $objectsCount\n";
echo "[H]House, [S]Ship, [C]Clothing\n";

$objectType = strtoupper(readline());

echo "\n";

while ($objectType !== 'E') {
    $factory = null;

    switch ($objectType) {
        case 'H':
            $factory = new HouseFactory();
            break;
        case 'S':
            $factory = new ShipFactory();
            break;
        case 'C':
            $factory = new ClothingFactory();
            break;
    }

    echo "Enter era name: \n";
    echo "[M]Medieval, [R]Renaissance, [V]Victorian Era\n";

    $eraCharacter = strtoupper(readline());

    echo "\n";

    $era = new Era($factory, $eraCharacter);
    echo "Object Number #$objectsCount ";
    $era->Info();

    echo str_repeat('-', 50) . "\n";

    echo "Please select your object type: " . ++$objectsCount . "\n";
    echo "[H]House, [S]Ship, [C]Clothing\n";

    $objectType = strtoupper(readline());

    echo "\n";
}