<?php

abstract class Employee
{
    protected string $name;
    protected float $salary;
    protected string $designation;

    public function __construct($name, $salary, $designation)
    {
        $this->name = $name;
        $this->salary = $salary;
        $this->designation = $designation;
    }

    public abstract function add(Employee $employee);

    public abstract function remove(Employee $employee);

    public abstract function getHierarchicalLevel($level);
}

class TeamLead extends Employee
{
    private array $employees = array();

    public function __construct($name, $salary, $designation)
    {
        parent::__construct($name, $salary, $designation);
    }

    public function add(Employee $employee): void
    {
        $this->employees[] = $employee;
    }

    public function remove(Employee $employee): void
    {
        $index = array_search($employee, $this->employees);

        if ($index !== false) {
            unset($this->employees[$index]);
        }
    }

    public function getHierarchicalLevel($level): void
    {
        echo str_repeat('-', $level) . '+ ' . $this->name . ' [' . $this->designation . '] [$' . $this->salary . ']' . PHP_EOL;

        foreach ($this->employees as $employee) {
            $employee->getHierarchicalLevel($level + 2);
        }
    }
}

class Developer extends Employee
{
    public function __construct($name, $salary, $designation)
    {
        parent::__construct($name, $salary, $designation);
    }

    public function add(Employee $employee): void
    {
        echo "Cannot add to a developer" . PHP_EOL;
    }

    public function remove(Employee $employee): void
    {
        echo "Cannot remove from a developer" . PHP_EOL;
    }

    public function getHierarchicalLevel($level): void
    {
        echo str_repeat('-', $level) . ' ' . $this->name . ' [' . $this->designation . '] [$' . $this->salary . ']' . PHP_EOL;
    }
}

$companyManager = new TeamLead("John", 100000, "Manager");
$companyManager->add(new Developer("Jack", 20000, "Senior .NET Backend Developer"));
$companyManager->add(new Developer("Jim", 25000, "Senior Python Developer"));
$companyManager->add(new Developer("Jacob", 27000, "Senior Frontend Developer"));

$groupArchitect = new TeamLead("Joe", 50000, "Group Architect");
$groupArchitect->add(new Developer("James", 15000, "Junior .NET Developer"));
$groupArchitect->add(new Developer("Jason", 12000, "Angular Developer"));
$companyManager->add($groupArchitect);

$developer = new Developer("Jerry", 18000, "Junior Frontend Developer");
$companyManager->add($developer);
$companyManager->remove($developer);

$companyManager->getHierarchicalLevel(1);