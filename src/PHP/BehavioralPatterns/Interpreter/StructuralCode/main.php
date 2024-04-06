<?php

class Context
{
}

abstract class AbstractExpression
{
    abstract public function interpret($context);
}

class TerminalExpression extends AbstractExpression
{
    public function interpret($context): void
    {
        echo "Called TerminalExpression.interpret()\n";
    }
}

class NonterminalExpression extends AbstractExpression
{
    public function interpret($context): void
    {
        echo "Called NonterminalExpression.interpret()\n";
    }
}

$context = new Context();

$listOfExpressions = [
    new TerminalExpression(),
    new NonterminalExpression(),
    new TerminalExpression(),
    new TerminalExpression()
];

foreach ($listOfExpressions as $expression) {
    $expression->interpret($context);
}