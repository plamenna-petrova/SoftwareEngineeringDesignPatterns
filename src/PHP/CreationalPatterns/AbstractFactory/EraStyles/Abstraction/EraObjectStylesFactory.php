<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\Abstraction;

abstract class EraObjectStylesFactory {
    abstract public function createMedievalStyleObject();
    abstract public function createRenaissanceStyleObject();
    abstract public function createVictorianEraStyleObject();
}