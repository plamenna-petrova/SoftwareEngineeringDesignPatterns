<?php

namespace CreationalPatterns\Factory\CreditCards\Products;

use InvalidArgumentException;
use CreationalPatterns\Factory\CreditCards\Extensions\StringExtensions;

class CreditCard
{
    private const CREDIT_CARD_MINIMUM_LIMIT = 1000;
    private const CREDIT_CARD_MAXIMUM_LIMIT = 10000000;
    private const CREDIT_CARD_MINIMUM_ANNUAL_CHARGE = 1500;
    private const CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE = 70000;

    private const NULL_OR_WHITESPACE_CREDIT_CARD_MODEL_ERROR_MESSAGE = "The %s's model cannot be empty!";
    private const CREDIT_CARD_LIMIT_OUT_OF_RANGE_ERROR_MESSAGE = "The credit card's limit must be between %s and %s!";
    private const CREDIT_CARD_ANNUAL_CHARGE_OUT_OF_RANGE_ERROR_MESSAGE = "The credit card's annual charge must be between %s and %s!";

    private string $model;
    private float $limit;
    private float $annualCharge;

    protected function __construct($model, $limit, $annualCharge)
    {
        $this->setModel($model);
        $this->setLimit($limit);
        $this->setAnnualCharge($annualCharge);
    }

    public function getModel(): string
    {
        return $this->model;
    }

    public function setModel($model): void
    {
        if (empty($model) || ctype_space($model)) {
            throw new InvalidArgumentException(
                sprintf(self::NULL_OR_WHITESPACE_CREDIT_CARD_MODEL_ERROR_MESSAGE, StringExtensions::splitPascalCaseString(get_class($this)))
            );
        }

        $this->model = $model;
    }

    public function getLimit(): float
    {
        return $this->limit;
    }

    public function setLimit($limit): void
    {
        if ($limit < self::CREDIT_CARD_MINIMUM_LIMIT || $limit > self::CREDIT_CARD_MAXIMUM_LIMIT) {
            throw new InvalidArgumentException(
                sprintf(self::CREDIT_CARD_LIMIT_OUT_OF_RANGE_ERROR_MESSAGE, self::CREDIT_CARD_MINIMUM_LIMIT, self::CREDIT_CARD_MAXIMUM_LIMIT)
            );
        }

        $this->limit = $limit;
    }

    public function getAnnualCharge(): float
    {
        return $this->annualCharge;
    }

    public function setAnnualCharge($annualCharge): void
    {
        if ($annualCharge < self::CREDIT_CARD_MINIMUM_ANNUAL_CHARGE || $annualCharge > self::CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE) {
            throw new InvalidArgumentException(
                sprintf(
                    self::CREDIT_CARD_ANNUAL_CHARGE_OUT_OF_RANGE_ERROR_MESSAGE,
                    self::CREDIT_CARD_MINIMUM_ANNUAL_CHARGE,
                    self::CREDIT_CARD_MAXIMUM_ANNUAL_CHARGE
                )
            );
        }

        $this->annualCharge = $annualCharge;
    }

    public function __toString()
    {
        return sprintf(
            "Credit Card: %s with model: %s, limit: %s and annual charge: %s",
            StringExtensions::splitPascalCaseString(get_class($this)),
            $this->getModel(),
            $this->getLimit(),
            $this->getAnnualCharge()
        );
    }
}
