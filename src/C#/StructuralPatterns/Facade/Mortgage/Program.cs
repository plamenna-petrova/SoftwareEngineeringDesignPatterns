using System;

namespace Mortgage
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public class Bank
    {
        public bool HasSufficientSavings(Customer customer, int amount)
        {
            Console.WriteLine($"Check bank for {customer.Name} with amount: {amount}");
            return true;
        }
    }

    public class Credit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.WriteLine($"Check credit for {customer.Name}");
            return true;
        }
    }

    public class Loan
    {
        public bool HasNoBadLoans(Customer customer)
        {
            Console.WriteLine($"Check loans for {customer.Name}");
            return true;
        }
    }

    public class Mortgage
    {
        private readonly Bank bank = new Bank();

        private readonly Loan loan = new Loan();

        private readonly Credit credit = new Credit();

        public bool IsEligible(Customer customer, int amount)
        {
            Console.WriteLine($"{customer.Name} applies for {amount:C} loan \n");

            bool isEligible = true;

            if (!bank.HasSufficientSavings(customer, amount))
            {
                isEligible = false;
            }
            else if (!loan.HasNoBadLoans(customer))
            {
                isEligible = false;
            }
            else if (!credit.HasGoodCredit(customer))
            {
                isEligible = false;
            }

            return isEligible;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Mortgage mortgage = new Mortgage();

            Customer customer = new Customer("Ann McKinsey");

            bool isEligibleForMortgage = mortgage.IsEligible(customer, 1250000);

            Console.WriteLine($"\nCustomer {customer.Name} has been " +
                $"{(isEligibleForMortgage ? "Approved" : "Rejected")}");
        }
    }
}
