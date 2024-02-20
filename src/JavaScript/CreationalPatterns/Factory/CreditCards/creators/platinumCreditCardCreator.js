
const ICreditCardCreator = require('./creditCardCreator');
const Platinum = require('../products/platinum');

/**
 * @implements {ICreditCardCreator}
 */
class PlatinumCreditCardCreator {
    /**
     * @inheritDoc
     */
    createCreditCard(model, limit, annualCharge) {
        return new Platinum(model, limit, annualCharge);
    }
}

module.exports = PlatinumCreditCardCreator;