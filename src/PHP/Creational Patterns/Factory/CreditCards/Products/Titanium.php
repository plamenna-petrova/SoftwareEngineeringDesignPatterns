<?php

namespace CreditCards\Products;

class Titanium extends CreditCard
{
    public function __construct($model, $limit, $annualCharge)
    {
        parent::__construct($model, $limit, $annualCharge);
    }
}