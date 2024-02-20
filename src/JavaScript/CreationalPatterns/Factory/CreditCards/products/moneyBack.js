
const CreditCard = require('./CreditCard');

class MoneyBack extends CreditCard {
    constructor(model, limit, annualCharge) {
        super(model, limit, annualCharge);
    }
}

module.exports = MoneyBack;