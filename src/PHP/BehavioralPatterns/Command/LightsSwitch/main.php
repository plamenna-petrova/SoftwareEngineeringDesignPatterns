<?php

class Light {
    public function turnOn(): void
    {
        echo "The light is on\n";
    }

    public function turnOff(): void
    {
        echo "The light is off\n";
    }
}

interface ICommand {
    public function execute();
}

class FlipUpCommand implements ICommand {
    private Light $light;

    public function __construct($light) {
        $this->light = $light;
    }

    public function execute(): void
    {
        $this->light->turnOn();
    }
}

class FlipDownCommand implements ICommand {
    private Light $light;

    public function __construct($light) {
        $this->light = $light;
    }

    public function execute(): void
    {
        $this->light->turnOff();
    }
}

class LightsSwitch {
    private array $commands = [];

    public function __construct() {

    }

    public function storeAndExecute($command): void
    {
        $this->commands[] = $command;
        $command->execute();
    }
}

echo "Enter commands (ON/OFF) : ";
$command = fgets(STDIN);

$lamp = new Light();
$switchUp = new FlipUpCommand($lamp);
$switchDown = new FlipDownCommand($lamp);

$switch = new LightsSwitch();

if (trim($command) == "ON") {
    $switch->storeAndExecute($switchUp);
} elseif (trim($command) == "OFF") {
    $switch->storeAndExecute($switchDown);
} else {
    echo "Command \"ON\" or \"OFF\" is required.\n";
}