<?php

namespace CreationalPatterns\Factory\CreditCards\Products;

class MoneyBack extends CreditCard
{
    public function __construct($model, $limit, $annualCharge)
    {
        parent::__construct($model, $limit, $annualCharge);
    }
}
