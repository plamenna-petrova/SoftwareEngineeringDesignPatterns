<?php

interface State {
    public function pressPowerButton(Computer $computer);
}

class OnState implements State {
    public function pressPowerButton(Computer $computer): void
    {
        echo "Computer is already on. Going to sleep mode...\n";
        $computer->setState(new SleepState());
    }
}

class OffState implements State {
    public function pressPowerButton(Computer $computer): void
    {
        echo "Turning on computer...\n";
        $computer->setState(new OnState());
    }
}

class SleepState implements State {
    public function pressPowerButton(Computer $computer): void
    {
        echo "Waking up computer from sleep mode...\n";
        $computer->setState(new OnState());
    }
}

class Computer {
    private State $currentState;

    public function __construct() {
        $this->currentState = new OffState();
    }

    public function pressPowerButton(): void
    {
        $this->currentState->pressPowerButton($this);
    }

    public function setState(State $state): void
    {
        $this->currentState = $state;
    }
}

$computer = new Computer();

for ($i = 0; $i < 3; $i++) {
    $computer->pressPowerButton();
}