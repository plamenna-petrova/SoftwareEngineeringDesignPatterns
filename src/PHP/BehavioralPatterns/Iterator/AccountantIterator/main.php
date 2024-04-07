<?php

interface IIterator
{
    public function hasNextItem(): bool;

    public function getNextItem();
}

class Transaction
{
    public string $name;
    public float $amount;
    public float $taxRate;
    public bool $isReconciled;

    public function __construct(string $name, float $amount, float $taxRate, bool $isReconciled)
    {
        $this->name = $name;
        $this->amount = $amount;
        $this->taxRate = $taxRate;
        $this->isReconciled = $isReconciled;
    }

    public function __toString(): string
    {
        $reconciled = $this->isReconciled ? "Yes" : "No";
        return "Name: $this->name\nAmount: $this->amount\nTax Rate: $this->taxRate\nIs Reconciled: $reconciled";
    }
}

class SalesAccountIterator implements IIterator
{
    private array $transactions;
    private int $currentTransactionIndex = 0;

    public function __construct(array $transactions)
    {
        $this->transactions = $transactions;
    }

    public function getNextItem()
    {
        $transaction = $this->transactions[$this->currentTransactionIndex];
        $this->currentTransactionIndex++;
        return $transaction;
    }

    public function hasNextItem(): bool
    {
        return $this->currentTransactionIndex < count($this->transactions);
    }
}

class ExpenseAccountIterator implements IIterator
{
    private array $transactions;
    private int $currentTransactionIndex = 0;

    public function __construct(array $transactions)
    {
        $this->transactions = $transactions;
    }

    public function getNextItem()
    {
        $transaction = $this->transactions[$this->currentTransactionIndex];
        $this->currentTransactionIndex++;
        return $transaction;
    }

    public function hasNextItem(): bool
    {
        return $this->currentTransactionIndex < count($this->transactions)
            && isset($this->transactions[$this->currentTransactionIndex]);
    }
}

interface IAccount
{
    public function addTransaction(string $name, float $amount, float $taxRate, bool $isReconciled);

    public function createIterator(): IIterator;
}

class SalesAccount implements IAccount
{
    private array $transactions = [];

    public function __construct()
    {
        $this->addTransaction("Start Industries", 200000000, 0, false);
        $this->addTransaction("Wayne Enterprises", 5500000, 10, true);
        $this->addTransaction("Oscorp", 100000, 20, false);
    }

    public function addTransaction(string $name, float $amount, float $taxRate, bool $isReconciled): void
    {
        $transaction = new Transaction($name, $amount, $taxRate, $isReconciled);
        $this->transactions[] = $transaction;
    }

    public function createIterator(): IIterator
    {
        return new SalesAccountIterator($this->transactions);
    }
}

class ExpenseAccount implements IAccount
{
    private const MAXIMUM_TRANSACTIONS = 3;
    private array $transactions = [];
    private int $currentTransactionIndex = 0;

    public function __construct()
    {
        $this->addTransaction("Gotham City Iron Works", -1500000, 10, true);
        $this->addTransaction("Super Electronics", -100000, 20, false);
        $this->addTransaction("Wakanda Vibranium Corporation", -100000000, 0, true);
    }

    public function addTransaction(string $name, float $amount, float $taxRate, bool $isReconciled): void
    {
        $transaction = new Transaction($name, $amount, $taxRate, $isReconciled);

        if ($this->currentTransactionIndex >= self::MAXIMUM_TRANSACTIONS) {
            echo "The account is full! Can't add transaction to account\n";
        } else {
            $this->transactions[$this->currentTransactionIndex] = $transaction;
            $this->currentTransactionIndex++;
        }
    }

    public function createIterator(): IIterator
    {
        return new ExpenseAccountIterator($this->transactions);
    }
}

class Accountant
{
    private SalesAccount $salesAccount;
    private ExpenseAccount $expenseAccount;

    public function __construct(SalesAccount $salesAccount, ExpenseAccount $expenseAccount)
    {
        $this->salesAccount = $salesAccount;
        $this->expenseAccount = $expenseAccount;
    }

    public function printTransactions(): void
    {
        $salesIterator = $this->salesAccount->createIterator();
        $expensesIterator = $this->expenseAccount->createIterator();

        echo "ACCOUNT\n----\nSALES\n";
        $this->printIteratorTransactions($salesIterator);
        echo "\nEXPENSES\n";
        $this->printIteratorTransactions($expensesIterator);
    }

    private function printIteratorTransactions(IIterator $transactionIterator): void
    {
        while ($transactionIterator->hasNextItem()) {
            $transaction = $transactionIterator->getNextItem();
            echo $transaction . "\n\n";
        }
    }
}

$salesAccount = new SalesAccount();
$expenseAccount = new ExpenseAccount();
$accountant = new Accountant($salesAccount, $expenseAccount);
$accountant->printTransactions();
