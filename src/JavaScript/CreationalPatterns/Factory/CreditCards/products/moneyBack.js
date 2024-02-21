
const CreditCard = require('./creditCard');

class MoneyBack extends CreditCard {
    constructor(model, limit, annualCharge) {
        super(model, limit, annualCharge);
    }
}

module.exports = MoneyBack;