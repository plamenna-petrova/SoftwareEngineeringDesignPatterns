using CreditCards.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCards.Creators
{
    public class TitaniumCreditCardCreator : ICreditCardCreator
    {
        public CreditCard CreateCreditCard(string model, decimal limit, decimal annualCharge)
           => new Titanium(model, limit, annualCharge);
    }
}
