<?php

namespace CreationalPatterns\Factory\CreditCards\Creators;

interface ICreditCardCreator
{
    public function createCreditCard($model, $limit, $annualCharge);
}