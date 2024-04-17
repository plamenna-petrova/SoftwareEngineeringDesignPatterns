<?php

class Memento {
    private $state;

    public function __construct($state) {
        $this->state = $state;
    }

    public function getState() {
        return $this->state;
    }
}

class Originator {
    private $state;

    public function getState() {
        return $this->state;
    }

    public function setState($state) {
        $this->state = $state;
        echo "State = " . $this->state . "\n";
    }

    public function createMemento() {
        return new Memento($this->state);
    }

    public function setMemento($memento) {
        echo "Restoring state...\n";
        $this->setState($memento->getState());
    }
}

class Caretaker {
    private $memento;

    public function getMemento() {
        return $this->memento;
    }

    public function setMemento($memento) {
        $this->memento = $memento;
    }
}

$originator = new Originator();
$originator->setState("On");

$caretaker = new Caretaker();
$caretaker->setMemento($originator->createMemento());

$originator->setState("Off");

$originator->setMemento($caretaker->getMemento());
