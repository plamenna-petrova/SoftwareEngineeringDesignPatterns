class State {
    constructor(account) {
        console.log("account");
        console.log(account);
        this.account = account;
        this.balance = 0;
        this.interest = 0;
        this.lowerLimit = 0;
        this.upperLimit = 0;
    }

    deposit(amount) {
        throw new Error("Method 'deposit' must be implemented.");
    }

    withdraw(amount) {
        throw new Error("Method 'withdraw' must be implemented.");
    }

    payInterest() {
        throw new Error("Method 'payInterest' must be implemented.");
    }
}

class RedState extends State {
    constructor(state) {
        super(state.account);
        this.balance = state.balance;
        this.account = state.account;
        this.initialize();
    }

    initialize() {
        this.interest = 0;
        this.lowerLimit = -100.0;
        this.upperLimit = 0.0;
        this.serviceFee = 15.0;
    }

    deposit(amount) {
        this.balance += amount;
        this.checkStateChange();
    }

    withdraw(amount) {
        amount -= this.serviceFee;
        console.log("No funds available for withdrawal!");
    }

    payInterest() {
        // No interest is paid
    }

    checkStateChange() {
        if (this.balance > this.upperLimit) {
            this.account.setState(new SilverState(this.account));
        }
    }
}

class SilverState extends State {
    constructor(state) {
        super(state.account);
        this.balance = state.balance;
        this.account = state.account;
        this.initialize();
    }

    initialize() {
        this.interest = 0;
        this.lowerLimit = 0.0;
        this.upperLimit = 1000.0;
    }

    deposit(amount) {
        this.balance += amount;
        this.checkStateChange();
    }

    withdraw(amount) {
        this.balance -= amount;
        this.checkStateChange();
    }

    payInterest() {
        this.balance += this.interest * this.balance;
        this.checkStateChange();
    }

    checkStateChange() {
        if (this.balance < this.lowerLimit) {
            this.account.setState(new RedState(this.account));
        } else if (this.balance > this.upperLimit) {
            console.log(this.account);       
            this.account.setState(new GoldState(this.account)); 
        }
    }
}

class GoldState extends State {
    constructor(state) {
        super(state.account);
        this.balance = state.balance;
        this.account = state.account;
        this.initialize();
    }

    initialize() {
        this.interest = 0.05;
        this.lowerLimit = 1000.0;
        this.upperLimit = 10000000.0;
    }

    deposit(amount) {
        this.balance += amount;
        this.checkStateChange();
    }

    withdraw(amount) {
        this.balance -= amount;
        this.checkStateChange();
    }

    payInterest() {
        this.balance += this.interest * this.balance;
        this.checkStateChange();
    }

    checkStateChange() {
        if (this.balance < 0.0) {
            this.account.setState(new RedState(this.account));
        } else if (this.balance < this.lowerLimit) {
            this.account.setState(new SilverState(this.account)); 
        }
    }
}

class Account {
    constructor(owner) {
        this.owner = owner;
        this.state = new SilverState(this);
        console.log(this.state);
    }

    get balance() {
        return this.state ? this.state.balance : 0;
    }

    setState(state) {
        this.state = state;
    }

    deposit(amount) {
        this.state.deposit(amount);
        console.log(`Deposited $${amount.toFixed(2)}`);
        console.log(`Balance = $${this.balance.toFixed(2)}`);
        console.log(`Status = ${this.state.constructor.name}\n`);
    }

    withdraw(amount) {
        this.state.withdraw(amount);
        console.log(`Withdrew $${amount.toFixed(2)}`);
        console.log(`Balance = $${this.balance.toFixed(2)}`);
        console.log(`Status = ${this.state.constructor.name}\n`);
    }

    payInterest() {
        this.state.payInterest();
        console.log("Interest Paid");
        console.log(`Balance = $${this.balance.toFixed(2)}`);
        console.log(`Status = ${this.state.constructor.name}\n`);
    }
}

const account = new Account("Jim Johnson");

account.deposit(500.0);
account.deposit(300.0);
account.deposit(550.0);
account.payInterest();
account.withdraw(2000.0);
account.withdraw(1100.0);