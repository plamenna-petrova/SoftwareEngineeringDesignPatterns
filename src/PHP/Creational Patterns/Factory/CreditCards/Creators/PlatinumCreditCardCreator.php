<?php

namespace CreditCards\Creators;

use CreditCards\Products\Platinum;

class PlatinumCreditCardCreator implements ICreditCardCreator
{
    public function createCreditCard($model, $limit, $annualCharge): Platinum
    {
        return new Platinum($model, $limit, $annualCharge);
    }
}