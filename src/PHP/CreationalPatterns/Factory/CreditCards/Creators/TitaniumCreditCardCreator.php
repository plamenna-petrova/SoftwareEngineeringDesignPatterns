<?php

namespace CreationalPatterns\Factory\CreditCards\Creators;

use CreationalPatterns\Factory\CreditCards\Products\Titanium;

class TitaniumCreditCardCreator implements ICreditCardCreator
{
    public function createCreditCard($model, $limit, $annualCharge): Titanium
    {
        return new Titanium($model, $limit, $annualCharge);
    }
}