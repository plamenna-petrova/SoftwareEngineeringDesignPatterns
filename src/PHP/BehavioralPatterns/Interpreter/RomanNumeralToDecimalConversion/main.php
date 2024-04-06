<?php

class Context
{
    private string $input;
    private int $output;

    public function __construct($input)
    {
        $this->input = $input;
        $this->output = 0;
    }

    public function getInput(): string
    {
        return $this->input;
    }

    public function setInput($input): void
    {
        $this->input = $input;
    }

    public function getOutput(): int
    {
        return $this->output;
    }

    public function setOutput($output): void
    {
        $this->output = $output;
    }
}

abstract class Expression
{
    public function interpret(Context $context): void
    {
        if (empty($context->getInput())) {
            return;
        }

        if (str_starts_with($context->getInput(), $this->nine())) {
            $context->setOutput($context->getOutput() + (9 * $this->multiplier()));
            $context->setInput(substr($context->getInput(), 2));
        } elseif (str_starts_with($context->getInput(), $this->four())) {
            $context->setOutput($context->getOutput() + (4 * $this->multiplier()));
            $context->setInput(substr($context->getInput(), 2));
        } elseif (str_starts_with($context->getInput(), $this->five())) {
            $context->setOutput($context->getOutput() + (5 * $this->multiplier()));
            $context->setInput(substr($context->getInput(), 1));
        }

        while (str_starts_with($context->getInput(), $this->one())) {
            $context->setOutput($context->getOutput() + (1 * $this->multiplier()));
            $context->setInput(substr($context->getInput(), 1));
        }
    }

    public abstract function one();

    public abstract function four();

    public abstract function five();

    public abstract function nine();

    public abstract function multiplier();
}

class ThousandExpression extends Expression
{
    public function one(): string
    {
        return "M";
    }

    public function four(): string
    {
        return " ";
    }

    public function five(): string
    {
        return " ";
    }

    public function nine(): string
    {
        return " ";
    }

    public function multiplier(): int
    {
        return 1000;
    }
}

class HundredExpression extends Expression
{
    public function one(): string
    {
        return "C";
    }

    public function four(): string
    {
        return "CD";
    }

    public function five(): string
    {
        return "D";
    }

    public function nine(): string
    {
        return "CM";
    }

    public function multiplier(): int
    {
        return 100;
    }
}

class TenExpression extends Expression
{
    public function one(): string
    {
        return "X";
    }

    public function four(): string
    {
        return "XL";
    }

    public function five(): string
    {
        return "L";
    }

    public function nine(): string
    {
        return "XC";
    }

    public function multiplier(): int
    {
        return 10;
    }
}

class OneExpression extends Expression
{
    public function one(): string
    {
        return "I";
    }

    public function four(): string
    {
        return "IV";
    }

    public function five(): string
    {
        return "V";
    }

    public function nine(): string
    {
        return "IX";
    }

    public function multiplier(): int
    {
        return 1;
    }
}

$romanNumber = "MCMXXVIII";

$context = new Context($romanNumber);

$expressionsTree = [
    new ThousandExpression(),
    new HundredExpression(),
    new TenExpression(),
    new OneExpression()
];

foreach ($expressionsTree as $expression) {
    $expression->interpret($context);
}

echo "{$romanNumber} = {$context->getOutput()}\n";