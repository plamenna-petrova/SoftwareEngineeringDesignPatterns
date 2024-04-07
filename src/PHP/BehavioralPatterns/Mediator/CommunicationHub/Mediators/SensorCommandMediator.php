<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Mediators;

use BehavioralPatterns\Mediator\CommunicationHub\Participants\Sensor;
use BehavioralPatterns\Mediator\CommunicationHub\Participants\User;

class SensorCommandMediator extends GroupMediator
{
    public function notify($sender, $senderArgs): void
    {
        $groupsOfParticipant = [];
        foreach ($this->groups as $group) {
            if ($group->doesParticipantExist($sender)) {
                $groupsOfParticipant[] = $group;
            }
        }

        $receivers = [];
        foreach ($groupsOfParticipant as $group) {
            $participants = $group->getParticipants();

            foreach ($participants as $participant) {
                if ($participant !== $sender) {
                    $receivers[] = $participant;
                }
            }
        }

        if ($senderArgs === "measure") {
            $receivers = array_filter($receivers, function ($r) {
                return !($r instanceof User);
            });
        } else {
            $receivers = array_filter($receivers, function ($r) {
                return !($r instanceof Sensor);
            });
        }

        foreach ($receivers as $receiver) {
            $receiver->receive($sender, $senderArgs);
        }
    }
}