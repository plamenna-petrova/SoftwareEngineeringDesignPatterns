
class Transaction {
    constructor(name, amount, taxRate, isReconciled) {
        this.name = name;
        this.amount = amount;
        this.taxRate = taxRate;
        this.isReconciled = isReconciled;
    }

    toString() {
        return `Name: ${this.name}\nAmount: ${this.amount}\nTax Rate: ${this.taxRate}\nIs Reconciled: ${this.isReconciled ? "Yes" : "No"}`;
    }
}

class IIterator {
    hasNextItem() {
        throw new Error("Method 'hasNextItem()' must be implemented.");
    }

    getNextItem() {
        throw new Error("Method 'getNextItem()' must be implemented.");
    }
}

class SalesAccountIterator extends IIterator {
    constructor(transactions) {
        super();
        this.transactions = transactions;
        this.currentTransactionIndex = 0;
    }

    getNextItem() {
        const transaction = this.transactions[this.currentTransactionIndex];
        this.currentTransactionIndex += 1;
        return transaction;
    }

    hasNextItem() {
        return this.currentTransactionIndex < this.transactions.length;
    }
}

class ExpenseAccountIterator extends IIterator {
    constructor(transactions) {
        super();
        this.transactions = transactions;
        this.currentTransactionIndex = 0;
    }

    getNextItem() {
        const transaction = this.transactions[this.currentTransactionIndex];
        this.currentTransactionIndex += 1;
        return transaction;
    }

    hasNextItem() {
        return this.currentTransactionIndex < this.transactions.length && this.transactions[this.currentTransactionIndex] !== null;
    }
}

class IAccount {
    addTransaction(name, amount, taxRate, isReconciled) {
        throw new Error("Method 'addTransaction()' must be implemented.");
    }

    createIterator() {
        throw new Error("Method 'createIterator()' must be implemented.");
    }
}

class SalesAccount extends IAccount {
    constructor() {
        super();
        this.transactions = [];

        this.addTransaction("Start Industries", 200000000, 0, false);
        this.addTransaction("Wayne Enterprises", 5500000, 10, true);
        this.addTransaction("Oscorp", 100000, 20, false);
    }

    addTransaction(name, amount, taxRate, isReconciled) {
        const transaction = new Transaction(name, amount, taxRate, isReconciled);
        this.transactions.push(transaction);
    }

    createIterator() {
        return new SalesAccountIterator(this.transactions);
    }
}

class ExpenseAccount extends IAccount {
    constructor() {
        super();
        this.maximumTransactions = 3;
        this.currentTransactionIndex = 0;
        this.transactions = Array(this.maximumTransactions).fill(null);

        this.addTransaction("Gotham City Iron Works", -1500000, 10, true);
        this.addTransaction("Super Electronics", -100000, 20, false);
        this.addTransaction("Wakanda Vibranium Corporation", -100000000, 0, true);
    }

    addTransaction(name, amount, taxRate, isReconciled) {
        const transaction = new Transaction(name, amount, taxRate, isReconciled);
        if (this.currentTransactionIndex >= this.maximumTransactions) {
            console.log("The account is full! Can't add transaction to account");
        } else {
            this.transactions[this.currentTransactionIndex] = transaction;
            this.currentTransactionIndex += 1;
        }
    }

    createIterator() {
        return new ExpenseAccountIterator(this.transactions);
    }
}

class Accountant {
    constructor(salesAccount, expenseAccount) {
        this.salesAccount = salesAccount;
        this.expenseAccount = expenseAccount;
    }

    printTransactions() {
        const salesIterator = this.salesAccount.createIterator();
        const expensesIterator = this.expenseAccount.createIterator();

        console.log("ACCOUNT\n----\nSALES");
        this.printTransactionsHelper(salesIterator);
        console.log("\nEXPENSES");
        this.printTransactionsHelper(expensesIterator);
    }

    printTransactionsHelper(transactionIterator) {
        while (transactionIterator.hasNextItem()) {
            const transaction = transactionIterator.getNextItem();
            console.log(transaction.toString());
            console.log();
        }
    }
}

const accountant = new Accountant(new SalesAccount(), new ExpenseAccount());
accountant.printTransactions();