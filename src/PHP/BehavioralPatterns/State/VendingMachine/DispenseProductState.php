<?php

namespace BehavioralPatterns\State\VendingMachine;

class DispenseProductState extends State {
    public function __construct(VendingMachine $vendingMachine) {
        parent::__construct($vendingMachine);
        echo "DISPENSING\n";
    }

    public function insertMoney(float $amount): void {
        echo "Cannot insert money during the dispensing of the product\n";
    }

    public function selectProduct(string $productCode): void {
        echo "The product is already selected.\n";
    }

    public function dispenseProduct(): void {
        if ($this->vendingMachine->getSelectedProductCode() === null) {
            echo "There is no selected product for dispensing\n";
            $this->vendingMachine->setState(new IdleState($this->vendingMachine));
            return;
        }

        echo "Dispensing product.\n";
        usleep(2000000); // Sleep for 2 seconds (in microseconds)

        $products = $this->vendingMachine->getProducts();
        $selectedProduct = $products[$this->vendingMachine->getSelectedProductCode()];
        $selectedProduct->setStock($selectedProduct->getStock() - 1);

        $this->vendingMachine->setSelectedProductCode(null);

        echo "The product is dispensed.\n";

        if (array_reduce($products, function ($carry, $product) {
            return $carry && ($product->getStock() == 0);
        }, true)) {
            $this->vendingMachine->setState(new SoldOutState($this->vendingMachine));
        } else {
            $this->vendingMachine->setState(new IdleState($this->vendingMachine));
        }
    }

    public function cancel(): void {
        echo "Cannot cancel the dispensing operation\n";
    }

    public function refill(array $products): void {
        echo "Cannot refill during the dispensing of the product\n";
    }
}