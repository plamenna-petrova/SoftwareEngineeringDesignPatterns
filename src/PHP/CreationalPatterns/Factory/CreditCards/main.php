<?php

use CreationalPatterns\Factory\CreditCards\Creators\MoneyBackCreditCardCreator;
use CreationalPatterns\Factory\CreditCards\Creators\PlatinumCreditCardCreator;
use CreationalPatterns\Factory\CreditCards\Creators\TitaniumCreditCardCreator;
use CreationalPatterns\Factory\CreditCards\Extensions\StringExtensions;

require_once 'vendor/autoload.php';

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


