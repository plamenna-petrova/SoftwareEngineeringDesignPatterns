<?php

abstract class CustomIterator {
    public abstract function getFirstItem();
    public abstract function getNextItem();
    public abstract function isIterationDone();
    public abstract function getCurrentItem();
}

class ConcreteIterator extends CustomIterator {
    private ConcreteAggregate $concreteAggregate;
    private int $currentItemIndex = 0;

    public function __construct($concreteAggregate) {
        $this->concreteAggregate = $concreteAggregate;
    }

    public function getFirstItem() {
        return $this->concreteAggregate->getItem(0);
    }

    public function getNextItem() {
        $nextItem = null;
        if ($this->currentItemIndex < $this->concreteAggregate->count() - 1) {
            $nextItem = $this->concreteAggregate->getItem(++$this->currentItemIndex);
        }
        return $nextItem;
    }

    public function getCurrentItem() {
        return $this->concreteAggregate->getItem($this->currentItemIndex);
    }

    public function isIterationDone(): bool
    {
        return $this->currentItemIndex >= $this->concreteAggregate->count();
    }
}

abstract class Aggregate implements \Countable
{
    public abstract function createIterator();
}

class ConcreteAggregate extends Aggregate {
    private array $items = [];

    public function createIterator(): ConcreteIterator
    {
        return new ConcreteIterator($this);
    }

    public function addItem($index, $value): void
    {
        $this->items[$index] = $value;
    }

    public function getItem($index) {
        return $this->items[$index] ?? null;
    }

    public function count(): int
    {
        return count($this->items);
    }
}

$concreteAggregate = new ConcreteAggregate();

$concreteAggregate->addItem(0, "Item A");
$concreteAggregate->addItem(1, "Item B");
$concreteAggregate->addItem(2, "Item C");
$concreteAggregate->addItem(3, "Item D");

$iterator = $concreteAggregate->createIterator();

echo "Iterating over collection: \n";

$currentItem = $iterator->getFirstItem();

while ($currentItem != null) {
    echo $currentItem . "\n";
    $currentItem = $iterator->getNextItem();
}