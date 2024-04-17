<?php

abstract class State {
    protected Account $account;
    protected float $balance;
    protected float $interest;
    protected float $lowerLimit;
    protected float $upperLimit;

    public function getAccount(): Account
    {
        return $this->account;
    }

    public function setAccount($account): void
    {
        $this->account = $account;
    }

    public function getBalance(): float
    {
        return $this->balance;
    }

    public function setBalance($balance): void
    {
        $this->balance = $balance;
    }

    public abstract function deposit($amount);

    public abstract function withdraw($amount);

    public abstract function payInterest();
}

class RedState extends State {
    private float $serviceFee;

    public function __construct(State $state) {
        $this->setBalance($state->getBalance());
        $this->setAccount($state->getAccount());
        $this->initialize();
    }

    private function initialize(): void
    {
        $this->interest = 0.0;
        $this->lowerLimit = -100.0;
        $this->upperLimit = 0.0;
        $this->serviceFee = 15.0;
    }

    public function deposit($amount): void
    {
        $this->balance += $amount;
        $this->checkStateChange();
    }

    public function withdraw($amount): void
    {
        $amount -= $this->serviceFee;
        echo "No funds available for withdrawal!\n";
    }

    public function payInterest() {
        // No interest is paid
    }

    private function checkStateChange(): void
    {
        if ($this->balance > $this->upperLimit) {
            $this->account->setState(new SilverState($this));
        }
    }
}

class SilverState extends State {
    public function __construct(float $balance, Account $account) {
        $this->balance = $balance;
        $this->account = $account;
        $this->initialize();
    }

    private function initialize(): void
    {
        $this->interest = 0;
        $this->lowerLimit = 0.0;
        $this->upperLimit = 1000.0;
    }

    public function deposit($amount): void
    {
        $this->balance += $amount;
        $this->checkStateChange();
    }

    public function withdraw($amount): void
    {
        $this->balance -= $amount;
        $this->checkStateChange();
    }

    public function payInterest(): void
    {
        $this->balance += $this->interest * $this->balance;
        $this->checkStateChange();
    }

    private function checkStateChange(): void
    {
        if ($this->balance < $this->lowerLimit) {
            $this->account->setState(new RedState($this));
        } elseif ($this->balance > $this->upperLimit) {
            $this->account->setState(new GoldState($this));
        }
    }
}

class GoldState extends State {
    public function __construct(State $state) {
        $this->balance = $state->getBalance();
        $this->account = $state->getAccount();
        $this->initialize();
    }

    public function deposit($amount): void
    {
        $this->balance += $amount;
        $this->checkStateChange();
    }

    public function withdraw($amount): void
    {
        $this->balance -= $amount;
        $this->checkStateChange();
    }

    public function payInterest(): void
    {
        $this->balance += $this->interest * $this->balance;
        $this->checkStateChange();
    }

    private function initialize(): void
    {
        $this->interest = 0.05;
        $this->lowerLimit = 1000.0;
        $this->upperLimit = 10000000.0;
    }

    private function checkStateChange(): void
    {
        if ($this->balance < 0.0) {
            $this->account->setState(new RedState($this));
        } elseif ($this->balance < $this->lowerLimit) {
            $this->account->setState(new SilverState($this));
        }
    }
}

class Account {
    private State $state;
    private string $owner;

    public function __construct($owner) {
        $this->owner = $owner;
        $this->state = new SilverState(0.0, $this);
    }

    public function getBalance(): float
    {
        return $this->state->getBalance();
    }

    public function getState(): State
    {
        return $this->state;
    }

    public function setState($state): void
    {
        $this->state = $state;
    }

    public function deposit($amount): void
    {
        $this->state->deposit($amount);
        echo "Deposited " . number_format($amount, 2) . " ---\n";
        echo "Balance = " . number_format($this->getBalance(), 2) . "\n";
        echo "Status = " . get_class($this->getState()) . "\n\n";
    }

    public function withdraw($amount): void
    {
        $this->state->withdraw($amount);
        echo "Withdrew " . number_format($amount, 2) . " ---\n";
        echo "Balance = " . number_format($this->getBalance(), 2) . "\n";
        echo "Status = " . get_class($this->getState()) . "\n\n";
    }

    public function payInterest(): void
    {
        $this->state->payInterest();
        echo "Interest Paid ---\n";
        echo "Balance = " . number_format($this->getBalance(), 2) . "\n";
        echo "Status = " . get_class($this->getState()) . "\n\n";
    }
}

$account = new Account("Jim Johnson");

$account->deposit(500.0);
$account->deposit(300.0);
$account->deposit(550.0);
$account->payInterest();
$account->withdraw(2000.00);
$account->withdraw(1100.00);