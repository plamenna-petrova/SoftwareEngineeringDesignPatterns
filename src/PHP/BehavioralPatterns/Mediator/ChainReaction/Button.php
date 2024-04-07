<?php

namespace BehavioralPatterns\Mediator\ChainReaction;

class Button extends Participant {
    public function __construct(Mediator $mediator) {
        parent::__construct($mediator);
    }

    public function enable(): void
    {
        echo "Button is enabled." . PHP_EOL;
    }

    public function disable(): void
    {
        echo "Button is disabled." . PHP_EOL;
    }
}