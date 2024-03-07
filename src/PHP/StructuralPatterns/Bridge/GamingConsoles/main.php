<?php

interface IGamingConsole
{
    public function connect();

    public function powerOn();

    public function powerOff();
}

class Xbox implements IGamingConsole
{
    public function connect(): void
    {
        echo get_class($this) . " connected" . PHP_EOL;
    }

    public function powerOn(): void
    {
        echo get_class($this) . " powered on" . PHP_EOL;
    }

    public function powerOff(): void
    {
        echo get_class($this) . " powered off" . PHP_EOL;
    }
}

class PlayStation implements IGamingConsole
{
    public function connect(): void
    {
        echo get_class($this) . " connected" . PHP_EOL;
    }

    public function powerOn(): void
    {
        echo get_class($this) . " powered on" . PHP_EOL;
    }

    public function powerOff(): void
    {
        echo get_class($this) . " powered off" . PHP_EOL;
    }
}

class Game
{
    public string $name;

    public string $studio;

    public function __construct($name, $studio)
    {
        $this->name = $name;
        $this->studio = $studio;
    }
}

abstract class GameInstaller
{
    protected IGamingConsole $gamingConsole;

    public function __construct(IGamingConsole $gamingConsole)
    {
        $this->gamingConsole = $gamingConsole;
    }

    public function connectConsole(): void
    {
        $this->gamingConsole->connect();
    }

    public function powerOnConsole(): void
    {
        $this->gamingConsole->powerOn();
    }

    public function initInstallation(): void
    {
        echo "Initializing game installation for " . get_class($this->gamingConsole) . " console" . PHP_EOL;
    }

    public abstract function installGame(Game $game);

    public function powerOff(): void
    {
        $this->gamingConsole->powerOff();
    }
}

class XboxGameInstaller extends GameInstaller
{
    public function __construct(IGamingConsole $gamingConsole)
    {
        parent::__construct($gamingConsole);
    }

    public function installGame(Game $game): void
    {
        echo "Installing game {$game->name} by {$game->studio} on " . get_class($this->gamingConsole) . " console" . PHP_EOL;
    }
}

class PlayStationGameInstaller extends GameInstaller
{
    public function __construct(IGamingConsole $gamingConsole)
    {
        parent::__construct($gamingConsole);
    }

    public function installGame(Game $game): void
    {
        echo "Installing game {$game->name} by {$game->studio} on " . get_class($this->gamingConsole) . " console" . PHP_EOL;
    }
}

$xboxGameInstaller = new XboxGameInstaller(new Xbox());
$xboxGameInstaller->connectConsole();
$xboxGameInstaller->powerOnConsole();
$xboxGameInstaller->initInstallation();
$xboxGameInstaller->installGame(new Game("Dark Souls III", "From Software"));
$xboxGameInstaller->powerOff();

echo PHP_EOL;

$playStationGameInstaller = new PlayStationGameInstaller(new PlayStation());
$playStationGameInstaller->connectConsole();
$playStationGameInstaller->powerOnConsole();
$playStationGameInstaller->initInstallation();
$playStationGameInstaller->installGame(new Game("Call Of Duty", "Activision Blizzard"));
$playStationGameInstaller->powerOff();
