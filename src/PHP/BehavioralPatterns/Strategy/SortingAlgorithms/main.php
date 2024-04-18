<?php

abstract class SortStrategy {
    abstract public function sort(&$listOfStrings);
}

class QuickSort extends SortStrategy {
    public function sort(&$listOfStrings): void
    {
        sort($listOfStrings);
        echo "Quick-sorted list" . PHP_EOL;
    }
}

class ShellSort extends SortStrategy {
    public function sort(&$listOfStrings): void
    {
        // not-implemented
        echo "Shell-sorted list" . PHP_EOL;
    }
}

class MergeSort extends SortStrategy {
    public function sort(&$listOfStrings): void
    {
        // not-implemented
        echo "Merge-sorted list" . PHP_EOL;
    }
}

class SortedList {
    private array $namesList = [];

    private SortStrategy $sortStrategy;

    public function setSortStrategy(SortStrategy $sortStrategy): void
    {
        $this->sortStrategy = $sortStrategy;
    }

    public function add($name): void
    {
        $this->namesList[] = $name;
    }

    public function sort(): void
    {
        $this->sortStrategy->sort($this->namesList);

        foreach ($this->namesList as $name) {
            echo " $name" . PHP_EOL;
        }

        echo PHP_EOL;
    }
}

$studentRecords = new SortedList();

$studentRecords->add("Samuel");
$studentRecords->add("Jimmy");
$studentRecords->add("Sandra");
$studentRecords->add("Vivek");
$studentRecords->add("Anna");

$studentRecords->setSortStrategy(new QuickSort());
$studentRecords->sort();

$studentRecords->setSortStrategy(new ShellSort());
$studentRecords->sort();

$studentRecords->setSortStrategy(new MergeSort());
$studentRecords->sort();
