<?php

abstract class Observer {
    public abstract function update();
}

class ConcreteObserver extends Observer {
    private string $name;
    private ConcreteSubject $concreteSubject;

    public function __construct($concreteSubject, $name) {
        $this->concreteSubject = $concreteSubject;
        $this->name = $name;
    }

    public function getConcreteSubject(): ConcreteSubject
    {
        return $this->concreteSubject;
    }

    public function update(): void
    {
        $observerState = $this->concreteSubject->getSubjectState();
        echo "Observer {$this->name}'s new state is {$observerState}\n";
    }
}

abstract class Subject {
    private array $observers = array();

    public function attach($observer): void
    {
        $this->observers[] = $observer;
    }

    public function detach($observer): void
    {
        foreach ($this->observers as $key => $obs) {
            if ($obs === $observer) {
                unset($this->observers[$key]);
                return;
            }
        }
    }

    public function notify(): void
    {
        foreach ($this->observers as $observer) {
            $observer->update();
        }
    }
}

class ConcreteSubject extends Subject {
    private string $subjectState;

    public function getSubjectState(): string
    {
        return $this->subjectState;
    }

    public function setSubjectState($state): void
    {
        $this->subjectState = $state;
    }
}

$concreteSubject = new ConcreteSubject();

$concreteSubject->attach(new ConcreteObserver($concreteSubject, "X"));
$concreteSubject->attach(new ConcreteObserver($concreteSubject, "Y"));
$concreteSubject->attach(new ConcreteObserver($concreteSubject, "Z"));

$concreteSubject->setSubjectState("ABC");
$concreteSubject->notify();