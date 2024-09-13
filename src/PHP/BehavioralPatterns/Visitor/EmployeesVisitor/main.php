<?php

interface IVisitor {
    public function visit(Element $element);
}

class IncomeVisitor implements IVisitor {
    public function visit(Element $element): void
    {
        if ($element instanceof Employee) {
            $employee = $element;

            $employee->setIncome($employee->getIncome() * 1.10);

            echo get_class($employee) . " " . $employee->getName() . "'s new income: $" . number_format($employee->getIncome(), 2) . PHP_EOL;
        } else {
            echo "Error: Element is not an Employee" . PHP_EOL;
        }
    }
}

class VacationVisitor implements IVisitor {
    public function visit(Element $element): void
    {
        if ($element instanceof  Employee) {
            $employee = $element;

            $employee->setVacationDays($employee->getVacationDays() + 3);

            echo get_class($employee) . " " . $employee->getName() . "'s new vacation days: " . $employee->getVacationDays() . PHP_EOL;
        } else {
            echo "Error: Element is not an Employee" . PHP_EOL;
        }
    }
}

abstract class Element {
    public abstract function accept(IVisitor $visitor);
}

class Employee extends Element {
    private string $name;
    private float $income;
    private int $vacationDays;

    public function __construct($name, $income, $vacationDays) {
        $this->name = $name;
        $this->income = $income;
        $this->vacationDays = $vacationDays;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function setName($name): void
    {
        $this->name = $name;
    }

    public function getIncome(): float
    {
        return $this->income;
    }

    public function setIncome($income): void
    {
        $this->income = $income;
    }

    public function getVacationDays(): int
    {
        return $this->vacationDays;
    }

    public function setVacationDays($vacationDays): void
    {
        $this->vacationDays = $vacationDays;
    }

    public function accept(IVisitor $visitor): void
    {
        $visitor->visit($this);
    }
}

class Clerk extends Employee {
    public function __construct() {
        parent::__construct("Kevin", 25000.0, 14);
    }
}

class Director extends Employee {
    public function __construct() {
        parent::__construct("Elly", 35000.0, 16);
    }
}

class President extends Employee {
    public function __construct() {
        parent::__construct("Eric", 45000.0, 21);
    }
}

class Employees {
    private array $employees = [];

    public function attach(Employee $employee): void
    {
        $this->employees[] = $employee;
    }

    public function detach(Employee $employee): void
    {
        $key = array_search($employee, $this->employees);

        if ($key !== false) {
            unset($this->employees[$key]);
        }
    }

    public function accept(IVisitor $visitor): void
    {
        foreach ($this->employees as $employee) {
            $employee->accept($visitor);
        }

        echo PHP_EOL;
    }
}

$employees = new Employees();

$employees->attach(new Clerk());
$employees->attach(new Director());
$employees->attach(new President());

$employees->accept(new IncomeVisitor());

$employees->accept(new VacationVisitor());
