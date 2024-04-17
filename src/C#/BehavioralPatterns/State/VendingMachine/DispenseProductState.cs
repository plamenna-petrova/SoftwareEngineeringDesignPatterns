using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VendingMachine
{
    public class DispenseProductState : State
    {
        public DispenseProductState(VendingMachine vendingMachine) : base(vendingMachine)
        {
            Console.WriteLine("DISPENSING");
        }

        public override void InsertMoney(decimal amount)
            => Console.WriteLine("Cannot insert money during the dispensing of the product");

        public override void SelectProduct(string productCode) => Console.WriteLine("The product is already selected.");

        public override void DispenseProduct()
        {
            if (vendingMachine.SelectedProductCode == null)
            {
                Console.WriteLine("There is no selected product for dispensing");
                vendingMachine.SetState(new IdleState(vendingMachine));
                return;
            }

            Console.WriteLine("Dispensing product.");
            Thread.Sleep(2000);

            var product = vendingMachine.Products.FirstOrDefault(p => p.Code == vendingMachine.SelectedProductCode);
            product.Stock--;

            vendingMachine.SelectedProductCode = null;

            Console.WriteLine("The product is dispensed.");

            if (vendingMachine.Products.All(p => p.Stock == 0))
            {
                vendingMachine.SetState(new SoldOutState(vendingMachine));
            }
            else
            {
                vendingMachine.SetState(new IdleState(vendingMachine));
            }
        }

        public override void Cancel() => Console.WriteLine("Cannot cancel the dispensing operation");

        public override void Refill(List<Product> products) =>
            Console.WriteLine("Cannot refill during the dispensing of the product");
    }
}
