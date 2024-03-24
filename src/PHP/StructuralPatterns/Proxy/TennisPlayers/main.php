<?php

interface ITennisPlayer {
    public function getPlayerInfo();
    public function setPlayerInfo($info);
}

class ATPPlayer implements ITennisPlayer {
    private string $info;

    public function getPlayerInfo(): string
    {
        return $this->info;
    }

    public function setPlayerInfo($info): void
    {
        $this->info = $info;
    }
}

class ProxyTennisPlayer implements ITennisPlayer {
    private ATPPlayer $atpPlayer;

    public function __construct() {
        $this->atpPlayer = new ATPPlayer();
    }

    public function getPlayerInfo(): string
    {
        return $this->atpPlayer->getPlayerInfo();
    }

    public function setPlayerInfo($info): void
    {
        $this->atpPlayer->setPlayerInfo($info);
    }
}

$proxyTennisPlayer = new ProxyTennisPlayer();
$proxyTennisPlayer->setPlayerInfo("Ranking up with 20 positions");

echo $proxyTennisPlayer->getPlayerInfo();

