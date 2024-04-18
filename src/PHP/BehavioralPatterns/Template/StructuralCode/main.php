<?php

abstract class AbstractClass {
    public function templateMethod(): void
    {
        $this->primitiveOperationA();
        $this->primitiveOperationB();
        echo PHP_EOL;
    }

    public abstract function primitiveOperationA();

    public abstract function primitiveOperationB();
}

class ConcreteClassA extends AbstractClass {
    public function primitiveOperationA(): void
    {
        echo "ConcreteClassA.PrimitiveOperationA" . PHP_EOL;
    }

    public function primitiveOperationB(): void
    {
        echo "ConcreteClassA.PrimitiveOperationB" . PHP_EOL;
    }
}

class ConcreteClassB extends AbstractClass {
    public function primitiveOperationA(): void
    {
        echo "ConcreteClassB.PrimitiveOperationA" . PHP_EOL;
    }

    public function primitiveOperationB(): void
    {
        echo "ConcreteClassB.PrimitiveOperationB" . PHP_EOL;
    }
}

$concreteClassA = new ConcreteClassA();
$concreteClassA->templateMethod();

$concreteClassB = new ConcreteClassB();
$concreteClassB->templateMethod();
