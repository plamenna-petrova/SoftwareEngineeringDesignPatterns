
const CreditCard = require('./CreditCard');

class Titanium extends CreditCard {
    constructor(model, limit, annualCharge) {
        super(model, limit, annualCharge);
    }
}

module.exports = Titanium;