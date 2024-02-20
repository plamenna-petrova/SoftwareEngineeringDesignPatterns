using CreditCards.Creators;
using CreditCards.Extensions;
using CreditCards.Products;
using System;
using System.Collections.Generic;

namespace CreditCards
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ICreditCardCreator[] creditCardCreators = new ICreditCardCreator[]
                {
                    new MoneyBackCreditCardCreator(), 
                    new TitaniumCreditCardCreator(),
                    new PlatinumCreditCardCreator()
                };

                List<CreditCard> creditCards = new List<CreditCard>();

                foreach (var creditCardCreator in creditCardCreators)
                {
                    var creditCardTypeFromCreator = creditCardCreator.GetType().Name
                        .Replace("Creator", string.Empty)
                        .SplitPascalCaseString();

                    Console.WriteLine($"Enter credit card details for type {creditCardTypeFromCreator}: ");

                    Console.Write("Enter model: ");
                    string creditCardModel = Console.ReadLine();
                    Console.Write("Enter limit: ");
                    decimal creditCardLimit = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter annual charge: ");
                    decimal creditCardAnnualCharge = decimal.Parse(Console.ReadLine());

                    CreditCard createdCreditCard = creditCardCreator.CreateCreditCard(
                        creditCardModel, creditCardLimit, creditCardAnnualCharge
                    );

                    creditCards.Add(createdCreditCard);
                }

                foreach (var creditCard in creditCards)
                {
                    Console.WriteLine(creditCard.ToString());
                }
            }
            catch (Exception exception)
            {
                if (exception is FormatException)
                {
                    Console.WriteLine("Aborting! Found entry with wrong format!");
                }
                else
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
