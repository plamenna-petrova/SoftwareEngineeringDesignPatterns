<?php

namespace CreationalPatterns\Factory\CreditCards\Creators;

use CreationalPatterns\Factory\CreditCards\Products\MoneyBack;

class MoneyBackCreditCardCreator implements ICreditCardCreator
{
    public function createCreditCard($model, $limit, $annualCharge): MoneyBack
    {
        return new MoneyBack($model, $limit, $annualCharge);
    }
}