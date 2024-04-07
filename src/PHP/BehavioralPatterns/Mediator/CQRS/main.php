<?php

use BehavioralPatterns\Mediator\CQRS\CreateProductCommand;
use BehavioralPatterns\Mediator\CQRS\CreateProductCommandHandler;
use BehavioralPatterns\Mediator\CQRS\GetProductsRequest;
use BehavioralPatterns\Mediator\CQRS\GetProductsRequestHandler;
use BehavioralPatterns\Mediator\CQRS\ProductsController;
use BehavioralPatterns\Mediator\CQRS\Mediator;

require_once 'vendor/autoload.php';

executeCQRSExample();

function executeCQRSExample(): void
{
    $productsController = new ProductsController(new Mediator([
        CreateProductCommand::class => CreateProductCommandHandler::class,
        GetProductsRequest::class => GetProductsRequestHandler::class
    ]));

    $productsController->createProduct("Product 1", 100);

    $products = $productsController->getProducts();
}