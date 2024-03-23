<?php

class Customer {
    private string $name;

    public function __construct($name) {
        $this->name = $name;
    }

    public function getName(): string
    {
        return $this->name;
    }
}

class Bank {
    public function hasSufficientSavings($customer, $amount): bool
    {
        echo "Check bank for {$customer->getName()} with amount: {$amount}\n";
        return true;
    }
}

class Credit {
    public function hasGoodCredit($customer): bool
    {
        echo "Check credit for {$customer->getName()}\n";
        return true;
    }
}

class Loan {
    public function hasNoBadLoans($customer): bool
    {
        echo "Check loans for {$customer->getName()}\n";
        return true;
    }
}

class Mortgage {
    private Bank $bank;
    private Loan $loan;
    private Credit $credit;

    public function __construct() {
        $this->bank = new Bank();
        $this->loan = new Loan();
        $this->credit = new Credit();
    }

    public function isEligible($customer, $amount): bool
    {
        echo "{$customer->getName()} applies for {$amount} loan \n";

        $isEligible = true;

        if (!$this->bank->hasSufficientSavings($customer, $amount)) {
            $isEligible = false;
        } elseif (!$this->loan->hasNoBadLoans($customer)) {
            $isEligible = false;
        } elseif (!$this->credit->hasGoodCredit($customer)) {
            $isEligible = false;
        }

        return $isEligible;
    }
}

$mortgage = new Mortgage();
$customer = new Customer("Ann McKinsey");
$isEligibleForMortgage = $mortgage->isEligible($customer, 1250000);

echo "\nCustomer " . $customer->getName() . " has been " . ($isEligibleForMortgage ? "Approved" : "Rejected");
