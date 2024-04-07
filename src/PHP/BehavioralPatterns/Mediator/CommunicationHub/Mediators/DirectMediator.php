<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Mediators;

use BehavioralPatterns\Mediator\CommunicationHub\Participants\Participant;

class DirectMediator implements IMediator
{
    public function notify($sender, $senderArgs): void
    {
        if (!is_array($senderArgs)) {
            return;
        }

        $receiver = $senderArgs[0];
        $args = $senderArgs[1];

        if (!($receiver instanceof Participant)) {
            return;
        }

        $receiver->receive($sender, $args);
    }
}