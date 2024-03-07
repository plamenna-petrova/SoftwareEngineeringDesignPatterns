<?php

abstract class Academy
{
    protected IJournal $journal;

    protected function __construct(IJournal $journal)
    {
        $this->journal = $journal;
    }

    abstract public function addMessage($message);

    abstract public function describeEvent($friend, $message);

    abstract public function poke($targetPerson);
}

class JediAcademy extends Academy
{
    public function __construct(IJournal $journal)
    {
        parent::__construct($journal);
    }

    public function addMessage($message): void
    {
        $this->journal->addMessage($message);
    }

    public function describeEvent($friend, $message): void
    {
        $this->journal->describeEvent($friend, $message);
    }

    public function poke($targetPerson): void
    {
        $this->journal->poke($targetPerson);
    }
}

interface IJournal
{
    public function addMessage($message);

    public function describeEvent($friend, $message);

    public function poke($targetPerson);
}

class DailyJournal implements IJournal
{
    private const GAP = "\n\t\t";

    private string $pages = '';

    private string $name;

    private static array $community = [];

    public function __construct($name)
    {
        $this->name = $name;
        self::$community[$name] = $this;
    }

    public function addMessage($message): void
    {
        $this->pages .= self::GAP . "$message";
        echo self::GAP . str_repeat('=', 7) . " {$this->name}'s' Spacebook " . str_repeat('=', 7);
        echo $this->pages;
        echo self::GAP . str_repeat('=', 70) . "\n";
    }

    public function describeEvent($friend, $message): void
    {
        self::$community[$friend]->addMessage($message);
    }

    public function poke($targetPerson): void
    {
        self::$community[$targetPerson]->pages .= self::GAP . " You have been poked";
    }
}

class SharedJournal implements IJournal
{
    private DailyJournal $dailyJournal;

    private string $name;

    private static int $users = 0;

    public function __construct($name)
    {
        $this->name = $name;
        self::$users++;
        $this->dailyJournal = new DailyJournal("{$name}'s daily journal");
    }

    public function addMessage($message): void
    {
        $this->dailyJournal->addMessage($message);
    }

    public function describeEvent($friend, $message): void
    {
        $this->dailyJournal->addMessage("$friend, {$this->name} said: $message");
    }

    public function poke($targetPerson): void
    {
        $this->dailyJournal->poke($targetPerson);
    }
}

$skywalkerDailyJournal = new DailyJournal("Luke");
$skywalkerDailyJournal->addMessage("Hello, Jedi World ");
$skywalkerDailyJournal->addMessage("Busy day at training with the green saber today :( ");

$jedisSharedJournal = new SharedJournal("Jedis");
$academy = new JediAcademy($jedisSharedJournal);
$academy->poke("Luke");
$academy->describeEvent("Luke", "How is everything going?");
$academy->addMessage("Hello there I have started writing on the share journal");