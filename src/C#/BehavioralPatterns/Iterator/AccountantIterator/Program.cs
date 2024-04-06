using System;
using System.Collections.Generic;

namespace AccountantIterator
{
    public class Transaction
    {
        public Transaction(string name, float amount, float taxRate, bool isReconciled)
        {
            Name = name;
            Amount = amount;
            TaxRate = taxRate;
            IsReconciled = isReconciled;
        }

        public string Name { get; set; }

        public float Amount { get; set; }

        public float TaxRate { get; set; }

        public bool IsReconciled { get; set; }

        public override string ToString() =>
            $"Name: {Name}\nAmount: {Amount}\nTax Rate: {TaxRate}\nIs Reconciled: {(IsReconciled ? "Yes" : "No")}";
    }

    public interface IIterator<T>
    {
        bool HasNextItem();

        T GetNextItem();
    }

    public class SalesAccountIterator : IIterator<Transaction>
    {
        private readonly List<Transaction> transactions;

        private int currentTransactionIndex = 0;

        public SalesAccountIterator(List<Transaction> transactions) => this.transactions = transactions;

        public Transaction GetNextItem()
        {
            Transaction transaction = transactions[currentTransactionIndex];
            currentTransactionIndex += 1;
            return transaction;
        }

        public bool HasNextItem() => currentTransactionIndex < transactions.Count;
    }

    public class ExpenseAccountIterator : IIterator<Transaction>
    {
        private readonly Transaction[] transactions;

        private int currentTransactionIndex = 0;

        public ExpenseAccountIterator(Transaction[] transactions) => this.transactions = transactions;

        public Transaction GetNextItem()
        {
            Transaction transaction = transactions[currentTransactionIndex];
            currentTransactionIndex += 1;
            return transaction;
        }

        public bool HasNextItem() => currentTransactionIndex < transactions.Length &&
            transactions[currentTransactionIndex] != null;
    }

    public interface IAccount
    {
        void AddTransaction(string name, float amount, float taxRate, bool isReconciled);

        IIterator<Transaction> CreateIterator();
    }

    public class SalesAccount : IAccount
    {
        private readonly List<Transaction> transactions;

        public SalesAccount()
        {
            transactions = new List<Transaction>();

            AddTransaction(
                name: "Start Industries",
                amount: 200000000,
                taxRate: 0,
                isReconciled: false
            );

            AddTransaction(
                name: "Wayne Enterprises",
                amount: 5500000,
                taxRate: 10,
                isReconciled: true
            );

            AddTransaction(
                name: "Oscorp",
                amount: 100000,
                taxRate: 20,
                isReconciled: false
            );
        }

        public void AddTransaction(string name, float amount, float taxRate, bool isReconciled)
        {
            Transaction transaction = new Transaction(name, amount, taxRate, isReconciled);
            transactions.Add(transaction);
        }

        public IIterator<Transaction> CreateIterator()
        {
            return new SalesAccountIterator(transactions);
        }
    }

    public class ExpenseAccount : IAccount
    {
        private static readonly int maximumTransactions = 3;

        private int currentTransactionIndex = 0;

        private readonly Transaction[] transactions;

        public ExpenseAccount()
        {
            transactions = new Transaction[maximumTransactions];

            AddTransaction(
                name: "Gotham City Iron Works",
                amount: -1500000,
                taxRate: 10,
                isReconciled: true
            );

            AddTransaction(
                name: "Super Electronics",
                amount: -100000,
                taxRate: 20,
                isReconciled: false
            );

            AddTransaction(
                name: "Wakanda Vibranium Corporation",
                amount: -100000000,
                taxRate: 0,
                isReconciled: true
            );
        }

        public void AddTransaction(string name, float amount, float taxRate, bool isReconciled)
        {
            Transaction transaction = new Transaction(name, amount, taxRate, isReconciled);

            if (currentTransactionIndex >= maximumTransactions)
            {
                Console.WriteLine("The account is full! Can't add transaction to account");
            }
            else
            {
                transactions[currentTransactionIndex] = transaction;
                currentTransactionIndex += 1;
            }
        }

        public IIterator<Transaction> CreateIterator()
        {
            return new ExpenseAccountIterator(transactions);
        }
    }

    public class Accountant
    {
        private readonly SalesAccount salesAccount;

        private readonly ExpenseAccount expenseAccount;

        public Accountant(SalesAccount salesAccount, ExpenseAccount expenseAccount)
        {
            this.salesAccount = salesAccount;
            this.expenseAccount = expenseAccount;
        }

        public void PrintTransactions()
        {
            IIterator<Transaction> salesIterator = salesAccount.CreateIterator();
            IIterator<Transaction> expensesIterator = expenseAccount.CreateIterator();

            Console.WriteLine("ACCOUNT\n----\nSALES");
            PrintTransactions(salesIterator);
            Console.WriteLine("\nEXPENSES");
            PrintTransactions(expensesIterator);
        }

        public void PrintTransactions(IIterator<Transaction> transactionIterator)
        {
            while (transactionIterator.HasNextItem())
            {
                Transaction transaction = transactionIterator.GetNextItem();
                Console.WriteLine(transaction.ToString());
                Console.WriteLine();
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Accountant accountant = new Accountant(new SalesAccount(), new ExpenseAccount());
            accountant.PrintTransactions();
        }
    }
}