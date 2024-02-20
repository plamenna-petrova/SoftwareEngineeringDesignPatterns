
const ICreditCardCreator = require('./creditCardCreator');
const MoneyBack = require('../products/moneyBack');

/**
 * @implements {ICreditCardCreator}
 */
class MoneyBackCreditCardCreator {
    /**
     * @inheritDoc
     */
    createCreditCard(model, limit, annualCharge) {
        return new MoneyBack(model, limit, annualCharge);
    }
}

module.exports = MoneyBackCreditCardCreator;