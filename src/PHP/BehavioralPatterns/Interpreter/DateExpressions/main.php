<?php

class Context
{
    private DateTime $date;
    private string $expression;

    public function __construct($date)
    {
        $this->date = $date;
    }

    public function getExpression(): string
    {
        return $this->expression;
    }

    public function setExpression($expression): void
    {
        $this->expression = $expression;
    }

    public function getDate(): DateTime
    {
        return $this->date;
    }
}

interface Expression
{
    public function evaluate(Context $context);
}

class DayExpression implements Expression
{
    public function evaluate(Context $context): void
    {
        $expression = $context->getExpression();
        $context->setExpression(str_replace("DD", $context->getDate()->format('d'), $expression));
    }
}

class MonthExpression implements Expression
{
    public function evaluate(Context $context): void
    {
        $expression = $context->getExpression();
        $context->setExpression(str_replace("MM", $context->getDate()->format('m'), $expression));
    }
}

class YearExpression implements Expression
{
    public function evaluate(Context $context): void
    {
        $expression = $context->getExpression();
        $context->setExpression(str_replace("YYYY", $context->getDate()->format('Y'), $expression));
    }
}

class SeparatorExpression implements Expression
{
    public function evaluate(Context $context): void
    {
        $expression = $context->getExpression();
        $context->setExpression(str_replace(" ", "-", $expression));
    }
}

$dateExpressions = [];

$context = new Context(new DateTime());

echo "Please select the Expression: MM DD YYYY or YYYY MM DD or DD MM YYYY\n";
$context->setExpression(readline());

$dateExpressionSplittedArray = explode(' ', $context->getExpression());

foreach ($dateExpressionSplittedArray as $expressionComponent) {
    switch ($expressionComponent) {
        case "DD":
            $dateExpressions[] = new DayExpression();
            break;
        case "MM":
            $dateExpressions[] = new MonthExpression();
            break;
        case "YYYY":
            $dateExpressions[] = new YearExpression();
            break;
    }
}

$dateExpressions[] = new SeparatorExpression();

foreach ($dateExpressions as $dateExpression) {
    $dateExpression->evaluate($context);
}

echo $context->getExpression() . PHP_EOL;