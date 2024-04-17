<?php

namespace BehavioralPatterns\State\VendingMachine;

abstract class State {
    protected VendingMachine $vendingMachine;

    public function __construct(VendingMachine $vendingMachine) {
        $this->vendingMachine = $vendingMachine;
    }

    public abstract function insertMoney(float $amount): void;

    public abstract function selectProduct(string $productCode): void;

    public abstract function dispenseProduct(): void;

    public abstract function refill(array $products): void;

    public abstract function cancel(): void;
}
