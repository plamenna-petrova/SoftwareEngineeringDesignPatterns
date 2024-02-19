package Products;

import java.math.BigDecimal;

public class Platinum extends CreditCard {
    public Platinum(String model, BigDecimal limit, BigDecimal annualCharge) {
        super(model, limit, annualCharge);
    }
}