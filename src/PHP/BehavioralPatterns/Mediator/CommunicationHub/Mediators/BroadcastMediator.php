<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Mediators;

class BroadcastMediator implements IMediator
{
    public array $participants = [];

    public function __construct()
    {
        $this->participants = [];
    }

    public function notify($sender, $senderArgs): void
    {
        foreach ($this->participants as $participant) {
            $participant->receive($sender, $senderArgs);
        }
    }
}