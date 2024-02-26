<?php

abstract class Builder {
    public abstract function buildPartA();

    public abstract function buildPartB();

    public abstract function getResult();
}

class Product {
    private array $parts = array();

    public function add($part): void
    {
        $this->parts[] = $part;
    }

    public function show(): void
    {
        echo "\nProduct Parts" . str_repeat('-', 10) . PHP_EOL;

        foreach ($this->parts as $part) {
            echo $part . PHP_EOL;
        }
    }
}

class ConcreteBuilder1 extends Builder {
    private Product $product;

    public function __construct() {
        $this->product = new Product();
    }

    public function buildPartA(): void
    {
        $this->product->add("PartA");
    }

    public function buildPartB(): void
    {
        $this->product->add("PartB");
    }

    public function getResult(): Product
    {
        return $this->product;
    }
}

class ConcreteBuilder2 extends Builder {
    private Product $product;

    public function __construct() {
        $this->product = new Product();
    }

    public function buildPartA(): void
    {
        $this->product->add("PartX");
    }

    public function buildPartB(): void
    {
        $this->product->add("PartY");
    }

    public function getResult(): Product
    {
        return $this->product;
    }
}

class Director {
    public function construct(Builder $builder): void
    {
        $builder->buildPartA();
        $builder->buildPartB();
    }
}

$director = new Director();

$firstBuilder = new ConcreteBuilder1();
$secondBuilder = new ConcreteBuilder2();

$director->construct($firstBuilder);
$firstProduct = $firstBuilder->getResult();
$firstProduct->show();

$director->construct($secondBuilder);
$secondProduct = $secondBuilder->getResult();
$secondProduct->show();