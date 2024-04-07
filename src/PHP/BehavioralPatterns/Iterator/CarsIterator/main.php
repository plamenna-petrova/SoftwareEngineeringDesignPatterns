<?php

interface CustomIterator
{
    public function moveNext();

    public function getCurrentItem();
}

class ConcreteIteratorForItems implements CustomIterator
{
    private array $data;
    private int $currentPosition = -1;

    public function __construct(array $data)
    {
        $this->data = $data;
    }

    public function getCurrentItem()
    {
        return $this->data[$this->currentPosition];
    }

    public function moveNext(): bool
    {
        $this->currentPosition++;
        return $this->currentPosition < count($this->data);
    }
}

interface IIterable
{
    public function createIterator();
}

class Collection implements IIterable
{
    private array $items;

    public function __construct(array $items)
    {
        $this->items = $items;
    }

    public function createIterator(): CustomIterator
    {
        return new ConcreteIteratorForItems($this->items);
    }
}

abstract class Company implements IIterable
{
    public abstract function createIterator();
}

class Car
{
    private string $name;

    public function __construct(string $name)
    {
        $this->name = $name;
    }

    public function __toString(): string
    {
        return $this->name;
    }
}

class Ferrari implements IteratorAggregate
{
    private array $cars = [];

    public function addCar(Car $car): void
    {
        $this->cars[] = $car;
    }

    public function getIterator(): Iterator
    {
        return new ArrayIterator($this->cars);
    }
}

class Ford implements IteratorAggregate
{
    private array $cars;

    public function __construct(array $cars)
    {
        $this->cars = $cars;
    }

    public function getIterator(): Iterator
    {
        return new ArrayIterator($this->cars);
    }
}

class CarDealer
{
    private array $carCompanies;

    public function __construct(array ...$carCompanies)
    {
        $this->carCompanies = $carCompanies;
    }

    public function printCars(): void
    {
        foreach ($this->carCompanies as $company) {
            if ($company instanceof Ferrari) {
                foreach ($company as $car) {
                    echo $car . "\n";
                }
            } elseif ($company instanceof Ford) {
                foreach ($company as $car) {
                    echo $car->__toString() . "\n";
                }
            }
        }
    }
}


class Node
{
    public int $value;
    public ?Node $left = null;
    public ?Node $right = null;

    public function __construct(int $value)
    {
        $this->value = $value;
    }
}

abstract class BinaryTreeIterator implements CustomIterator
{
    protected array $queue = [];
    protected ?Node $root;
    protected ?Node $currentItem = null;
    protected bool $traversed = false;

    public function __construct(?Node $root)
    {
        $this->root = $root;
    }

    abstract protected function traverse(Node $node);

    public function moveNext(): bool
    {
        if (!$this->traversed) {
            if ($this->root !== null) {
                $this->traverse($this->root);
            }
            $this->traversed = true;
        }

        $this->currentItem = array_shift($this->queue);
        return isset($this->currentItem);
    }

    public function getCurrentItem()
    {
        return $this->currentItem;
    }
}

class PreOrderIterator extends BinaryTreeIterator
{
    public function traverse(Node $node): void
    {
        $this->queue[] = $node;
        if ($node->left !== null) {
            $this->traverse($node->left);
        }
        if ($node->right !== null) {
            $this->traverse($node->right);
        }
    }
}

class InOrderIterator extends BinaryTreeIterator
{
    public function traverse(Node $node): void
    {
        if ($node->left !== null) {
            $this->traverse($node->left);
        }
        $this->queue[] = $node;
        if ($node->right !== null) {
            $this->traverse($node->right);
        }
    }
}

class PostOrderIterator extends BinaryTreeIterator
{
    public function traverse(Node $node): void
    {
        if ($node->left !== null) {
            $this->traverse($node->left);
        }
        if ($node->right !== null) {
            $this->traverse($node->right);
        }
        $this->queue[] = $node;
    }
}

$collectionToIterateOver = new Collection(["Item1", "Item2", "Item3"]);
$iterator = $collectionToIterateOver->createIterator();

while ($iterator->moveNext()) {
    echo $iterator->getCurrentItem() . "\n";
}

$ferrari = new Ferrari();
$ferrari->addCar(new Car("Ferrari F40"));
$ferrari->addCar(new Car("Ferrari F355"));
$ferrari->addCar(new Car("Ferrari 250 GT0"));
$ferrari->addCar(new Car("Ferrari 125 S"));
$ferrari->addCar(new Car("Ferrari 488 GTB"));

$ford = new Ford([
    new Car("Ford Model T"),
    new Car("Ford GT40"),
    new Car("Ford Escort"),
    new Car("Ford Focus"),
    new Car("Ford Mustang")
]);

$carDealer = new CarDealer([$ferrari, $ford]);
$carDealer->printCars();

$root = new Node(25);
$root->left = new Node(15);
$root->right = new Node(50);

$root->left->left = new Node(10);
$root->left->right = new Node(22);
$root->right->left = new Node(35);
$root->right->right = new Node(70);

$root->left->left->left = new Node(4);
$root->left->left->right = new Node(12);
$root->left->right->left = new Node(18);
$root->left->right->right = new Node(24);

$root->right->left->left = new Node(31);
$root->right->left->right = new Node(44);
$root->right->right->left = new Node(66);
$root->right->right->right = new Node(90);

$preOrderIterator = new PreOrderIterator($root);
$postOrderIterator = new PostOrderIterator($root);
$inOrderIterator = new InOrderIterator($root);

iterateTree($preOrderIterator);
iterateTree($postOrderIterator);
iterateTree($inOrderIterator);

function iterateTree(CustomIterator $binaryTreeIterator): void
{
    $results = [];
    while ($binaryTreeIterator->moveNext()) {
        $results[] = $binaryTreeIterator->getCurrentItem()->value;
    }
    echo get_class($binaryTreeIterator) . " results: " . implode(",", $results) . "\n";
}