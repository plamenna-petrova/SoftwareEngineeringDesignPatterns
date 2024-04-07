<?php

namespace BehavioralPatterns\Mediator\CQRS;

class CreateProductCommand implements IRequest {
    public string $name;
    public float $price;

    public function __construct($name, $price) {
        $this->name = $name;
        $this->price = $price;
    }
}