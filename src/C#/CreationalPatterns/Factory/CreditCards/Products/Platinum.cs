using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCards.Products
{
    public class Platinum : CreditCard
    {
        public Platinum(string model, decimal limit, decimal annualCharge)
            : base(model, limit, annualCharge)
        {

        }
    }
}
