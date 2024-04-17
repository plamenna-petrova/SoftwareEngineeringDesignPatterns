abstract class State {
    protected Account account;
    protected double balance;
    protected double interest;
    protected double lowerLimit;
    protected double upperLimit;

    public Account getAccount() {
        return account;
    }

    public double getBalance() {
        return balance;
    }

    public abstract void deposit(double amount);

    public abstract void withdraw(double amount);

    public abstract void payInterest();
}

class RedState extends State {
    private double serviceFee;

    public RedState(State state) {
        this.balance = state.balance;
        this.account = state.account;
        initialize();
    }

    private void initialize() {
        interest = 0.0;
        lowerLimit = -100.0;
        upperLimit = 0.0;
        serviceFee = 15.0;
    }

    @Override
    public void deposit(double amount) {
        balance += amount;
        checkStateChange();
    }

    @Override
    public void withdraw(double amount) {
        amount -= serviceFee;
        System.out.println("No funds available for withdrawal!");
    }

    @Override
    public void payInterest() {
        // No interest is paid
    }

    private void checkStateChange() {
        if (balance > upperLimit) {
            account.setState(new SilverState(this));
        }
    }
}

class SilverState extends State {
    public SilverState(State state) {
        this.balance = state.balance;
        this.account = state.account;
        initialize();
    }

    public SilverState(double balance, Account account) {
        this.balance = balance;
        this.account = account;
        initialize();
    }

    private void initialize() {
        interest = 0;
        lowerLimit = 0.0;
        upperLimit = 1000.0;
    }

    @Override
    public void deposit(double amount) {
        balance += amount;
        checkStateChange();
    }

    @Override
    public void withdraw(double amount) {
        balance -= amount;
        checkStateChange();
    }

    @Override
    public void payInterest() {
        balance += interest * balance;
        checkStateChange();
    }

    private void checkStateChange() {
        if (balance < lowerLimit) {
            account.setState(new RedState(this));
        } else if (balance > upperLimit) {
            account.setState(new GoldState(this));
        }
    }
}

class GoldState extends State {
    public GoldState(State state) {
        this.balance = state.balance;
        this.account = state.account;
        initialize();
    }

    public GoldState(double balance, Account account) {
        this.balance = balance;
        this.account = account;
        initialize();
    }

    private void initialize() {
        interest = 0.05;
        lowerLimit = 1000.0;
        upperLimit = 10000000.0;
    }

    @Override
    public void deposit(double amount) {
        balance += amount;
        checkStateChange();
    }

    @Override
    public void withdraw(double amount) {
        balance -= amount;
        checkStateChange();
    }

    @Override
    public void payInterest() {
        balance += interest * balance;
        checkStateChange();
    }

    private void checkStateChange() {
        if (balance < 0.0) {
            account.setState(new RedState(this));
        } else if (balance < lowerLimit) {
            account.setState(new SilverState(this));
        }
    }
}

class Account {
    private State state;

    public Account(String owner) {
        this.state = new SilverState(0.0, this);
    }

    public double getBalance() {
        return state.getBalance();
    }

    public State getState() {
        return state;
    }

    public void setState(State state) {
        this.state = state;
    }

    public void deposit(double amount) {
        state.deposit(amount);
        System.out.println(String.format("Deposited %.2f --- Balance = %.2f --- Status = %s\n", amount, getBalance(), getState().getClass().getSimpleName()));
    }

    public void withdraw(double amount) {
        state.withdraw(amount);
        System.out.println(String.format("Withdrew %.2f --- Balance = %.2f --- Status = %s\n", amount, getBalance(), getState().getClass().getSimpleName()));
    }

    public void payInterest() {
        state.payInterest();
        System.out.println(String.format("Interest Paid --- Balance = %.2f --- Status = %s\n", getBalance(), getState().getClass().getSimpleName()));
    }
}

public class Main {
    public static void main(String[] args) {
        Account account = new Account("Jim Johnson");

        account.deposit(500.0);
        account.deposit(300.0);
        account.deposit(550.0);
        account.payInterest();
        account.withdraw(2000.00);
        account.withdraw(1100.00);
    }
}