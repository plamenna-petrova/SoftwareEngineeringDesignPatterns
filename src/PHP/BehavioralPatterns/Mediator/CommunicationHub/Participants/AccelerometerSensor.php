<?php

namespace BehavioralPatterns\Mediator\CommunicationHub\Participants;

class AccelerometerSensor extends Sensor
{
    public function __construct()
    {
        parent::__construct("acceleration");
    }

    public function receive($sender, $args): void
    {
        if ($args === "measure")
        {
            $this->lastValue = mt_rand() / mt_getrandmax();
            $this->mediator->notify($this, "measure");
            $this->mediator->notify($this, $this->lastValue);
        }
    }

    public function valueChanged($value): void
    {
        $this->lastValue = $value;
        $this->mediator->notify($this, "measure");
        $this->mediator->notify($this, $this->lastValue);
    }
}