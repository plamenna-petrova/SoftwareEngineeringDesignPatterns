<?php

abstract class Product {
}

class ConcreteProductA extends Product {
}

class ConcreteProductB extends Product {
}

abstract class Creator {
    public abstract function createProduct(): Product;
}

class ConcreteCreatorA extends Creator {
    public function createProduct(): Product {
        return new ConcreteProductA();
    }
}

class ConcreteCreatorB extends Creator {
    public function createProduct(): Product {
        return new ConcreteProductB();
    }
}

$creators = [
    new ConcreteCreatorA(),
    new ConcreteCreatorB(),
];

foreach ($creators as $creator) {
    $createdProduct = $creator->createProduct();
    echo "Created: " . get_class($createdProduct) . PHP_EOL;
}