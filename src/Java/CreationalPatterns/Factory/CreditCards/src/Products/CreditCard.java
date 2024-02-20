package Products;

import Extensions.StringExtensions;

import java.math.BigDecimal;
import java.util.Objects;

public abstract class CreditCard {
    private static final int CREDIT_CARD_MINIMUM_LIMIT = 1000;
    private static final int CREDIT_CARD_MAXIMUM_LIMIT = 10000000;
    private static final int CREDIT_CARD_MINIMUM_ANNUAL_CHARGE = 1500;
    private static final int CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE = 70000;
    private static final String NULL_OR_WHITESPACE_CREDIT_CARD_MODEL_ERROR_MESSAGE = "The %s's model cannot be empty!";
    private static final String CREDIT_CARD_LIMIT_OUT_OF_RANGE_ERROR_MESSAGE = "The credit card's limit must be between %d and %d!";
    private static final String CREDIT_CARD_ANNUAL_CHARGE_OUT_OF_RANGE_ERROR_MESSAGE =
            "The credit card's annual charge must be between %d and %d!";

    private String model;
    private BigDecimal limit;
    private BigDecimal annualCharge;

    protected CreditCard(String model, BigDecimal limit, BigDecimal annualCharge) {
        setModel(model);
        setLimit(limit);
        setAnnualCharge(annualCharge);
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        if (Objects.requireNonNull(model).isBlank()) {
            throw new IllegalArgumentException(
                    String.format(NULL_OR_WHITESPACE_CREDIT_CARD_MODEL_ERROR_MESSAGE, getClass().getSimpleName()));
        }

        this.model = model;
    }

    public BigDecimal getLimit() {
        return limit;
    }

    public void setLimit(BigDecimal limit) {
        if (limit.compareTo(BigDecimal.valueOf(CREDIT_CARD_MINIMUM_LIMIT)) < 0 ||
                limit.compareTo(BigDecimal.valueOf(CREDIT_CARD_MAXIMUM_LIMIT)) > 0) {
            throw new IllegalArgumentException(String.format(CREDIT_CARD_LIMIT_OUT_OF_RANGE_ERROR_MESSAGE,
                    CREDIT_CARD_MINIMUM_LIMIT, CREDIT_CARD_MAXIMUM_LIMIT));
        }

        this.limit = limit;
    }

    public BigDecimal getAnnualCharge() {
        return annualCharge;
    }

    public void setAnnualCharge(BigDecimal annualCharge) {
        if (annualCharge.compareTo(BigDecimal.valueOf(CREDIT_CARD_MINIMUM_ANNUAL_CHARGE)) < 0 ||
                annualCharge.compareTo(BigDecimal.valueOf(CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE)) > 0) {
            throw new IllegalArgumentException(String.format(CREDIT_CARD_ANNUAL_CHARGE_OUT_OF_RANGE_ERROR_MESSAGE,
                    CREDIT_CARD_MINIMUM_ANNUAL_CHARGE, CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE));
        }

        this.annualCharge = annualCharge;
    }

    @Override
    public String toString() {
        return String.format("Credit Card: %s with model: %s, limit: %s and annual charge: %s",
                StringExtensions.splitPascalCaseString(getClass().getSimpleName()), getModel(), getLimit(), getAnnualCharge());
    }
}
