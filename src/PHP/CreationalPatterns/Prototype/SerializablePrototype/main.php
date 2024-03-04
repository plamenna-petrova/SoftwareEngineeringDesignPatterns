<?php

class ReferenceTypeClass {
    public $ID;
}

abstract class Prototype {
    public function clone(): Prototype|static
    {
        return clone $this;
    }

    public function deepCopy() {
        $serialized = serialize($this);
        return unserialize($serialized);
    }
}

class ConcretePrototype extends Prototype {
    public string $ValueType;
    public ReferenceTypeClass $DummyReference;

    public function __toString() {
        return "Value type: {$this->ValueType}, Dummy Reference ID: {$this->DummyReference->ID}";
    }
}

$firstConcretePrototype = new ConcretePrototype();
$firstConcretePrototype->ValueType = "1";
$firstConcretePrototype->DummyReference = new ReferenceTypeClass();
$firstConcretePrototype->DummyReference->ID = "1";

$secondConcretePrototype = $firstConcretePrototype->clone();
$thirdConcretePrototype = $firstConcretePrototype->deepCopy();

$secondConcretePrototype->ValueType = "2";
$secondConcretePrototype->DummyReference->ID = "2";

echo $firstConcretePrototype . PHP_EOL;
echo $secondConcretePrototype . PHP_EOL;
echo $thirdConcretePrototype . PHP_EOL;
