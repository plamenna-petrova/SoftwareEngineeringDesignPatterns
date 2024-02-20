
/**
 * @interface
 */
 class ICreditCardCreator {
    /**
     * @param {string} model
     * @param {number} limit
     * @param {number} annualCharge
     * @returns {CreditCard}
     */
    createCreditCard(model, limit, annualCharge) {
        
    }
}

module.exports = ICreditCardCreator;