<?php

namespace CreditCards\Creators;

use CreditCards\Products\Titanium;

class TitaniumCreditCardCreator implements ICreditCardCreator
{
    public function createCreditCard($model, $limit, $annualCharge): Titanium
    {
        return new Titanium($model, $limit, $annualCharge);
    }
}