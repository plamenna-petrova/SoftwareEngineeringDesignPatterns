using System;

namespace Invoices
{
    public interface IInvoiceState
    {
        void Pay(Invoice invoice);

        void Cancel(Invoice invoice);

        void Refund(Invoice invoice);
    }

    public class Invoice
    {
        public Invoice(int number, decimal amount, string description)
        {
            Number = number;
            Amount = amount;
            Description = description;
            State = new UnpaidState();
        }

        public int Number { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public IInvoiceState State { get; set; }

        public void Pay()
        {
            State.Pay(this);
            State = new PaidState();
        }

        public void Cancel()
        {
            State.Cancel(this);
            State = new CanceledState();
        }

        public void Refund()
        {
            State.Refund(this);
            State = new RefundedState();
        }
    }

    public class UnpaidState : IInvoiceState
    {
        public void Pay(Invoice invoice)
        {
            Console.WriteLine($"Paying invoice {invoice.Number}...");
        }

        public void Cancel(Invoice invoice)
        {
            Console.WriteLine($"Cancelling invoice {invoice.Number}...");
        }

        public void Refund(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} is unpaid and cannot be refunded.");
        }
    }

    public class PaidState : IInvoiceState
    {
        public void Pay(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} has already been paid.");
        }

        public void Cancel(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} cannot be cancelled.");
        }

        public void Refund(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} has been refunded.");
        }
    }

    public class CanceledState : IInvoiceState
    {
        public void Pay(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} has been cancelled and cannot be paid.");
        }

        public void Cancel(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} has been cancelled and cannot be cancelled again.");
        }

        public void Refund(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} has been cancelled and cannot be refunded.");
        }
    }

    public class RefundedState : IInvoiceState
    {
        public void Pay(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} was refunded and cannot be paid.");
        }

        public void Cancel(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} was refunded and cannot be cancelled.");
        }

        public void Refund(Invoice invoice)
        {
            Console.WriteLine($"Invoice {invoice.Number} was refunded and cannot be refunded again.");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var invoice = new Invoice(123, 1000m, "Software Devs Services");

            invoice.Pay();
            invoice.Refund();
        }
    }
}
