<?php

abstract class Subject {
    abstract public function request();
}

class RealSubject extends Subject {
    public function request(): void
    {
        echo "Called RealSubject.Request()\n";
    }
}

class Proxy extends Subject {
    private ?RealSubject $realSubject = null;

    public function request(): void
    {
        if (!$this->realSubject) {
            $this->realSubject = new RealSubject();
        }

        $this->realSubject->request();
    }
}

$proxy = new Proxy();
$proxy->request();
