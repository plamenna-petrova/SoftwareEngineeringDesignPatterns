<?php

class Receiver {
    public function action(): void
    {
        echo "Called Receiver.Action()\n";
    }
}

abstract class Command {
    protected Receiver $receiver;

    public function __construct($receiver) {
        $this->receiver = $receiver;
    }

    public abstract function execute();
}

class ConcreteCommand extends Command {
    public function __construct($receiver) {
        parent::__construct($receiver);
    }

    public function execute(): void
    {
        $this->receiver->action();
    }
}

class Invoker {
    private Command $command;

    public function setCommand($command): void
    {
        $this->command = $command;
    }

    public function executeCommand(): void
    {
        $this->command->execute();
    }
}

$receiver = new Receiver();
$command = new ConcreteCommand($receiver);
$invoker = new Invoker();

$invoker->setCommand($command);
$invoker->executeCommand();