<?php

class Prototype {
    public $X;

    public function __construct($x) {
        $this->X = $x;
    }

    public function printData(): void
    {
        echo "with value: " . $this->X . PHP_EOL;
    }

    public function clone(): Prototype|static
    {
        return clone $this;
    }
}

$prototype = new Prototype(10);
$clonesDictionary = [];

$name = "Object";

for ($i = 1; $i < 11; $i++) {
    $identifier = $name . $i;
    $clonesDictionary[$identifier] = $prototype->clone();
    $clonesDictionary[$identifier]->X *= $i;
    echo $identifier . " ";
    $clonesDictionary[$identifier]->printData();
}

