<?php

namespace BehavioralPatterns\State\VendingMachine;

class VendingMachine {
    private array $products;
    private State $currentState;
    private ?string $selectedProductCode;

    public function __construct(array $products) {
        $this->products = $products;
        $this->currentState = new IdleState($this);
        $this->selectedProductCode = null;
    }

    public function getProducts(): array {
        return $this->products;
    }

    public function setProducts(array $products): void {
        $this->products = $products;
    }

    public function getCurrentState(): State {
        return $this->currentState;
    }

    public function getSelectedProductCode(): ?string {
        return $this->selectedProductCode;
    }

    public function setSelectedProductCode(?string $selectedProductCode): void {
        $this->selectedProductCode = $selectedProductCode;
    }

    public function selectProduct(string $productCode): void {
        $this->currentState->selectProduct($productCode);
    }

    public function insertMoney(float $amount): void {
        $this->currentState->insertMoney($amount);
    }

    public function dispenseProduct(): void {
        $this->currentState->dispenseProduct();
    }

    public function refill(array $products): void {
        $this->currentState->refill($products);
    }

    public function setState(State $state): void {
        $this->currentState = $state;
    }
}