<?php

class Calculator {
    private float $currentValue = 0;

    public function executeOperation($operator, $operand): void
    {
        $oldValue = 0;
        $oldValue = $this->currentValue;

        switch ($operator) {
            case '+':
                $this->currentValue += $operand;
                break;
            case '-':
                $this->currentValue -= $operand;
                break;
            case '*':
                $this->currentValue *= $operand;
                break;
            case '/':
                $this->currentValue /= $operand;
                break;
        }

        echo "Current value = {$oldValue} $operator $operand = {$this->currentValue}\n";
    }
}

abstract class Command {
    public abstract function execute();
    public abstract function undo();
}

class CalculatorCommand extends Command {
    private string $operator;
    private int $operand;
    private Calculator $calculator;

    public function __construct($calculator, $operator, $operand) {
        $this->calculator = $calculator;
        $this->operator = $operator;
        $this->operand = $operand;
    }

    public function execute(): void
    {
        $this->calculator->executeOperation($this->operator, $this->operand);
    }

    /**
     * @throws Exception
     */
    public function undo(): void
    {
        $previousOperator = $this->getPreviousOperator($this->operator);
        $this->calculator->executeOperation($previousOperator, $this->operand);
    }

    /**
     * @throws Exception
     */
    private function getPreviousOperator($operator): string
    {
        return match ($operator) {
            '+' => '-',
            '-' => '+',
            '*' => '/',
            '/' => '*',
            default => throw new Exception("Invalid operator"),
        };
    }
}

class User {
    private Calculator $calculator;
    private array $commands = [];
    private int $currentCommandIndex = 0;

    public function __construct() {
        $this->calculator = new Calculator();
    }

    public function redoCommand($levelsToMoveForward): void
    {
        echo "\n---- Redo $levelsToMoveForward levels\n";

        for ($i = 0; $i < $levelsToMoveForward; $i++) {
            if ($this->currentCommandIndex < count($this->commands) - 1) {
                $commandToRedo = $this->commands[$this->currentCommandIndex++];
                $commandToRedo->execute();
            }
        }
    }

    public function undoCommand($levelsToMoveBackward): void
    {
        echo "\n---- Undo $levelsToMoveBackward levels\n";

        for ($i = 0; $i < $levelsToMoveBackward; $i++) {
            if ($this->currentCommandIndex > 0) {
                $commandToUndo = $this->commands[--$this->currentCommandIndex];
                $commandToUndo->undo();
            }
        }
    }

    public function compute($operator, $operand): void
    {
        $commandToCompute = new CalculatorCommand($this->calculator, $operator, $operand);
        $commandToCompute->execute();

        $this->commands[] = $commandToCompute;
        $this->currentCommandIndex++;
    }
}

$user = new User();

$user->compute('+', 100);
$user->compute('-', 50);
$user->compute('*', 10);
$user->compute('/', 2);

$user->undoCommand(4);

$user->redoCommand(3);