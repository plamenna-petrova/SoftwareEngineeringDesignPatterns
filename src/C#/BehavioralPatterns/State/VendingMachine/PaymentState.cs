using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class PaymentState : State
    {
        private decimal funds = 0;

        public PaymentState(VendingMachine vendingMachine) : base(vendingMachine)
        {
            Console.WriteLine($"PAYMENT - You can insert coins.");
        }

        public override void InsertMoney(decimal amount)
        {
            funds += amount;

            var selectedProduct = vendingMachine.Products.FirstOrDefault(p => p.Code == vendingMachine.SelectedProductCode);

            if (funds < selectedProduct.Price)
            {
                Console.WriteLine($"Remaining: {selectedProduct.Price - funds}");
            }
            else
            {
                Console.WriteLine($"Proper amount received");

                var change = funds - selectedProduct.Price;

                if (change > 0)
                {
                    Console.WriteLine($"Dispensing {change} amount");
                }

                vendingMachine.SetState(new DispenseProductState(vendingMachine));
                vendingMachine.DispenseProduct();
            }
        }

        public override void SelectProduct(string productCode) =>
            Console.WriteLine("The product is already selected. Please complete or cancel the current payment");

        public override void DispenseProduct() => Console.WriteLine("Cannot dispense product yet. Insufficient funds.");

        public override void Cancel()
        {
            Console.WriteLine("Cancelling order.");

            if (funds > 0)
            {
                Console.WriteLine($"Returning the amount of {funds}");
            }

            vendingMachine.SelectedProductCode = null;
            vendingMachine.SetState(new IdleState(vendingMachine));
        }

        public override void Refill(List<Product> products) =>
            Console.WriteLine("Cannot refill during payment operation. Please cancel or complete the payment before refill.");
    }
}
