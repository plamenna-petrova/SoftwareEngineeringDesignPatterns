<?php

namespace CreditCards\Products;

class Platinum extends CreditCard
{
    public function __construct($model, $limit, $annualCharge)
    {
        parent::__construct($model, $limit, $annualCharge);
    }
}