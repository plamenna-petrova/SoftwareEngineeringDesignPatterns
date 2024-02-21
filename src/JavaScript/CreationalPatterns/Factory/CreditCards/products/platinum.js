
const CreditCard = require('./creditCard');

class Platinum extends CreditCard {
    constructor(model, limit, annualCharge) {
        super(model, limit, annualCharge);
    }
}

module.exports = Platinum;