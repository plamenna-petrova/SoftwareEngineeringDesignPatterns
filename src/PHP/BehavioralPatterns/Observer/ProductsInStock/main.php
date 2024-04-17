<?php

interface IObserver {
    public function update($availability);
}

class Observer implements IObserver {
    public string $userName;

    public function __construct($userName) {
        $this->userName = $userName;
    }

    public function addSubscriber($subject): void
    {
        $subject->registerObserver($this);
    }

    public function removeSubscriber($subject): void
    {
        $subject->removeObserver($this);
    }

    public function update($availability): void
    {
        echo "Hello {$this->userName}, Product is now {$availability} on Amazon\n";
    }
}

interface ISubject {
    public function registerObserver($observer);

    public function removeObserver($observer);

    public function notifyObservers();
}

class Subject implements ISubject {
    private array $observers = [];
    private string $productName;
    private int $productPrice;
    private string $productAvailability;

    public function __construct($productName, $productPrice, $productAvailability) {
        $this->productName = $productName;
        $this->productPrice = $productPrice;
        $this->productAvailability = $productAvailability;
    }

    public function getProductAvailability(): string
    {
        return $this->productAvailability;
    }

    public function setProductAvailability($productAvailability): void
    {
        $this->productAvailability = $productAvailability;
        echo "Availability changed from Out of Stock to {$productAvailability}\n";
    }

    public function registerObserver($observer): void
    {
        echo "Observer added : {$observer->userName}\n";
        $this->observers[] = $observer;
    }

    public function removeObserver($observer): void
    {
        echo "Observer removed : {$observer->userName}\n";
        $key = array_search($observer, $this->observers);

        if ($key !== false) {
            unset($this->observers[$key]);
        }
    }

    public function notifyObservers(): void
    {
        echo "Product Name : {$this->productName}, product price : {$this->productPrice}. So, notifying all registered users.\n\n";

        foreach ($this->observers as $observer) {
            $observer->update($this->productAvailability);
        }
    }
}

$XiaomiRedmi = new Subject("Xiaomi Redmi Mobile", 10000, "Out Of Stock");

$firstObserver = new Observer("Axel");
$firstObserver->addSubscriber($XiaomiRedmi);

$secondObserver = new Observer("Pharrell");
$secondObserver->addSubscriber($XiaomiRedmi);

$thirdObserver = new Observer("Carl");
$thirdObserver->addSubscriber($XiaomiRedmi);

echo "Xiaomi Red Mi Mobile current state : " . $XiaomiRedmi->getProductAvailability() . "\n\n";

$thirdObserver->removeSubscriber($XiaomiRedmi);

$XiaomiRedmi->setProductAvailability("Available");