<?php

namespace BehavioralPatterns\Mediator\ChainReaction;

class TextBox extends Participant {
    private bool $isEnabled = false;

    public function __construct(Mediator $mediator) {
        parent::__construct($mediator);
    }

    public function isEnabled(): bool
    {
        return $this->isEnabled;
    }

    public function enable(): void
    {
        $this->isEnabled = true;
        echo "TextBox is enabled." . PHP_EOL;
        $this->mediator->onStateChanged($this);
    }

    public function disable(): void
    {
        $this->isEnabled = false;
        echo "TextBox is disabled." . PHP_EOL;
        $this->mediator->onStateChanged($this);
    }
}