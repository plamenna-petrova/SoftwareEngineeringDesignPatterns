<?php

class Product {
    private string $name;
    private float $price;

    public function __construct($name, $price) {
        $this->name = $name;
        $this->price = $price;
    }

    public function increasePrice($amount): void
    {
        $this->price += $amount;
        echo "The price for the {$this->name} has been increased by {$amount}$.\n";
    }

    public function decreasePrice($amount): bool
    {
        if ($amount < $this->price) {
            $this->price -= $amount;
            echo "The price for the {$this->name} has been decreased by {$amount}$.\n";
            return true;
        }

        return false;
    }

    public function __toString() {
        return "The current price for the {$this->name} product is {$this->price}$.\n";
    }
}

interface ICommand {
    public function executeAction();
    public function undoAction();
}

class PriceAction {
    const Increase = 'Increase';
    const Decrease = 'Decrease';
}

class ProductCommand implements ICommand {
    private Product $product;
    private string $priceAction;
    private float $amount;
    private bool $isCommandExecuted = false;

    public function __construct($product, $priceAction, $amount) {
        $this->product = $product;
        $this->priceAction = $priceAction;
        $this->amount = $amount;
    }

    public function executeAction(): void
    {
        if ($this->priceAction === PriceAction::Increase) {
            $this->product->increasePrice($this->amount);
            $this->isCommandExecuted = true;
        } else {
            $this->isCommandExecuted = $this->product->decreasePrice($this->amount);
        }
    }

    public function undoAction(): void
    {
        if (!$this->isCommandExecuted) {
            return;
        }

        if ($this->priceAction === PriceAction::Increase) {
            $this->product->decreasePrice($this->amount);
        } else {
            $this->product->increasePrice($this->amount);
        }
    }
}

class PriceModifier {
    private array $commands = [];
    private ICommand $command;

    public function setCommand($command): void
    {
        $this->command = $command;
    }

    public function invoke(): void
    {
        $this->commands[] = $this->command;
        $this->command->executeAction();
    }

    public function undoActions(): void
    {
        foreach (array_reverse($this->commands) as $command) {
            $command->undoAction();
        }
    }
}

$priceModifier = new PriceModifier();
$product = new Product("Phone", 500);

execute($priceModifier, new ProductCommand($product, PriceAction::Increase, 100));
execute($priceModifier, new ProductCommand($product, PriceAction::Increase, 50));
execute($priceModifier, new ProductCommand($product, PriceAction::Decrease, 25));

echo $product . PHP_EOL;

$priceModifier->undoActions();

echo $product;

function execute($priceModifier, $productCommand): void
{
    $priceModifier->setCommand($productCommand);
    $priceModifier->invoke();
}