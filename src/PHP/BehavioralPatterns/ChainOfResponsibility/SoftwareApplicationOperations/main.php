<?php

class Request {
    public $Content;
}

interface IRequestHandler {
    public function setNextHandler($requestHandler);
    public function handleRequest($request);
}

abstract class BaseRequestHandler implements IRequestHandler {
    private ?IRequestHandler $nextRequestHandler = null; // Initializing to null

    public function setNextHandler($nextRequestHandler): void
    {
        $this->nextRequestHandler = $nextRequestHandler;
    }

    public function handleRequest($request): void
    {
        $this->processRequest($request);

        $this->nextRequestHandler?->handleRequest($request);
    }

    protected abstract function processRequest($request);
}

class AuthenticationHandler extends BaseRequestHandler {
    protected function processRequest($request): void
    {
        echo "Authentication handler processing request\n";
    }
}

class AuthorizationHandler extends BaseRequestHandler {
    protected function processRequest($request): void
    {
        echo "Authorization handler processing request\n";
    }
}

class ValidationHandler extends BaseRequestHandler {
    protected function processRequest($request): void
    {
        echo "Validation handler processing request\n";
    }
}

$authenticationHandler = new AuthenticationHandler();
$authorizationHandler = new AuthorizationHandler();
$validationHandler = new ValidationHandler();

$authenticationHandler->setNextHandler($authorizationHandler);
$authorizationHandler->setNextHandler($validationHandler);

$request = new Request();
$request->Content = "Simple Request";

$authenticationHandler->handleRequest($request);