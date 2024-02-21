
class CreditCard {
    static CREDIT_CARD_MINIMUM_LIMIT = 1000;
    static CREDIT_CARD_MAXIMUM_LIMIT = 10000000;
    static CREDIT_CARD_MINIMUM_ANNUAL_CHARGE = 1500;
    static CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE = 70000;
    static NULL_OR_WHITESPACE_CREDIT_CARD_MODEL_ERROR_MESSAGE = "The {0}'s model cannot be empty!";
    static CREDIT_CARD_LIMIT_OUT_OF_RANGE_ERROR_MESSAGE = "The credit card's limit must be between {0} and {1}!";
    static CREDIT_CARD_ANNUAL_CHARGE_OUT_OF_RANGE_ERROR_MESSAGE = "The credit card's annual charge must be between {0} and {1}!";
    static NON_NUMERIC_LIMIT_ERROR_MESSAGE = "The credit card's limit must be a number!";
    static NON_NUMERIC_ANNUAL_CHARGE_ERROR_MESSAGE = "The credit card's annual charge must be a number!";

    constructor(model, limit, annualCharge) {
        this.Model = model;
        this.Limit = limit;
        this.AnnualCharge = annualCharge;
    }

    set Model(value) {
        if (!value || value.trim() === "") {
            throw new Error(
                CreditCard.NULL_OR_WHITESPACE_CREDIT_CARD_MODEL_ERROR_MESSAGE.replace("{0}", this.constructor.name)
            );
        }
        this.model = value;
    }

    get Model() {
        return this.model;
    }

    set Limit(value) {
        if (isNaN(value)) {
            throw new Error(CreditCard.NON_NUMERIC_LIMIT_ERROR_MESSAGE);
        }

        value = parseFloat(value);

        if (value < CreditCard.CREDIT_CARD_MINIMUM_LIMIT || value > CreditCard.CREDIT_CARD_MAXIMUM_LIMIT) {
            throw new Error(
                CreditCard.CREDIT_CARD_LIMIT_OUT_OF_RANGE_ERROR_MESSAGE.replace("{0}", CreditCard.CREDIT_CARD_MINIMUM_LIMIT)
                    .replace("{1}", CreditCard.CREDIT_CARD_MAXIMUM_LIMIT)
            );
        }

        this.limit = value;
    }

    get Limit() {
        return this.limit;
    }

    set AnnualCharge(value) {
        if (isNaN(value)) {
            throw new Error(CreditCard.NON_NUMERIC_ANNUAL_CHARGE_ERROR_MESSAGE);
        }

        value = parseFloat(value);

        if (value < CreditCard.CREDIT_CARD_MINIMUM_ANNUAL_CHARGE || value > CreditCard.CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE) {
            throw new Error(
                CreditCard.CREDIT_CARD_ANNUAL_CHARGE_OUT_OF_RANGE_ERROR_MESSAGE.replace("{0}", CreditCard.CREDIT_CARD_MINIMUM_ANNUAL_CHARGE)
                    .replace("{1}", CreditCard.CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE)
            );
        }
        this.annualCharge = value;
    }

    get AnnualCharge() {
        return this.annualCharge;
    }

    toString() {
        return `Credit Card: ${this.constructor.name} with model: ${this.Model}, limit: ${this.Limit} and annual charge: ${this.AnnualCharge}`;
    }
}

module.exports = CreditCard;