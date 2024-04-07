<?php

namespace BehavioralPatterns\Mediator\CQRS;

interface IMediator {
    public function send($request);
}