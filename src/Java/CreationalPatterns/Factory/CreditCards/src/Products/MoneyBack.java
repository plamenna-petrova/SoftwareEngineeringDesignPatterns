package Products;

import java.math.BigDecimal;

public class MoneyBack extends CreditCard {
    public MoneyBack(String model, BigDecimal limit, BigDecimal annualCharge) {
        super(model, limit, annualCharge);
    }
}