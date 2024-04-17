using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine
{
    public class SoldOutState : State
    {
        public SoldOutState(VendingMachine vendingMachine) : base(vendingMachine)
        {
            Console.WriteLine("SOLDOUT");
        }

        public override void InsertMoney(decimal amount) => Console.WriteLine("There are no products in the vending machine.");

        public override void SelectProduct(string productCode) => Console.WriteLine("There are no products in the vending machine.");

        public override void DispenseProduct() => Console.WriteLine("There is no selected product for dispensing");

        public override void Cancel() => Console.WriteLine("There is no operation to be cancelled");

        public override void Refill(List<Product> products)
        {
            vendingMachine.Products = products;
            Console.WriteLine($"Total amount of products: {vendingMachine.Products.Sum(p => p.Stock)}");
            vendingMachine.SetState(new IdleState(vendingMachine));
        }
    }
}
