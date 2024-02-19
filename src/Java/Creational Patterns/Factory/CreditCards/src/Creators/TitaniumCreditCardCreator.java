package Creators;

import Products.CreditCard;
import Products.Titanium;

import java.math.BigDecimal;

public class TitaniumCreditCardCreator implements ICreditCardCreator {
    @Override
    public CreditCard createCreditCard(String model, BigDecimal limit, BigDecimal annualCharge) {
        return new Titanium(model, limit, annualCharge);
    }
}
