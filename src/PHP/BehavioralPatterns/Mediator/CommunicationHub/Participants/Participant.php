<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Participants;

use BehavioralPatterns\Mediator\CommunicationHub\Mediators\IMediator;

abstract class Participant
{
    public IMediator $mediator;

    public function setMediator($mediator): void
    {
        $this->mediator = $mediator;
    }

    abstract public function receive($sender, $args);
}