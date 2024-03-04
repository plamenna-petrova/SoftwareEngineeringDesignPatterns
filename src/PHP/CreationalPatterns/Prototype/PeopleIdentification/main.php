<?php

class IDInfo {
    public string $IDNumber;

    public function __construct($idNumber) {
        $this->IDNumber = $idNumber;
    }
}

abstract class Person {
    public int $age;
    public DateTime $birthDate;

    public string $name;
    public IDInfo $idInfo;

    public function __construct($age, $birthDate, $name, IDInfo $idInfo) {
        $this->age = $age;
        $this->birthDate = $birthDate;
        $this->name = $name;
        $this->idInfo = $idInfo;
    }

    abstract public function ShallowCopy();
    abstract public function DeepCopy();
}

class Traveler extends Person {
    public function __construct($age, $birthDate, $name, IDInfo $idInfo) {
        parent::__construct($age, $birthDate, $name, $idInfo);
    }

    public function ShallowCopy(): Person|static
    {
        return clone $this;
    }

    public function DeepCopy(): Person|static
    {
        $clonedPerson = $this->ShallowCopy();
        $clonedPerson->idInfo = new IDInfo($this->idInfo->IDNumber);
        return $clonedPerson;
    }
}

$firstTraveler = new Traveler(42, new DateTime("1977-01-01"), "Jack Daniels", new IDInfo(666));

$secondTraveler = $firstTraveler->ShallowCopy();
$thirdTraveler = $firstTraveler->DeepCopy();

echo "Original values of the first, second, and third travelers: \n";
echo "Traveler #1 instance values: \n";
displayValues($firstTraveler);
echo "Traveler #2 instance values: \n";
displayValues($secondTraveler);
echo "Traveler #3 instance values: \n";
displayValues($thirdTraveler);

$firstTraveler->age = 32;
$firstTraveler->birthDate = new DateTime("1990-05-06");
$firstTraveler->name = "Frank";
$firstTraveler->idInfo->IDNumber = 7879;

echo "Values of the first, second, and third travelers after applying changes to the first one: \n";
echo "Traveler #1 instance values: \n";
displayValues($firstTraveler);
echo "Traveler #2 instance values (reference values have changed - shallow copy): \n";
displayValues($secondTraveler);
echo "Traveler #3 instance values (everything was kept the same - deep copy): \n";
displayValues($thirdTraveler);

function displayValues($person): void
{
    echo str_repeat(' ', 10) . "Name: {$person->name}, Age: {$person->age}, BirthDate: {$person->birthDate->format('m/d/y')}\n";
    echo str_repeat(' ', 10) . "ID#: {$person->idInfo->IDNumber}\n";
}
