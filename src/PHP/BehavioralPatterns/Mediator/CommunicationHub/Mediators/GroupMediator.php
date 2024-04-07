<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Mediators;

class GroupMediator implements IMediator
{
    public array $groups = [];

    public function __construct()
    {
        $this->groups = [];
    }

    public function addGroup($group): void
    {
        $this->groups[] = $group;
    }

    public function notify($sender, $senderArgs): void
    {
        foreach ($this->groups as $group) {
            if ($group->doesParticipantExist($sender)) {
                $participants = $group->getParticipants();

                foreach ($participants as $participant) {
                    if ($participant !== $sender) {
                        $participant->receive($sender, $senderArgs);
                    }
                }
            }
        }
    }
}