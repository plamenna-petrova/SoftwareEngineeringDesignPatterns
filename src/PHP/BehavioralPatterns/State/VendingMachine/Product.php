<?php

namespace BehavioralPatterns\State\VendingMachine;

class Product {
    private string $code;
    private float $price;
    private int $stock;

    public function __construct(string $code, float $price, int $stock) {
        $this->code = $code;
        $this->price = $price;
        $this->stock = $stock;
    }

    public function getCode(): string {
        return $this->code;
    }

    public function setCode(string $code): void {
        $this->code = $code;
    }

    public function getPrice(): float {
        return $this->price;
    }

    public function setPrice(float $price): void {
        $this->price = $price;
    }

    public function getStock(): int {
        return $this->stock;
    }

    public function setStock(int $stock): void {
        $this->stock = $stock;
    }
}