<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Mediators;

interface IMediator
{
    public function notify($sender, $senderArgs);
}