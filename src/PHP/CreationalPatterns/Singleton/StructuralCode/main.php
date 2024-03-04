<?php

class Singleton {
    private static Singleton $instance;

    private function __construct() {

    }

    public static function getInstance(): Singleton
    {
        self::$instance ??= new self();
        return self::$instance;
    }
}

$firstSingletonInstance = Singleton::getInstance();
$secondSingletonInstance = Singleton::getInstance();

if ($firstSingletonInstance === $secondSingletonInstance) {
    echo "The objects share the same instance\n";
}