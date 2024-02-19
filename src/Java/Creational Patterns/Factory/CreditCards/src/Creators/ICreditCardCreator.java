package Creators;

import Products.CreditCard;

import java.math.BigDecimal;

public interface ICreditCardCreator {
    CreditCard createCreditCard(String model, BigDecimal limit, BigDecimal annualCharge);
}
