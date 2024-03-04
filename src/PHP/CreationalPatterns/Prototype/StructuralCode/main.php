<?php

abstract class Prototype {
    public $id;

    public function __construct($id) {
        $this->id = $id;
    }

    abstract public function clone();
}

class ConcretePrototype1 extends Prototype {
    public function __construct($id) {
        parent::__construct($id);
    }

    public function clone() {
        return clone $this;
    }
}

class ConcretePrototype2 extends Prototype {
    public function __construct($id) {
        parent::__construct($id);
    }

    public function clone(): ConcretePrototype2|static
    {
        return clone $this;
    }
}

$concretePrototype1 = new ConcretePrototype1("I");
$clonedConcretePrototype1 = $concretePrototype1->clone();
echo "Cloned: " . $clonedConcretePrototype1->id . "\n";

$concretePrototype2 = new ConcretePrototype2("II");
$clonedConcretePrototype2 = $concretePrototype2->clone();
echo "Cloned: " . $clonedConcretePrototype2->id . "\n";

