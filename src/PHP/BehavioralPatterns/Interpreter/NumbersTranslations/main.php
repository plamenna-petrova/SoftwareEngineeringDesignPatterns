<?php

class NumberContext
{
    private int $number;

    private string $result;

    public function __construct($number)
    {
        $this->number = $number;
    }

    public function getNumber(): int
    {
        return $this->number;
    }

    public function setResult($result): void
    {
        $this->result = $result;
    }

    public function getResult(): string
    {
        return $this->result;
    }
}

interface NumberExpression
{
    public function interpret(NumberContext $numberContext);
}

class ConcreteNumberExpression implements NumberExpression
{
    public function interpret(NumberContext $numberContext): void
    {
        $numberString = (string) $numberContext->getNumber();

        $numberTranslations = [
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine"
        ];

        $result = '';

        foreach (str_split($numberString) as $character) {
            $result .= $numberTranslations[(int) $character] . '-';
        }

        $result = rtrim($result, '-');

        $numberContext->setResult($result);
    }
}

$numberExpression = new ConcreteNumberExpression();
$numberContext = new NumberContext(3456);

$numberExpression->interpret($numberContext);

$result = $numberContext->getResult();

echo "The string is:\n";
echo $result . "\n";