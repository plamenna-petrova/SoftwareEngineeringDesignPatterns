<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Participants;

class Sensor extends Participant
{
    private string $id;

    protected float $lastValue;

    public function __construct($id)
    {
        $this->id = $id;
    }

    public function getId(): string
    {
        return $this->id;
    }

    public function getLastValue(): float
    {
        return $this->lastValue;
    }

    public function receive($sender, $args): void
    {
        if ($args === "measure")
        {
            $this->lastValue = mt_rand() / mt_getrandmax();
            $this->mediator->notify($this, $this->lastValue);
        }
    }

    public function valueChanged($value): void
    {
        $this->lastValue = $value;
        $this->mediator->notify($this, $this->lastValue);
    }

    public function __toString()
    {
        return "Sensor({$this->id})";
    }
}