<?php

use CreationalPatterns\AbstractFactory\Furniture\ConcreteFactories\ClassicFurnitureFactory;
use CreationalPatterns\AbstractFactory\Furniture\ConcreteFactories\ContemporaryFurnitureFactory;
use CreationalPatterns\AbstractFactory\Furniture\ConcreteFactories\ScandinavianFurnitureFactory;

require_once 'vendor/autoload.php';

echo "Please select your furniture style:" . PHP_EOL;
echo "[1]Classic, [2]Contemporary, [3]Scandinavian" . PHP_EOL;

$line = readline();

if (is_numeric($line)) {
    $furnitureFactory = null;

    $furnitureStyle = (int)$line;

    switch ($furnitureStyle) {
        case 1:
            $furnitureFactory = new ClassicFurnitureFactory();
            break;
        case 2:
            $furnitureFactory = new ContemporaryFurnitureFactory();
            break;
        case 3:
            $furnitureFactory = new ScandinavianFurnitureFactory();
            break;
    }

    echo "Please select your furniture type:" . PHP_EOL;
    echo "[1]Cabinet, [2]Chair, [3]Dining Table" . PHP_EOL;

    $line = readline();

    if (is_numeric($line)) {
        $furniture = null;

        $furnitureType = (int)$line;

        switch ($furnitureType) {
            case 1:
                $furniture = $furnitureFactory->createCabinet();
                break;
            case 2:
                $furniture = $furnitureFactory->createChair();
                break;
            case 3:
                $furniture = $furnitureFactory->createDiningTable();
                break;
        }

        $furniture->showFurnitureStyle();
    }
}