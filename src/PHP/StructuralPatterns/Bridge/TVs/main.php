<?php

interface ILEDTV
{
    public function switchOn();

    public function switchOff();

    public function setChannel($channelNumber);
}

class SamsungLEDTV implements ILEDTV
{
    public function switchOn(): void
    {
        echo "Turning ON : " . get_class($this) . "\n";
    }

    public function switchOff(): void
    {
        echo "Turning OFF : " . get_class($this) . "\n";
    }

    public function setChannel($channelNumber): void
    {
        echo "Setting channel number $channelNumber on " . get_class($this) . "\n";
    }
}

class SonyLEDTV implements ILEDTV
{
    public function switchOn(): void
    {
        echo "Turning ON : " . get_class($this) . "\n";
    }

    public function switchOff(): void
    {
        echo "Turning OFF : " . get_class($this) . "\n";
    }

    public function setChannel($channelNumber): void
    {
        echo "Setting channel number $channelNumber on " . get_class($this) . "\n";
    }
}

abstract class AbstractRemoteControl
{
    protected $ledTV;

    protected function __construct(ILEDTV $ledTV)
    {
        $this->ledTV = $ledTV;
    }

    abstract public function switchOn();

    abstract public function switchOff();

    abstract public function setChannel($channelNumber);
}

class SamsungRemoteControl extends AbstractRemoteControl
{
    public function __construct(ILEDTV $ledTV)
    {
        parent::__construct($ledTV);
    }

    public function switchOn(): void
    {
        $this->ledTV->switchOn();
    }

    public function switchOff(): void
    {
        $this->ledTV->switchOff();
    }

    public function setChannel($channelNumber): void
    {
        $this->ledTV->setChannel($channelNumber);
    }
}

class SonyRemoteControl extends AbstractRemoteControl
{
    public function __construct(ILEDTV $ledTV)
    {
        parent::__construct($ledTV);
    }

    public function switchOn(): void
    {
        $this->ledTV->switchOn();
    }

    public function switchOff(): void
    {
        $this->ledTV->switchOff();
    }

    public function setChannel($channelNumber): void
    {
        $this->ledTV->setChannel($channelNumber);
    }
}

$samsungLEDTV = new SamsungLEDTV();
$samsungRemoteControl = new SamsungRemoteControl($samsungLEDTV);
$samsungRemoteControl->switchOn();
$samsungRemoteControl->setChannel(9);
$samsungRemoteControl->switchOff();

echo "\n";

$sonyLEDTV = new SonyLEDTV();
$sonyRemoteControl = new SonyRemoteControl($sonyLEDTV);
$sonyRemoteControl->switchOn();
$sonyRemoteControl->setChannel(21);
$sonyRemoteControl->switchOff();