<?php

namespace BehavioralPatterns\Mediator\CQRS;

class GetProductsRequestHandler implements IRequestHandler {
    public function execute($getProductsRequest): array
    {
        echo "Returning the products\n";
        return [
            ["Name" => "product 1"],
            ["Name" => "product 2"]
        ];
    }
}