import Creators.ICreditCardCreator;
import Creators.MoneyBackCreditCardCreator;
import Creators.PlatinumCreditCardCreator;
import Creators.TitaniumCreditCardCreator;
import Extensions.StringExtensions;
import Products.CreditCard;

import java.math.BigDecimal;
import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        try {
            ICreditCardCreator[] creditCardCreators = new ICreditCardCreator[]{
                    new MoneyBackCreditCardCreator(),
                    new TitaniumCreditCardCreator(),
                    new PlatinumCreditCardCreator()
            };

            List<CreditCard> creditCards = new ArrayList<>();

            for (ICreditCardCreator creditCardCreator : creditCardCreators) {
                String creditCardTypeFromCreator = StringExtensions.splitPascalCaseString(
                        creditCardCreator.getClass().getSimpleName()
                                .replace("Creator", "")
                );

                System.out.println("Enter credit card details for type " + creditCardTypeFromCreator + ": ");

                System.out.print("Enter model: ");
                String creditCardModel = new Scanner(System.in).nextLine();
                System.out.print("Enter limit: ");
                BigDecimal creditCardLimit = BigDecimal.valueOf(Double.parseDouble(new Scanner(System.in).nextLine()));
                System.out.print("Enter annual charge: ");
                double creditCardAnnualCharge = Double.parseDouble(new Scanner(System.in).nextLine());

                CreditCard createdCreditCard = creditCardCreator.createCreditCard(
                        creditCardModel, creditCardLimit, BigDecimal.valueOf(creditCardAnnualCharge)
                );

                creditCards.add(createdCreditCard);
            }

            for (CreditCard creditCard : creditCards) {
                System.out.println(creditCard.toString());
            }
        } catch (Exception exception) {
            if (exception instanceof NumberFormatException) {
                System.out.println("Aborting! Found entry with wrong format!");
            } else {
                System.out.println(exception.getMessage());
            }
        }
    }
}