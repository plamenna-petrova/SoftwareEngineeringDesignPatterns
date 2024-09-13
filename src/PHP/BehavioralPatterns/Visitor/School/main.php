<?php

interface IElement {
    public function accept(IVisitor $visitor);
}

class Kid implements IElement {
    private string $name;

    public function __construct($name) {
        $this->name = $name;
    }

    public function getName() {
        return $this->name;
    }

    public function setName($name): void
    {
        $this->name = $name;
    }

    public function accept(IVisitor $visitor): void
    {
        $visitor->visit($this);
    }
}

interface IVisitor {
    public function visit(IElement $element);
}

class Doctor implements IVisitor {
    private string $name;

    public function __construct($name) {
        $this->name = $name;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function setName($name): void
    {
        $this->name = $name;
    }

    public function visit(IElement $element): void
    {
        if ($element instanceof Kid) {
            $kid = $element;
            echo "Doctor: " . $this->name . " did the health checkup of the child: " . $kid->getName() . PHP_EOL;
        }
    }
}

class Teacher implements IVisitor {
    private string $name;

    public function __construct($name) {
        $this->name = $name;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function setName($name): void
    {
        $this->name = $name;
    }

    public function visit(IElement $element): void
    {
        if ($element instanceof Kid) {
            $kid = $element;
            echo "Teacher: " . $this->name . " assessed the daily work of the child: " . $kid->getName() . PHP_EOL;
        }
    }
}

class School {
    private array $elements;

    public function __construct() {
        $this->elements = [
            new Kid("John"),
            new Kid("Sarah"),
            new Kid("Kim")
        ];
    }

    public function performOperation(IVisitor $visitor): void
    {
        foreach ($this->elements as $element) {
            $element->accept($visitor);
        }
    }
}

$school = new School();

$doctor = new Doctor("James");
$school->performOperation($doctor);
echo PHP_EOL;

$teacher = new Teacher("Mr. Smith");
$school->performOperation($teacher);