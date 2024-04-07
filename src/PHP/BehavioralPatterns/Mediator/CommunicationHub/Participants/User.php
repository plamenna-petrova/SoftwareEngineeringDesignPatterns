<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Participants;

class User extends Participant
{
    private string $name;

    public function __construct($name)
    {
        $this->name = $name;
    }

    public function receive($sender, $args): void
    {
        if (is_array($args))
        {
            $receiver = $args[0];
            $message = $args[1];
            echo "User: {$this->name}, received from: {$sender}, message: {$message}\n";
        }
        else
        {
            echo "User: {$this->name}, received from: {$sender}, message: {$args}\n";
        }
    }

    public function send($receiver, $args): void
    {
        $this->mediator->notify($this, [$receiver, $args]);
    }

    public function __toString()
    {
        return $this->name;
    }
}