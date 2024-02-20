package Creators;

import Products.CreditCard;
import Products.MoneyBack;

import java.math.BigDecimal;

public class MoneyBackCreditCardCreator implements ICreditCardCreator {
    @Override
    public CreditCard createCreditCard(String model, BigDecimal limit, BigDecimal annualCharge) {
        return new MoneyBack(model, limit, annualCharge);
    }
}
