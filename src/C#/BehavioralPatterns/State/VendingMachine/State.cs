using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public abstract class State
    {
        protected readonly VendingMachine vendingMachine;

        protected State(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }

        public abstract void InsertMoney(decimal amount);

        public abstract void SelectProduct(string productCode);

        public abstract void DispenseProduct();

        public abstract void Refill(List<Product> products);

        public abstract void Cancel();
    }
}
