<?php

abstract class State {
    public abstract function handle(Context $context);
}

class ConcreteStateA extends State {
    public function handle(Context $context): void
    {
        $context->setState(new ConcreteStateB());
    }
}

class ConcreteStateB extends State {
    public function handle(Context $context): void
    {
        $context->setState(new ConcreteStateA());
    }
}

class Context {
    private State $state;

    public function __construct(State $state) {
        $this->state = $state;
    }

    public function getState(): State
    {
        return $this->state;
    }

    public function setState(State $state): void
    {
        $this->state = $state;
        echo "State: " . get_class($state) . "\n";
    }

    public function request(): void
    {
        $this->state->handle($this);
    }
}

$context = new Context(new ConcreteStateA());

for ($i = 0; $i < 4; $i++) {
    $context->request();
}
