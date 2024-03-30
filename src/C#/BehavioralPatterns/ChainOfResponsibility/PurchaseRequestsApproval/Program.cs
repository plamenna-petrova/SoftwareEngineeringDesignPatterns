using System;

namespace PurchaseRequestsApproval
{
    public class Purchase
    {
        public Purchase(int number, double amount, string purpose)
        {
            Number = number;
            Amount = amount;
            Purpose = purpose;
        }

        public int Number { get; set; }

        public double Amount { get; set; }

        public string Purpose { get; set; }
    }

    public abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public string Name { get; set; }

        public abstract void ProcessRequest(Purchase purchase);
    }

    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}", GetType().Name, purchase.Number);
            }
            else
            {
                successor?.ProcessRequest(purchase);
            }
        }
    }

    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}", GetType().Name, purchase.Number);
            }
            else
            {
                successor?.ProcessRequest(purchase);
            }
        }
    }

    public class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}", GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine("Request# {0} requires an executive meeting!", purchase.Number);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Approver director = new Director() { Name = "Larry" };
            Approver vicePresident = new VicePresident() { Name = "Sam" };
            Approver president = new President() { Name = "Tammy" };

            director.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Purchase purchase = new Purchase(2034, 350.00, "Supplies");
            director.ProcessRequest(purchase);

            purchase = new Purchase(2035, 32590.10, "Project X");
            director.ProcessRequest(purchase);

            purchase = new Purchase(2036, 122100.00, "Project Y");
            director.ProcessRequest(purchase);
        }
    }
}
