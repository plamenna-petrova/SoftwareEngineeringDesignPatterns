using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCards.Products
{
    public class Titanium : CreditCard
    {
        public Titanium(string model, decimal limit, decimal annualCharge)
            : base(model, limit, annualCharge)
        {

        }
    }
}
