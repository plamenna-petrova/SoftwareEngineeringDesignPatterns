<?php

class Item {
    private string $name;

    public function __construct($name) {
        $this->name = $name;
    }

    public function getName(): string
    {
        return $this->name;
    }
}

interface AbstractIterator {
    public function getFirstItem();
    public function getNextItem();
    public function isIterationDone();
    public function getCurrentItem();
}

class CustomIterator implements AbstractIterator {
    private array $collection;
    private int $currentItemIndex;
    private int $stepsToSkip = 1;

    public function __construct($collection) {
        $this->collection = $collection;
    }

    public function isIterationDone(): bool
    {
        return $this->currentItemIndex >= count($this->collection);
    }

    public function getCurrentItem() {
        return $this->collection[$this->currentItemIndex];
    }

    public function getFirstItem() {
        $this->currentItemIndex = 0;
        return $this->collection[$this->currentItemIndex];
    }

    public function getNextItem() {
        $this->currentItemIndex += $this->stepsToSkip;

        if ($this->isIterationDone()) {
            return null;
        } else {
            return $this->collection[$this->currentItemIndex];
        }
    }

    public function setStepToSkip($steps): void
    {
        $this->stepsToSkip = $steps;
    }
}

interface AbstractCollection {
    public function createIterator();
}

class Collection implements AbstractCollection {
    private array $items = [];

    public function createIterator(): CustomIterator
    {
        return new CustomIterator($this->items);
    }

    public function count(): int
    {
        return count($this->items);
    }

    public function addItem($index, $item): void
    {
        $this->items[$index] = $item;
    }

    public function getItem($index) {
        return $this->items[$index];
    }
}

$collectionToIterateOver = new Collection();

for ($i = 0; $i < 8; $i++) {
    $collectionToIterateOver->addItem($i, new Item("Item " . ($i + 1)));
}

$iterator = $collectionToIterateOver->createIterator();

$iterator->setStepToSkip(2);

echo "Iterating over a collection: \n";

for ($currentItem = $iterator->getFirstItem(); !$iterator->isIterationDone(); $currentItem = $iterator->getNextItem()) {
    echo $currentItem->getName() . "\n";
}