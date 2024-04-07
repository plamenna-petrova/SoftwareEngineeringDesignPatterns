<?php

abstract class Mediator {
    abstract public function send($message, $colleague);
}

class ConcreteMediator extends Mediator {
    private Colleague $firstConcreteColleague;
    private Colleague $secondConcreteColleague;

    public function setFirstConcreteColleague($colleague): void
    {
        $this->firstConcreteColleague = $colleague;
    }

    public function setSecondConcreteColleague($colleague): void
    {
        $this->secondConcreteColleague = $colleague;
    }

    public function send($message, $colleague): void
    {
        if ($colleague == $this->firstConcreteColleague) {
            $this->secondConcreteColleague->getNotification($message);
        } else {
            $this->firstConcreteColleague->getNotification($message);
        }
    }
}

abstract class Colleague {
    protected Mediator $mediator;

    public function __construct($mediator) {
        $this->mediator = $mediator;
    }
}

class FirstConcreteColleague extends Colleague {
    public function __construct($mediator) {
        parent::__construct($mediator);
    }

    public function send($message): void
    {
        $this->mediator->send($message, $this);
    }

    public function getNotification($message): void
    {
        echo "Colleague #1 gets message: " . $message . "\n";
    }
}

class SecondConcreteColleague extends Colleague {
    public function __construct($mediator) {
        parent::__construct($mediator);
    }

    public function send($message): void
    {
        $this->mediator->send($message, $this);
    }

    public function getNotification($message): void
    {
        echo "Colleague #2 gets message: " . $message . "\n";
    }
}

$concreteMediator = new ConcreteMediator();

$firstConcreteColleague = new FirstConcreteColleague($concreteMediator);
$secondConcreteColleague = new SecondConcreteColleague($concreteMediator);

$concreteMediator->setFirstConcreteColleague($firstConcreteColleague);
$concreteMediator->setSecondConcreteColleague($secondConcreteColleague);

$firstConcreteColleague->send("How are you?");
$secondConcreteColleague->send("Fine, thanks");