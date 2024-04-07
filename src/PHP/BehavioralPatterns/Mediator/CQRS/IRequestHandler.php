<?php

namespace BehavioralPatterns\Mediator\CQRS;

interface IRequestHandler {
    public function execute($request);
}