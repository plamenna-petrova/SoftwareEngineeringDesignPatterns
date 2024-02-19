<?php

use CreditCards\Creators\MoneyBackCreditCardCreator;
use CreditCards\Creators\PlatinumCreditCardCreator;
use CreditCards\Creators\TitaniumCreditCardCreator;
use CreditCards\Extensions\StringExtensions;

$creditCardCreators = [
    new MoneyBackCreditCardCreator(),
    new TitaniumCreditCardCreator(),
    new PlatinumCreditCardCreator()
];

$creditCards = [];

foreach ($creditCardCreators as $creditCardCreator) {
    $creditCardTypeFromCreator = get_class($creditCardCreator);
    $creditCardTypeFromCreator = StringExtensions::splitPascalCaseString($creditCardTypeFromCreator);

    echo "Enter credit card details for type $creditCardTypeFromCreator: \n";

    echo "Enter model: ";
    $creditCardModel = trim(fgets(STDIN));
    echo "Enter limit: ";
    $creditCardLimit = (float)trim(fgets(STDIN));
    echo "Enter annual charge: ";
    $creditCardAnnualCharge = (float)trim(fgets(STDIN));

    $createdCreditCard = $creditCardCreator->createCreditCard(
        $creditCardModel,
        $creditCardLimit,
        $creditCardAnnualCharge
    );

    $creditCards[] = $createdCreditCard;
}

foreach ($creditCards as $creditCard) {
    echo $creditCard->__toString() . "\n";
}


