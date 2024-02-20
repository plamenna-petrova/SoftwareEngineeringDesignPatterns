using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCards.Products
{
    public class MoneyBack : CreditCard
    {
        public MoneyBack(string model, decimal limit, decimal annualCharge)
            : base(model, limit, annualCharge)
        {

        }
    }
}
