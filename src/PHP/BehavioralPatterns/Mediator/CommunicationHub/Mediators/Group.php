<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Mediators;

class Group
{
    public array $participants = [];

    public function __construct()
    {
        $this->participants = [];
    }

    public function addParticipant($participant): void
    {
        $this->participants[] = $participant;
    }

    /**
     * @return array
     */
    public function getParticipants(): array
    {
        return $this->participants;
    }

    public function doesParticipantExist($participant): bool
    {
        return in_array($participant, $this->participants);
    }
}