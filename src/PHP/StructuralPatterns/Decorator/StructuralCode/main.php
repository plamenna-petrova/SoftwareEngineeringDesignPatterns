<?php

abstract class Component {
    abstract public function executeOperation();
}

class ConcreteComponent extends Component {
    public function executeOperation(): void
    {
        echo "Called executeOperation() from Concrete Component\n";
    }
}

abstract class Decorator extends Component {
    protected Component $component;

    public function setComponent(Component $component): void
    {
        $this->component = $component;
    }

    public function executeOperation(): void
    {
        $this->component->executeOperation();
    }
}

class ConcreteDecoratorA extends Decorator {
    public function executeOperation(): void
    {
        parent::executeOperation();
        echo "Called executeOperation() from " . get_class($this) . "\n";
    }
}

class ConcreteDecoratorB extends Decorator {
    public function executeOperation(): void
    {
        parent::executeOperation();
        $this->addBehavior();
        echo "Called executeOperation() from " . get_class($this) . "\n";
    }

    public function addBehavior(): void
    {
        echo "Added Behavior\n";
    }
}

$concreteComponent = new ConcreteComponent();
$concreteDecoratorA = new ConcreteDecoratorA();
$concreteDecoratorB = new ConcreteDecoratorB();

$concreteDecoratorA->setComponent($concreteComponent);
$concreteDecoratorB->setComponent($concreteComponent);

$concreteDecoratorB->executeOperation();

