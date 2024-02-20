
class CreditCard {
    static CreditCardMinimumLimit = 1000;
    static CreditCardMaximumLimit = 10000000;
    static CreditCardMinimumAnnualCharge = 1500;
    static CreditCardMaximumAnnualCharge = 70000;
    static NullOrWhiteSpaceCreditCardModelErrorMessage = "The {0}'s model cannot be empty!";
    static CreditCardLimitOutOfRangeErrorMessage = "The credit card's limit must be between {0} and {1}!";
    static CreditCardAnnualChargeOutOfRangeErrorMessage = "The credit card's annual charge must be between {0} and {1}!";
    static NonNumericLimitErrorMessage = "The credit card's limit must be a number!";
    static NonNumericAnnualChargeErrorMessage = "The credit card's annual charge must be a number!";

    constructor(model, limit, annualCharge) {
        this.Model = model;
        this.Limit = limit;
        this.AnnualCharge = annualCharge;
    }

    set Model(value) {
        if (!value || value.trim() === "") {
            throw new Error(
                CreditCard.NullOrWhiteSpaceCreditCardModelErrorMessage.replace("{0}", this.constructor.name)
            );
        }
        this.model = value;
    }

    get Model() {
        return this.model;
    }

    set Limit(value) {
        if (isNaN(value)) {
            throw new Error(CreditCard.NonNumericLimitErrorMessage);
        }

        value = parseFloat(value);

        if (value < CreditCard.CreditCardMinimumLimit || value > CreditCard.CreditCardMaximumLimit) {
            throw new Error(
                CreditCard.CreditCardLimitOutOfRangeErrorMessage.replace("{0}", CreditCard.CreditCardMinimumLimit)
                    .replace("{1}", CreditCard.CreditCardMaximumLimit)
            );
        }
        this.limit = value;
    }

    get Limit() {
        return this.limit;
    }

    set AnnualCharge(value) {
        if (isNaN(value)) {
            throw new Error(CreditCard.NonNumericAnnualChargeErrorMessage);
        }

        value = parseFloat(value);

        if (value < CreditCard.CreditCardMinimumAnnualCharge || value > CreditCard.CreditCardMaximumAnnualCharge) {
            throw new Error(
                CreditCard.CreditCardAnnualChargeOutOfRangeErrorMessage.replace("{0}", CreditCard.CreditCardMinimumAnnualCharge)
                    .replace("{1}", CreditCard.CreditCardMaximumAnnualCharge)
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