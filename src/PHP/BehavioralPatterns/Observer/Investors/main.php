<?php

abstract class Stock {
    private float $price;
    private array $investors = [];

    public function __construct($symbol, $price) {
        $this->symbol = $symbol;
        $this->price = $price;
    }

    public function attach($investor): void
    {
        $this->investors[] = $investor;
    }

    public function detach($investor): void
    {
        $key = array_search($investor, $this->investors);
        if ($key !== false) {
            unset($this->investors[$key]);
        }
    }

    public function notify(): void
    {
        foreach ($this->investors as $investor) {
            $investor->update($this);
        }
        echo "\n";
    }

    public function getPrice(): float
    {
        return $this->price;
    }

    public function setPrice($price): void
    {
        if ($this->price != $price) {
            $this->price = $price;
            $this->notify();
        }
    }

    public function getSymbol() {
        return $this->symbol;
    }
}

class IBM extends Stock {
    public function __construct($symbol, $price) {
        parent::__construct($symbol, $price);
    }
}

interface IInvestor {
    public function update($stock);
}

class Investor implements IInvestor {
    private string $name;
    private Stock $stock;

    public function __construct($name) {
        $this->name = $name;
    }

    public function update($stock): void
    {
        printf("Notified %s of %s's change to %.2f\n", $this->name, $stock->getSymbol(), $stock->getPrice());
    }
}

$IBM = new IBM("IBM", 120.00);
$IBM->attach(new Investor("Sorros"));
$IBM->attach(new Investor("Berkshire"));

$IBM->setPrice(120.10);
$IBM->setPrice(121.00);
$IBM->setPrice(120.50);
$IBM->setPrice(120.75);