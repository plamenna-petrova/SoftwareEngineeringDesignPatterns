<?php

namespace BehavioralPatterns\Mediator\CQRS;

class Mediator implements IMediator {
    private array $requestHandlers;

    public function __construct($requestHandlers) {
        $this->requestHandlers = $requestHandlers;
    }

    public function send($request) {
        $requestHandlerType = $this->requestHandlers[get_class($request)];
        $requestHandler = new $requestHandlerType();
        return $requestHandler->execute($request);
    }
}