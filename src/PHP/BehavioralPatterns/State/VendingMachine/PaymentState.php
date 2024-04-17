<?php

namespace BehavioralPatterns\State\VendingMachine;

class PaymentState extends State {
    private float $funds = 0;

    public function __construct(VendingMachine $vendingMachine) {
        parent::__construct($vendingMachine);
        echo "PAYMENT - You can insert coins.\n";
    }

    public function insertMoney(float $amount): void {
        $this->funds += $amount;

        $selectedProduct = $this->vendingMachine->getProducts()[$this->vendingMachine->getSelectedProductCode()] ?? null;

        if ($selectedProduct === null) {
            echo "No product selected. Please select a product first.\n";
            return;
        }

        if ($this->funds < $selectedProduct->getPrice()) {
            echo "Remaining: " . number_format($selectedProduct->getPrice() - $this->funds, 2) . "\n";
        } else {
            echo "Proper amount received\n";

            $change = $this->funds - $selectedProduct->getPrice();

            if ($change > 0) {
                echo "Dispensing " . number_format($change, 2) . " amount\n";
            }

            $this->vendingMachine->setState(new DispenseProductState($this->vendingMachine));
            $this->vendingMachine->dispenseProduct();
        }
    }

    public function selectProduct(string $productCode): void {
        echo "The product is already selected. Please complete or cancel the current payment.\n";
    }

    public function dispenseProduct(): void {
        echo "Cannot dispense product yet. Insufficient funds.\n";
    }

    public function cancel(): void {
        echo "Cancelling order.\n";

        if ($this->funds > 0) {
            echo "Returning the amount of " . number_format($this->funds, 2) . "\n";
        }

        $this->vendingMachine->setSelectedProductCode(null);
        $this->vendingMachine->setState(new IdleState($this->vendingMachine));
    }

    public function refill(array $products): void {
        echo "Cannot refill during payment operation. Please cancel or complete the payment before refill.\n";
    }
}