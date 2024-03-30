<?php

abstract class Handler {
    protected Handler $successor;

    public function setSuccessor($successor): void
    {
        $this->successor = $successor;
    }

    public abstract function handleRequest($request);
}

class FirstConcreteHandler extends Handler {
    public function handleRequest($request): void
    {
        if ($request >= 0 && $request < 10) {
            echo get_class($this) . " handled request $request\n";
        } else {
            $this->successor?->handleRequest($request);
        }
    }
}

class SecondConcreteHandler extends Handler {
    public function handleRequest($request): void
    {
        if ($request >= 10 && $request < 20) {
            echo get_class($this) . " handled request $request\n";
        } else {
            $this->successor?->handleRequest($request);
        }
    }
}

class ThirdConcreteHandler extends Handler {
    public function handleRequest($request): void
    {
        if ($request >= 20 && $request < 30) {
            echo get_class($this) . " handled request $request\n";
        } else {
            $this->successor?->handleRequest($request);
        }
    }
}

$firstConcreteHandler = new FirstConcreteHandler();
$secondConcreteHandler = new SecondConcreteHandler();
$thirdConcreteHandler = new ThirdConcreteHandler();

$firstConcreteHandler->setSuccessor($secondConcreteHandler);
$secondConcreteHandler->setSuccessor($thirdConcreteHandler);

$requests = [2, 5, 14, 22, 18, 3, 27, 20];

foreach ($requests as $request) {
    $firstConcreteHandler->handleRequest($request);
}