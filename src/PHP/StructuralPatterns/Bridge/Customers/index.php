<?php

abstract class DataObject
{
    public abstract function getNextRecord();

    public abstract function getPreviousRecord();

    public abstract function addRecord($record);

    public abstract function removeRecord($record);

    public abstract function getCurrentRecord();

    public abstract function showRecord();

    public abstract function showAllRecords();
}

class CustomersData extends DataObject
{
    private array $customers = [];
    private int $currentCustomerIndex = 0;
    private string $city;

    public function __construct($city)
    {
        $this->city = $city;

        $this->customers[] = "Jim Jones";
        $this->customers[] = "Samuel Jackson";
        $this->customers[] = "Allen Good";
        $this->customers[] = "Ann Stills";
        $this->customers[] = "Lisa Giolani";
    }

    public function getNextRecord(): void
    {
        if ($this->currentCustomerIndex <= count($this->customers) - 1) {
            $this->currentCustomerIndex++;
        }
    }

    public function getPreviousRecord(): void
    {
        if ($this->currentCustomerIndex > 0) {
            $this->currentCustomerIndex--;
        }
    }

    public function addRecord($record): void
    {
        $this->customers[] = $record;
    }

    public function removeRecord($record): void
    {
        $index = array_search($record, $this->customers);

        if ($index !== false) {
            array_splice($this->customers, $index, 1);
        }
    }

    public function getCurrentRecord()
    {
        return $this->customers[$this->currentCustomerIndex];
    }

    public function showRecord(): void
    {
        echo $this->customers[$this->currentCustomerIndex] . "\n";
    }

    public function showAllRecords(): void
    {
        echo "Customers City: {$this->city}\n";
        echo implode("\n", array_map(fn($c) => " $c", $this->customers)) . "\n";
    }
}

abstract class CustomersBase
{
    protected DataObject $dataObject;

    public function __construct(DataObject $dataObject)
    {
        $this->dataObject = $dataObject;
    }

    public function next(): void
    {
        $this->dataObject->getNextRecord();
    }

    public function previous(): void
    {
        $this->dataObject->getPreviousRecord();
    }

    public function add($record): void
    {
        $this->dataObject->addRecord($record);
    }

    public function remove($record): void
    {
        $this->dataObject->removeRecord($record);
    }

    public function show(): void
    {
        $this->dataObject->showRecord();
    }

    public function showAll(): void
    {
        $this->dataObject->showAllRecords();
    }
}

class RefinedCustomers extends CustomersBase
{
    public function showAll(): void
    {
        echo "\n";
        echo str_repeat('-', 40) . "\n";
        parent::showAll();
        echo str_repeat('-', 40) . "\n";
    }
}

$customers = new RefinedCustomers(new CustomersData("Chicago"));

$customers->show();
$customers->next();
$customers->show();
$customers->next();
$customers->show();
$customers->previous();
$customers->show();
$customers->add("Henry Velasquez");
$customers->showAll();
$customers->remove("Allen Good");
$customers->showAll();