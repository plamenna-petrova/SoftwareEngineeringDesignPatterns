<?php

interface IFacebookGroupMediator {
    public function sendMessage($message, $user);
    public function registerUser($user);
}

class ConcreteFacebookGroupMediator implements IFacebookGroupMediator {
    private array $usersInFacebookGroup = [];

    public function registerUser($user): void
    {
        $this->usersInFacebookGroup[] = $user;
        $user->setFacebookGroupMediator($this);
    }

    public function sendMessage($message, $user): void
    {
        foreach ($this->usersInFacebookGroup as $userInFacebookGroup) {
            if ($userInFacebookGroup !== $user) {
                $userInFacebookGroup->receiveMessage($message);
            }
        }
    }
}

abstract class User {
    protected string $name;
    protected IFacebookGroupMediator $facebookGroupMediator;

    public function __construct($name) {
        $this->name = $name;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function setFacebookGroupMediator($mediator): void
    {
        $this->facebookGroupMediator = $mediator;
    }

    abstract public function sendMessage($message);
    abstract public function receiveMessage($message);
}

class ConcreteUser extends User {
    public function __construct($name) {
        parent::__construct($name);
    }

    public function sendMessage($message): void
    {
        echo "{$this->getName()} sending message {$message}\n";
        $this->facebookGroupMediator->sendMessage($message, $this);
    }

    public function receiveMessage($message): void
    {
        echo "{$this->getName()} received message: {$message}\n";
    }
}

$facebookGroupMediator = new ConcreteFacebookGroupMediator();

$john = new ConcreteUser("John");
$david = new ConcreteUser("David");
$sam = new ConcreteUser("Sam");
$richard = new ConcreteUser("Richard");
$lisa = new ConcreteUser("Lisa");
$jodie = new ConcreteUser("Jodie");
$william = new ConcreteUser("William");
$harry = new ConcreteUser("Harry");

$usersToRegisterInFacebookGroup = [
    $john,
    $david,
    $sam,
    $richard,
    $lisa,
    $jodie,
    $william,
    $harry
];

foreach ($usersToRegisterInFacebookGroup as $user) {
    $facebookGroupMediator->registerUser($user);
}

$david->sendMessage("Good place to learn Design Patterns");
echo "\n";
$william->sendMessage("Dofactory");