
const ICreditCardCreator = require('./creditCardCreator');
const Titanium = require('../products/titanium');

/**
 * @implements {ICreditCardCreator}
 */
class TitaniumCreditCardCreator {
    /**
     * @inheritDoc
     */
    createCreditCard(model, limit, annualCharge) {
        return new Titanium(model, limit, annualCharge);
    }
}

module.exports = TitaniumCreditCardCreator;