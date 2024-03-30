<?php

class Purchase {
    public $number;
    public $amount;
    public $purpose;

    public function __construct($number, $amount, $purpose) {
        $this->number = $number;
        $this->amount = $amount;
        $this->purpose = $purpose;
    }
}

abstract class Approver {
    protected Approver $successor;

    public string $name;

    public function setSuccessor($successor): void
    {
        $this->successor = $successor;
    }

    abstract public function processRequest($purchase);
}

class Director extends Approver {
    public function processRequest($purchase): void
    {
        if ($purchase->amount < 10000.0) {
            echo get_class($this) . " approved request# {$purchase->number}\n";
        } else {
            $this->successor?->processRequest($purchase);
        }
    }
}

class VicePresident extends Approver {
    public function processRequest($purchase): void
    {
        if ($purchase->amount < 25000.0) {
            echo get_class($this) . " approved request# {$purchase->number}\n";
        } else {
            $this->successor?->processRequest($purchase);
        }
    }
}

class President extends Approver {
    public function processRequest($purchase): void
    {
        if ($purchase->amount < 100000.0) {
            echo get_class($this) . " approved request# {$purchase->number}\n";
        } else {
            echo "Request# {$purchase->number} requires an executive meeting!\n";
        }
    }
}

$director = new Director();
$director->name = "Larry";
$vicePresident = new VicePresident();
$vicePresident->name = "Sam";
$president = new President();
$president->name = "Tammy";

$director->setSuccessor($vicePresident);
$vicePresident->setSuccessor($president);

$purchase = new Purchase(2034, 350.00, "Supplies");
$director->processRequest($purchase);

$purchase = new Purchase(2035, 32590.10, "Project X");
$director->processRequest($purchase);

$purchase = new Purchase(2036, 122100.00, "Project Y");
$director->processRequest($purchase);