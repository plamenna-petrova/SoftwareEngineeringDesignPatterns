<?php

namespace CreditCards\Creators;

use CreditCards\Products\MoneyBack;

class MoneyBackCreditCardCreator implements ICreditCardCreator
{
    public function createCreditCard($model, $limit, $annualCharge): MoneyBack
    {
        return new MoneyBack($model, $limit, $annualCharge);
    }
}