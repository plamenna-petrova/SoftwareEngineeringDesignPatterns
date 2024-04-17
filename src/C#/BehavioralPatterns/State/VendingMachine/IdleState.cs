using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class IdleState : State
    {
        public IdleState(VendingMachine vendingMachine) : base(vendingMachine)
        {
            Console.WriteLine("IDLE - Wait for product selection");
        }

        public override void InsertMoney(decimal amount)
        {
            Console.WriteLine("Please select a product before inserting any money.");
        }

        public override void SelectProduct(string productCode)
        {
            var selectedProduct = vendingMachine.Products.FirstOrDefault(p => p.Code == productCode);

            if (selectedProduct.Stock == 0)
            {
                Console.WriteLine($"The product code: {selectedProduct.Code} is out of stock");
                return;
            }

            vendingMachine.SelectedProductCode = selectedProduct.Code;
            Console.WriteLine($"Product: {selectedProduct.Code} with price: {selectedProduct.Price} selected.");
            vendingMachine.SetState(new PaymentState(vendingMachine));
        }

        public override void DispenseProduct() => Console.WriteLine("Select a product first.");

        public override void Cancel() => Console.WriteLine("There is no selected product or payment in process to cancel.");

        public override void Refill(List<Product> products)
        {
            vendingMachine.Products = products;
            Console.WriteLine($"Total amount of products: {vendingMachine.Products.Sum(p => p.Stock)}");
        }
    }
}
