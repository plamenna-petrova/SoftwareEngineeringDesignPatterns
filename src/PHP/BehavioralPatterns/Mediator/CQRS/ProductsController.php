<?php

namespace BehavioralPatterns\Mediator\CQRS;

class ProductsController {
    private IMediator $mediator;

    public function __construct($mediator) {
        $this->mediator = $mediator;
    }

    public function createProduct($productName, $productPrice): void
    {
        $this->mediator->send(new CreateProductCommand($productName, $productPrice));
    }

    public function getProducts() {
        return $this->mediator->send(new GetProductsRequest());
    }
}