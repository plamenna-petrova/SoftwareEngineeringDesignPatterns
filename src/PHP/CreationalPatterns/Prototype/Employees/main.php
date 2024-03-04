<?php

abstract class Employee {
    public string $name;
    public string $department;
    public Address $address;

    abstract public function getShallowCopy();

    abstract public function getDeepCopy();

    public function getDetails(): void
    {
        echo "Employee Details: Name - {$this->name}, Department - {$this->department}, Address - {$this->address->name}\n";
    }
}

class SoftwareDeveloper extends Employee {
    public function getShallowCopy(): Employee|static
    {
        return clone $this;
    }

    public function getDeepCopy(): Employee|static
    {
        $clonedEmployee = $this->getShallowCopy();
        $clonedEmployee->address = $this->address->getClone();
        return $clonedEmployee;
    }
}

class Address {
    public string $name;

    public function getClone(): Address|static
    {
        return clone $this;
    }
}

$firstSoftwareDeveloper = new SoftwareDeveloper();
$firstSoftwareDeveloper->name = "John";
$firstSoftwareDeveloper->department = "IT";
$firstSoftwareDeveloper->address = new Address();
$firstSoftwareDeveloper->address->name = "London, UK";

$secondSoftwareDeveloper = $firstSoftwareDeveloper->getShallowCopy();

$thirdSoftwareDeveloper = $firstSoftwareDeveloper->getDeepCopy();

echo "Original values: \r\n";

$firstSoftwareDeveloper->getDetails();
$secondSoftwareDeveloper->getDetails();
$thirdSoftwareDeveloper->getDetails();

echo "\n";

$secondSoftwareDeveloper->name = "James";
$secondSoftwareDeveloper->address->name = "New York, USA";

$thirdSoftwareDeveloper->address->name = "Barcelona, Spain";

echo "After applying changes: \r\n";

$firstSoftwareDeveloper->getDetails();
$secondSoftwareDeveloper->getDetails();
$thirdSoftwareDeveloper->getDetails();

