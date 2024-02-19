using CreditCards.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCards.Products
{
    public abstract class CreditCard
    {
        private const int CreditCardMinimumLimit = 1000;

        private const int CreditCardMaximumLimit = 10000000;

        private const int CreditCardMinimumAnnualCharge = 1500;

        private const int CreditCardMaximumAnnualCharge = 70000;

        private const string NullOrWhiteSpaceCreditCardModelErrorMessage = "The {0}'s model cannot be empty!";

        private const string CreditCardLimitOutOfRangeErrorMessage = "The credit card's limit must be between {0} and {1}!";

        private const string CreditCardAnnualChargeOutOfRangeErrorMessage = "The credit card's annual charge must be between {0} and {1}!";

        private string model;

        private decimal limit;

        private decimal annualCharge;

        protected CreditCard(string model, decimal limit, decimal annualCharge)
        {
            Model = model;
            Limit = limit;
            AnnualCharge = annualCharge;
        }

        public string Model
        {
            get => model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        string.Format(NullOrWhiteSpaceCreditCardModelErrorMessage, GetType().Name.SplitPascalCaseString())
                    );
                }

                model = value;
            }
        }

        public decimal Limit
        {
            get => limit;
            set
            {
                if (value < CreditCardMinimumLimit || value > CreditCardMaximumLimit)
                {
                    throw new ArgumentException(
                        string.Format(CreditCardLimitOutOfRangeErrorMessage, CreditCardMinimumLimit, CreditCardMaximumLimit)
                    );
                }

                limit = value;
            }
        }

        public decimal AnnualCharge
        {
            get => annualCharge;
            set
            {
                if (value < CreditCardMinimumAnnualCharge || value > CreditCardMaximumAnnualCharge)
                {
                    throw new ArgumentException(string.Format(
                        CreditCardAnnualChargeOutOfRangeErrorMessage, CreditCardMinimumAnnualCharge, CreditCardMaximumAnnualCharge)
                    );
                }

                annualCharge = value;
            }
        }

        public override string ToString()
        {
            return $"Credit Card: {GetType().Name.SplitPascalCaseString()} with model: {Model}, limit: {Limit} and annual charge: {AnnualCharge}";
        }
    }
}
