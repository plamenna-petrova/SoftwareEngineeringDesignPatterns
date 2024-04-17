<?php

class Memento {
    private string $name;
    private string $phone;
    private float $budget;

    public function __construct($name, $phone, $budget) {
        $this->name = $name;
        $this->phone = $phone;
        $this->budget = $budget;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getPhone(): string
    {
        return $this->phone;
    }

    public function getBudget(): float
    {
        return $this->budget;
    }
}

class SalesProspect {
    private string $name;
    private string $phone;
    private float $budget;

    public function getName(): string
    {
        return $this->name;
    }

    public function setName($name): void
    {
        $this->name = $name;
        echo "Name: " . $this->name . "\n";
    }

    public function getPhone(): string
    {
        return $this->phone;
    }

    public function setPhone($phone): void
    {
        $this->phone = $phone;
        echo "Phone: " . $this->phone . "\n";
    }

    public function getBudget(): float
    {
        return $this->budget;
    }

    public function setBudget($budget): void
    {
        $this->budget = $budget ?? 0.0;
        echo "Budget: " . $this->budget . "\n";
    }

    public function saveMemento(): Memento
    {
        echo "\nSaving state --\n";
        return new Memento($this->name, $this->phone, $this->budget);
    }

    public function restoreMemento($memento): void
    {
        echo "\nRestoring state --\n";
        $this->setName($memento->getName());
        $this->setPhone($memento->getPhone());
        $this->setBudget($memento->getBudget());
    }
}

class ProspectMemory {
    private Memento $memento;

    public function getMemento(): Memento
    {
        return $this->memento;
    }

    public function setMemento($memento): void
    {
        $this->memento = $memento;
    }
}

$salesProspect = new SalesProspect();
$salesProspect->setName("Noel van Halen");
$salesProspect->setPhone("(412) 256-0990");
$salesProspect->setBudget(0.0);

$prospectMemory = new ProspectMemory();
$prospectMemory->setMemento($salesProspect->saveMemento());

$salesProspect->setName("Leo Welch");
$salesProspect->setPhone("(310) 209-7111");
$salesProspect->setBudget(100000.0);

$salesProspect->restoreMemento($prospectMemory->getMemento());