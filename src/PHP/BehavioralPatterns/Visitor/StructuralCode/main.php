<?php

abstract class Visitor {
    public abstract function visitConcreteElementA(ConcreteElementA $concreteElementA);

    public abstract function visitConcreteElementB(ConcreteElementB $concreteElementB);
}

// Concrete Visitor A class
class ConcreteVisitorA extends Visitor {
    public function visitConcreteElementA(ConcreteElementA $concreteElementA): void
    {
        echo get_class($concreteElementA) . " visited by " . get_class($this) . "\n";
    }

    public function visitConcreteElementB(ConcreteElementB $concreteElementB): void
    {
        echo get_class($concreteElementB) . " visited by " . get_class($this) . "\n";
    }
}

class ConcreteVisitorB extends Visitor {
    public function visitConcreteElementA(ConcreteElementA $concreteElementA): void
    {
        echo get_class($concreteElementA) . " visited by " . get_class($this) . "\n";
    }

    public function visitConcreteElementB(ConcreteElementB $concreteElementB): void
    {
        echo get_class($concreteElementB) . " visited by " . get_class($this) . "\n";
    }
}

abstract class Element {
    public abstract function accept(Visitor $visitor);
}

class ConcreteElementA extends Element {
    public function accept(Visitor $visitor): void
    {
        $visitor->visitConcreteElementA($this);
    }

    public function operationA() {

    }
}

class ConcreteElementB extends Element {
    public function accept(Visitor $visitor): void
    {
        $visitor->visitConcreteElementB($this);
    }

    public function operationB() {

    }
}

class ObjectStructure {
    private array $elements = [];

    public function attach(Element $element): void
    {
        $this->elements[] = $element;
    }

    public function detach(Element $element): void
    {
        $this->elements = array_filter($this->elements, function($e) use ($element) {
            return $e !== $element;
        });
    }

    public function accept(Visitor $visitor): void
    {
        foreach ($this->elements as $element) {
            $element->accept($visitor);
        }
    }
}

$objectStructure = new ObjectStructure();

$objectStructure->attach(new ConcreteElementA());
$objectStructure->attach(new ConcreteElementB());

$concreteVisitorA = new ConcreteVisitorA();
$concreteVisitorB = new ConcreteVisitorB();

$objectStructure->accept($concreteVisitorA);
$objectStructure->accept($concreteVisitorB);
