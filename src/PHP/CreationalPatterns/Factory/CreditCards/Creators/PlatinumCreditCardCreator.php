<?php

namespace CreationalPatterns\Factory\CreditCards\Creators;

use CreationalPatterns\Factory\CreditCards\Products\Platinum;

class PlatinumCreditCardCreator implements ICreditCardCreator
{
    public function createCreditCard($model, $limit, $annualCharge): Platinum
    {
        return new Platinum($model, $limit, $annualCharge);
    }
}