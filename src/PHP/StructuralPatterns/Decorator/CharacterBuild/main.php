<?php

abstract class CharacterBuild
{
    public int $health;
    public int $stamina;
    public int $strength;
    public int $dexterity;
    public int $endurance;
    public int $attunement;

    public function showStats(): void
    {
        $stats = sprintf("Health: %d\nStamina: %d\nStrength: %d\nDexterity: %d\nEndurance: %d\nAttunement: %d\n",
            $this->health, $this->stamina, $this->strength, $this->dexterity, $this->endurance, $this->attunement);
        echo $stats . PHP_EOL;
    }
}

class Knight extends CharacterBuild
{
    public function __construct()
    {
        $this->health = 120;
        $this->stamina = 110;
        $this->strength = 15;
        $this->dexterity = 10;
        $this->endurance = 12;
        $this->attunement = 3;
    }
}

class Wanderer extends CharacterBuild
{
    public function __construct()
    {
        $this->health = 100;
        $this->stamina = 120;
        $this->strength = 10;
        $this->dexterity = 15;
        $this->endurance = 12;
        $this->attunement = 4;
    }
}

abstract class CharacterBuildDecorator extends CharacterBuild
{
    protected CharacterBuild $characterBuild;

    public function __construct(CharacterBuild $characterBuild)
    {
        $this->characterBuild = $characterBuild;
    }

    public function increaseHealth($points): void
    {
        $this->characterBuild->health += $points;
    }

    public function increaseStrength($points): void
    {
        $this->characterBuild->strength += $points;
    }

    public function increaseDexterity($points): void
    {
        $this->characterBuild->dexterity += $points;
    }
    public function increaseEndurance($points): void
    {
        $this->characterBuild->endurance += $points;
    }

    public function increaseAttunement($points): void
    {
        $this->characterBuild->attunement += $points;
    }

    public function showStats(): void
    {
        $this->characterBuild->showStats();
    }
}

class StrengthBuild extends CharacterBuildDecorator
{
    public function __construct(CharacterBuild $characterBuild)
    {
        parent::__construct($characterBuild);
        $this->characterBuild->strength += 10;
        $this->characterBuild->health -= 10;
    }
}

class DexterityBuild extends CharacterBuildDecorator
{
    public function __construct(CharacterBuild $characterBuild)
    {
        parent::__construct($characterBuild);
        $this->characterBuild->dexterity += 10;
        $this->characterBuild->strength -= 2;
    }
}

class MagicKnightBuild extends CharacterBuildDecorator
{
    public function __construct(CharacterBuild $characterBuild)
    {
        parent::__construct($characterBuild);
        if ($characterBuild instanceof CharacterBuildDecorator) {
            $characterBuild->increaseAttunement(15);
        } else {
            $characterBuild->attunement += 15;
        }
    }
}

$knight = new Knight();
echo "Base Knight Stats:" . PHP_EOL;
$knight->showStats();

$strengthenedKnight = new StrengthBuild($knight);
echo "Knight Stats After Strength Build: " . PHP_EOL;
$strengthenedKnight->showStats();

$wanderer = new Wanderer();
echo "Base Wanderer Stats: " . PHP_EOL;
$wanderer->showStats();

$dexterousWanderer = new DexterityBuild($wanderer);
echo "Wanderer Stats After Dexterity Build: " . PHP_EOL;
$dexterousWanderer->showStats();

$magicKnight = new MagicKnightBuild($strengthenedKnight);
echo "Strengthened Knight After Magic Build: " . PHP_EOL;
$magicKnight->showStats();
