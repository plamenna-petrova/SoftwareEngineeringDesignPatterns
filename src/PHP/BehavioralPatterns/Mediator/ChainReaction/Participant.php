<?php

namespace BehavioralPatterns\Mediator\ChainReaction;

abstract class Participant {
    protected $mediator;

    public function __construct(Mediator $mediator) {
        $this->mediator = $mediator;
    }

    protected function getMediator(): Mediator
    {
        return $this->mediator;
    }
}