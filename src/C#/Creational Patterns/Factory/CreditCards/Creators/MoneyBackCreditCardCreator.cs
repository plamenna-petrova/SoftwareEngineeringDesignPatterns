using CreditCards.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCards.Creators
{
    public class MoneyBackCreditCardCreator : ICreditCardCreator
    {
        public CreditCard CreateCreditCard(string model, decimal limit, decimal annualCharge)
            => new MoneyBack(model, limit, annualCharge);
    }
}
