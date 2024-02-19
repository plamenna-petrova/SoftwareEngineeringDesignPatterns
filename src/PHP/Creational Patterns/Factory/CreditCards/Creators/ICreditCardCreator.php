<?php

namespace CreditCards\Creators;

interface ICreditCardCreator
{
    public function createCreditCard($model, $limit, $annualCharge);
}