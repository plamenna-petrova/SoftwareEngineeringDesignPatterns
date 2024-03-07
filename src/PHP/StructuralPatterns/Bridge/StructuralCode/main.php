<?php

class Implementor
{
    public function executeOperation()
    {
        // To be implemented by concrete implementor classes
    }
}

class Abstraction
{
    protected Implementor $implementor;

    public function setImplementor(Implementor $implementor): void
    {
        $this->implementor = $implementor;
    }

    public function executeOperation(): void
    {
        $this->implementor->executeOperation();
    }
}

class RefinedAbstraction extends Abstraction
{
    public function executeOperation(): void
    {
        $this->implementor->executeOperation();
    }
}

class ConcreteImplementorA extends Implementor
{
    public function executeOperation(): void
    {
        echo get_class($this) . " Operation\n";
    }
}

class ConcreteImplementorB extends Implementor
{
    public function executeOperation(): void
    {
        echo get_class($this) . " Operation\n";
    }
}

$abstraction = new RefinedAbstraction();

$abstraction->setImplementor(new ConcreteImplementorA());
$abstraction->executeOperation();

$abstraction->setImplementor(new ConcreteImplementorB());
$abstraction->executeOperation();