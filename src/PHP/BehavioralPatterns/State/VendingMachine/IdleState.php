<?php

namespace BehavioralPatterns\State\VendingMachine;

class IdleState extends State {
    public function __construct(VendingMachine $vendingMachine) {
        parent::__construct($vendingMachine);
        echo "IDLE - Wait for product selection\n";
    }

    public function insertMoney(float $amount): void {
        echo "Please select a product before inserting any money.\n";
    }

    public function selectProduct(string $productCode): void {
        $selectedProduct = $this->vendingMachine->getProducts()[$productCode] ?? null;

        if ($selectedProduct === null || $selectedProduct->getStock() === 0) {
            echo "The product code: $productCode is out of stock\n";
            return;
        }

        $this->vendingMachine->setSelectedProductCode($productCode);
        echo "Product: $productCode with price: " . number_format($selectedProduct->getPrice(), 2) . " selected.\n";
        $this->vendingMachine->setState(new PaymentState($this->vendingMachine));
    }

    public function dispenseProduct(): void {
        echo "Select a product first.\n";
    }

    public function cancel(): void {
        echo "There is no selected product or payment in process to cancel.\n";
    }

    public function refill(array $products): void {
        $this->vendingMachine->setProducts($products);
        echo "Total amount of products: " . array_sum(array_map(fn($product) => $product->getStock(), $products)) . "\n";
    }
}