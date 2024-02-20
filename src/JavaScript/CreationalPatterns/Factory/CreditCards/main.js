
const MoneyBackCreditCardCreator = require('./creators/moneyBackCreditCardCreator');
const TitaniumCreditCardCreator = require('./creators/titaniumCreditCardCreator');
const PlatinumCreditCardCreator = require('./creators/platinumCreditCardCreator');
const { splitPascalCaseString } = require('./extensions/stringExtensions');

const prompt = require("prompt-sync")();

try {
    const creditCardCreators = [
        new MoneyBackCreditCardCreator(),
        new TitaniumCreditCardCreator(),
        new PlatinumCreditCardCreator()
    ];

    const creditCards = [];

    for (const creditCardCreator of creditCardCreators) {
        const creditCardTypeFromCreator = splitPascalCaseString(
            creditCardCreator.constructor.name.replace('CreditCardCreator', '')
        );

        console.log(`Enter credit card details for type ${creditCardTypeFromCreator}: `);

        const creditCardModel = prompt('Enter model: ');
        const creditCardLimit = parseFloat(prompt('Enter limit: '));
        const creditCardAnnualCharge = parseFloat(prompt('Enter annual charge: '));

        const createdCreditCard = creditCardCreator.createCreditCard(
            creditCardModel, creditCardLimit, creditCardAnnualCharge
        );

        creditCards.push(createdCreditCard);
    }

    for (const creditCard of creditCards) {
        console.log(creditCard.toString());
    }
} catch (exception) {
    if (exception instanceof SyntaxError) {
        console.log('Aborting! Found entry with wrong format!');
    } else {
        console.log(exception.message);
    }
}