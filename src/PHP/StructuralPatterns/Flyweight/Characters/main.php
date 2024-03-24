<?php

abstract class Character {
    protected string $symbol;
    protected int $width;
    protected int $height;
    protected int $ascent;
    protected int $descent;
    protected int $pointSize;

    public abstract function display($pointSize);
}

class CharacterA extends Character {
    public function __construct() {
        $this->symbol = 'A';
        $this->height = 100;
        $this->width = 120;
        $this->ascent = 70;
        $this->descent = 0;
    }

    public function display($pointSize): void
    {
        $this->pointSize = $pointSize;
        echo "symbol (point size $this->pointSize)\n";
    }
}

class CharacterB extends Character {
    public function __construct() {
        $this->symbol = 'B';
        $this->height = 100;
        $this->width = 140;
        $this->ascent = 72;
        $this->descent = 0;
    }

    public function display($pointSize): void
    {
        $this->pointSize = $pointSize;
        echo "symbol (point size $this->pointSize)\n";
    }
}

class CharacterZ extends Character {
    public function __construct() {
        $this->symbol = 'Z';
        $this->height = 100;
        $this->width = 100;
        $this->ascent = 68;
        $this->descent = 0;
    }

    public function display($pointSize): void
    {
        $this->pointSize = $pointSize;
        echo "symbol (point size $this->pointSize)\n";
    }
}

class CharacterFactory {
    private array $characters = [];

    public function getCharacter($key) {
        if (isset($this->characters[$key])) {
            return $this->characters[$key];
        } else {
            switch ($key) {
                case 'A':
                    $character = new CharacterA();
                    break;
                case 'B':
                    $character = new CharacterB();
                    break;
                case 'Z':
                    $character = new CharacterZ();
                    break;
            }

            $this->characters[$key] = $character;
            return $character;
        }
    }
}

$documentText = "AAZZBBZB";
$documentTextCharacters = str_split($documentText);
$characterFactory = new CharacterFactory();
$pointSize = 10;

foreach ($documentTextCharacters as $documentTextCharacter) {
    $pointSize++;
    $character = $characterFactory->getCharacter($documentTextCharacter);
    $character->display($pointSize);
}

