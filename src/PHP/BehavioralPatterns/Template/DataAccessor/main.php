<?php

abstract class DataAccessor {
    abstract public function connect();

    abstract public function select();

    abstract public function process($top);

    abstract public function disconnect();

    public function run($top): void
    {
        $this->connect();
        $this->select();
        $this->process($top);
        $this->disconnect();
    }
}

class Categories extends DataAccessor {
    private array $categories;

    public function connect(): void
    {
        $this->categories = [];
    }

    public function select(): void
    {
        $this->categories = ["Red", "Green", "Blue", "Orange", "Purple", "White", "Black"];
    }

    public function process($top): void
    {
        echo "Categories ---- " . PHP_EOL;

        foreach (array_slice($this->categories, 0, $top) as $category) {
            echo $category . PHP_EOL;
        }

        echo PHP_EOL;
    }

    public function disconnect(): void
    {
        $this->categories = [];
    }
}

class Products extends DataAccessor {
    private array $products;

    public function connect(): void
    {
        $this->products = [];
    }

    public function select(): void
    {
        $this->products = ["Car", "Bike", "Boat", "Truck", "Moped", "Rollerskate", "Stroller"];
    }

    public function process($top): void
    {
        echo "Products ---- " . PHP_EOL;

        foreach (array_slice($this->products, 0, $top) as $product) {
            echo $product . PHP_EOL;
        }
    }

    public function disconnect(): void
    {
        $this->products = [];
    }
}

$categories = new Categories();
$categories->run(5);

$products = new Products();
$products->run(3);
