<?php

abstract class Strategy {
    abstract public function algorithmInterface();
}

class ConcreteStrategyA extends Strategy {
    public function algorithmInterface(): void
    {
        echo "Called ConcreteStrategyA.AlgorithmInterface()" . PHP_EOL;
    }
}

class ConcreteStrategyB extends Strategy {
    public function algorithmInterface(): void
    {
        echo "Called ConcreteStrategyB.AlgorithmInterface()" . PHP_EOL;
    }
}

class ConcreteStrategyC extends Strategy {
    public function algorithmInterface(): void
    {
        echo "Called ConcreteStrategyC.AlgorithmInterface()" . PHP_EOL;
    }
}

class Context {
    private Strategy $strategy;

    public function __construct(Strategy $strategy) {
        $this->strategy = $strategy;
    }

    public function contextInterface(): void
    {
        $this->strategy->algorithmInterface();
    }
}

$context = new Context(new ConcreteStrategyA());
$context->contextInterface();

$context = new Context(new ConcreteStrategyB());
$context->contextInterface();

$context = new Context(new ConcreteStrategyC());
$context->contextInterface();
