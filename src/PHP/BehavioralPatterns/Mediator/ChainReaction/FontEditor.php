<?php

namespace BehavioralPatterns\Mediator\ChainReaction;

class FontEditor extends Participant {
    public function __construct(Mediator $mediator) {
        parent::__construct($mediator);
    }

    public function enable(): void
    {
        echo "FontEditor is enabled." . PHP_EOL;
    }

    public function disable(): void
    {
        echo "FontEditor is disabled." . PHP_EOL;
    }
}