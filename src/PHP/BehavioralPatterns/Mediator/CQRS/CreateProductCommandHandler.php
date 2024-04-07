<?php

namespace BehavioralPatterns\Mediator\CQRS;

class CreateProductCommandHandler implements IRequestHandler {
    public function execute($createProductCommand): bool
    {
        echo "Creating the product: " . $createProductCommand->name . PHP_EOL;
        return true;
    }
}