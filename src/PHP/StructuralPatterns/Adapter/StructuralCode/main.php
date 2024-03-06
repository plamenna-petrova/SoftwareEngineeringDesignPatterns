<?php

class Target {
    public function executeRequest(): void
    {
        echo "Called Target ExecuteRequest()\n";
    }
}

class Adapter extends Target {
    private $adaptee;

    public function __construct() {
        $this->adaptee = new Adaptee();
    }

    public function executeRequest(): void
    {
        $this->adaptee->executeSpecificRequest();
    }
}

class Adaptee {
    public function executeSpecificRequest(): void
    {
        echo "Called ExecuteSpecificRequest()\n";
    }
}

$target = new Adapter();
$target->executeRequest();
