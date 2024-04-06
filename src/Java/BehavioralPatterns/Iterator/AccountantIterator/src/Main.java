import java.util.ArrayList;
import java.util.List;

interface IIterator<T> {
    boolean hasNextItem();
    T getNextItem();
}

class Transaction {
    private final String name;
    private final float amount;
    private final float taxRate;
    private final boolean isReconciled;

    public Transaction(String name, float amount, float taxRate, boolean isReconciled) {
        this.name = name;
        this.amount = amount;
        this.taxRate = taxRate;
        this.isReconciled = isReconciled;
    }

    @Override
    public String toString() {
        return String.format("Name: %s\nAmount: %.2f\nTax Rate: %.2f\nIs Reconciled: %s", name, amount, taxRate, isReconciled ? "Yes" : "No");
    }
}

class SalesAccountIterator implements IIterator<Transaction> {
    private final List<Transaction> transactions;
    private int currentTransactionIndex = 0;

    public SalesAccountIterator(List<Transaction> transactions) {
        this.transactions = transactions;
    }

    @Override
    public Transaction getNextItem() {
        Transaction transaction = transactions.get(currentTransactionIndex);
        currentTransactionIndex++;
        return transaction;
    }

    @Override
    public boolean hasNextItem() {
        return currentTransactionIndex < transactions.size();
    }
}

class ExpenseAccountIterator implements IIterator<Transaction> {
    private final Transaction[] transactions;
    private int currentTransactionIndex = 0;

    public ExpenseAccountIterator(Transaction[] transactions) {
        this.transactions = transactions;
    }

    @Override
    public Transaction getNextItem() {
        Transaction transaction = transactions[currentTransactionIndex];
        currentTransactionIndex++;
        return transaction;
    }

    @Override
    public boolean hasNextItem() {
        return currentTransactionIndex < transactions.length && transactions[currentTransactionIndex] != null;
    }
}

interface IAccount {
    void addTransaction(String name, float amount, float taxRate, boolean isReconciled);
    IIterator<Transaction> createIterator();
}

class SalesAccount implements IAccount {
    private final List<Transaction> transactions;

    public SalesAccount() {
        transactions = new ArrayList<>();
        addTransaction("Start Industries", 200000000, 0, false);
        addTransaction("Wayne Enterprises", 5500000, 10, true);
        addTransaction("Oscorp", 100000, 20, false);
    }

    @Override
    public void addTransaction(String name, float amount, float taxRate, boolean isReconciled) {
        Transaction transaction = new Transaction(name, amount, taxRate, isReconciled);
        transactions.add(transaction);
    }

    @Override
    public IIterator<Transaction> createIterator() {
        return new SalesAccountIterator(transactions);
    }
}

class ExpenseAccount implements IAccount {
    private static final int maximumTransactions = 3;
    private int currentTransactionIndex = 0;
    private final Transaction[] transactions = new Transaction[maximumTransactions];

    public ExpenseAccount() {
        addTransaction("Gotham City Iron Works", -1500000, 10, true);
        addTransaction("Super Electronics", -100000, 20, false);
        addTransaction("Wakanda Vibranium Corporation", -100000000, 0, true);
    }

    @Override
    public void addTransaction(String name, float amount, float taxRate, boolean isReconciled) {
        Transaction transaction = new Transaction(name, amount, taxRate, isReconciled);
        if (currentTransactionIndex >= maximumTransactions) {
            System.out.println("The account is full! Can't add transaction to account");
        } else {
            transactions[currentTransactionIndex] = transaction;
            currentTransactionIndex++;
        }
    }

    @Override
    public IIterator<Transaction> createIterator() {
        return new ExpenseAccountIterator(transactions);
    }
}

class Accountant {
    private final SalesAccount salesAccount;
    private final ExpenseAccount expenseAccount;

    public Accountant(SalesAccount salesAccount, ExpenseAccount expenseAccount) {
        this.salesAccount = salesAccount;
        this.expenseAccount = expenseAccount;
    }

    public void printTransactions() {
        IIterator<Transaction> salesIterator = salesAccount.createIterator();
        IIterator<Transaction> expensesIterator = expenseAccount.createIterator();

        System.out.println("ACCOUNT\n----\nSALES");
        printTransactions(salesIterator);
        System.out.println("\nEXPENSES");
        printTransactions(expensesIterator);
    }

    private void printTransactions(IIterator<Transaction> transactionIterator) {
        while (transactionIterator.hasNextItem()) {
            Transaction transaction = transactionIterator.getNextItem();
            System.out.println(transaction.toString());
            System.out.println();
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Accountant accountant = new Accountant(new SalesAccount(), new ExpenseAccount());
        accountant.printTransactions();
    }
}