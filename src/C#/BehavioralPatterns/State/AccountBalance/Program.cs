using System;

namespace AccountBalance
{
    public abstract class State
    {
        protected Account account;

        protected double balance;

        protected double interest;

        protected double lowerLimit;

        protected double upperLimit;

        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public abstract void Deposit(double amount);

        public abstract void Withdraw(double amount);

        public abstract void PayInterest();
    }

    public class RedState : State
    {
        private double serviceFee;

        public RedState(State state)
        {
            Balance = state.Balance;
            Account = state.Account;
            Initialize();
        }

        private void Initialize()
        {
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            serviceFee = 15.0;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            CheckStateChange();
        }

        public override void Withdraw(double amount)
        {
            amount -= serviceFee;
            Console.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest()
        {
            // No interest is paid
        }

        private void CheckStateChange()
        {
            if (balance > upperLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }

    public class SilverState : State
    {
        public SilverState(State state) : this(state.Balance, state.Account)
        {

        }

        public SilverState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            interest = 0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            CheckStateChange();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            CheckStateChange();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            CheckStateChange();
        }

        private void CheckStateChange()
        {
            if (balance < lowerLimit)
            {
                account.State = new RedState(this);
            }
            else if (balance > upperLimit)
            {
                account.State = new GoldState(this);
            }
        }
    }

    public class GoldState : State
    {
        public GoldState(State state) : this(state.Balance, state.Account)
        {

        }

        public GoldState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            CheckStateChange();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            CheckStateChange();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            CheckStateChange();
        }

        private void Initialize()
        {
            interest = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 10000000.0;
        }

        private void CheckStateChange()
        {
            if (balance < 0.0)
            {
                account.State = new RedState(this);
            }
            else if (balance < lowerLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }

    public class Account
    {
        private State state;

        private string owner;

        public Account(string owner)
        {
            this.owner = owner;
            state = new SilverState(0.0, this);
        }

        public double Balance => state.Balance;

        public State State { get => state; set => state = value; }

        public void Deposit(double amount)
        {
            state.Deposit(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", Balance);
            Console.WriteLine(" Status = {0}", State.GetType().Name);
            Console.WriteLine("");
        }

        public void Withdraw(double amount)
        {
            state.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", Balance);
            Console.WriteLine(" Status  = {0}\n", State.GetType().Name);
        }

        public void PayInterest()
        {
            state.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", Balance);
            Console.WriteLine(" Status = {0}\n", State.GetType().Name);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("Jim Johnson");

            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
        }
    }
}
