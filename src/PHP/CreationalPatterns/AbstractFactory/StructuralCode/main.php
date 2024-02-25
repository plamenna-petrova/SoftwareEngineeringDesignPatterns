<?php

abstract class AbstractFactory {
    abstract public function createProductA();
    abstract public function createProductB();
}

class ConcreteFactory1 extends AbstractFactory {
    public function createProductA() {
        return new ProductA1();
    }

    public function createProductB() {
        return new ProductB1();
    }
}

class ConcreteFactory2 extends AbstractFactory {
    public function createProductA() {
        return new ProductA2();
    }

    public function createProductB() {
        return new ProductB2();
    }
}

abstract class AbstractProductA {

}

abstract class AbstractProductB {
    abstract public function interact(AbstractProductA $abstractProductA);
}

class ProductA1 extends AbstractProductA {

}

class ProductB1 extends AbstractProductB {
    public function interact(AbstractProductA $abstractProductA) {
        echo get_class($this) . " interacts with " . get_class($abstractProductA) . PHP_EOL;
    }
}

class ProductA2 extends AbstractProductA {

}

class ProductB2 extends AbstractProductB {
    public function interact(AbstractProductA $abstractProductA) {
        echo get_class($this) . " interacts with " . get_class($abstractProductA) . PHP_EOL;
    }
}

class Client {
    private $abstractProductA;
    private $abstractProductB;

    public function __construct(AbstractFactory $abstractFactory) {
        $this->abstractProductA = $abstractFactory->createProductA();
        $this->abstractProductB = $abstractFactory->createProductB();
    }

    public function run() {
        $this->abstractProductB->interact($this->abstractProductA);
    }
}

$concreteFactory1 = new ConcreteFactory1();
$client1 = new Client($concreteFactory1);
$client1->run();

$concreteFactory2 = new ConcreteFactory2();
$client2 = new Client($concreteFactory2);
$client2->run();
