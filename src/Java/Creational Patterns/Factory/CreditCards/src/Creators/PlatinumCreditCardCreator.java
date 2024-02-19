package Creators;

import Products.CreditCard;
import Products.Platinum;

import java.math.BigDecimal;

public class PlatinumCreditCardCreator implements ICreditCardCreator {
    @Override
    public CreditCard createCreditCard(String model, BigDecimal limit, BigDecimal annualCharge) {
        return new Platinum(model, limit, annualCharge);
    }
}
