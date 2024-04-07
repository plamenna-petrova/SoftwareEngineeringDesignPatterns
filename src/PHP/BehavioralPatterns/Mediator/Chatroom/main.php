<?php

abstract class AbstractChatroom {
    abstract public function register($participant);
    abstract public function sendMessage($from, $to, $message);
}

class Chatroom extends AbstractChatroom {
    private $participants = [];

    public function register($participant) {
        if (!in_array($participant, $this->participants, true)) {
            $this->participants[$participant->getName()] = $participant;
        }

        $participant->setChatroom($this);
    }

    public function sendMessage($from, $to, $message) {
        if (isset($this->participants[$to])) {
            $this->participants[$to]->receiveMessage($from, $message);
        }
    }
}

class Participant {
    private string $name;
    private Chatroom $chatroom;

    public function __construct($name) {
        $this->name = $name;
    }

    public function getName() {
        return $this->name;
    }

    public function setChatroom($chatroom): void
    {
        $this->chatroom = $chatroom;
    }

    public function send($to, $message): void
    {
        $this->chatroom->sendMessage($this->name, $to, $message);
    }

    public function receiveMessage($from, $message): void
    {
        echo "{$from} to {$this->name}: '{$message}'\n";
    }
}

class Beatle extends Participant {
    public function receiveMessage($from, $message): void
    {
        echo "To a Beatle: ";
        parent::receiveMessage($from, $message);
    }
}

class NonBeatle extends Participant {
    public function receiveMessage($from, $message): void
    {
        echo "To a non-Beatle: ";
        parent::receiveMessage($from, $message);
    }
}

$chatroom = new Chatroom();

$george = new Beatle("George");
$paul = new Beatle("Paul");
$ringo = new Beatle("Ringo");
$john = new Beatle("John");
$yoko = new Beatle("Yoko");

$participantsToRegisterInChatroom = [$george, $paul, $ringo, $john, $yoko];

foreach ($participantsToRegisterInChatroom as $participant) {
    $chatroom->register($participant);
}

$yoko->send("John", "Hi, John!");
$paul->send("Ringo", "All you need is love");
$ringo->send("George", "My sweet Lord");
$paul->send("John", "Can't buy me love");
$john->send("Yoko", "My sweet love");
