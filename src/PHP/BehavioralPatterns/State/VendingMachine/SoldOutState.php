<?php

namespace BehavioralPatterns\State\VendingMachine;

class SoldOutState extends State {
    public function __construct(VendingMachine $vendingMachine) {
        parent::__construct($vendingMachine);
        echo "SOLDOUT\n";
    }

    public function insertMoney(float $amount): void {
        echo "There are no products in the vending machine.\n";
    }

    public function selectProduct(string $productCode): void {
        echo "There are no products in the vending machine.\n";
    }

    public function dispenseProduct(): void {
        echo "There is no selected product for dispensing\n";
    }

    public function cancel(): void {
        echo "There is no operation to be cancelled\n";
    }

    public function refill(array $products): void {
        $this->vendingMachine->setProducts($products);

        echo "Total amount of products: " . array_reduce($products, function ($sum, $product) {
                return $sum + $product->getStock();
            }, 0) . "\n";

        $this->vendingMachine->setState(new IdleState($this->vendingMachine));
    }
}