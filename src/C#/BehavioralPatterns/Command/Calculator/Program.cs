using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Calculator
    {
        private int currentValue = 0;

        private int oldValue = 0;

        public void ExecuteOperation(char @operator, int operand)
        {
            oldValue = currentValue;

            switch (@operator)
            {
                case '+':
                    currentValue += operand;
                    break;
                case '-':
                    currentValue -= operand;
                    break;
                case '*':
                    currentValue *= operand;
                    break;
                case '/':
                    currentValue /= operand;
                    break;
            }

            Console.WriteLine($"Current value = {oldValue,3} {@operator} {operand} = {currentValue,3}");
        }
    }

    public abstract class Command
    {
        public abstract void Execute();

        public abstract void Undo();
    }

    public class CalculatorCommand : Command
    {
        private char @operator;

        private readonly int operand;

        private readonly Calculator calculator;

        public CalculatorCommand(Calculator calculator, char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }

        public char Operator { set => @operator = value; }

        public int Operand => operand;

        public override void Execute()
        {
            calculator.ExecuteOperation(@operator, operand);
        }

        public override void Undo()
        {
            char previousOperator = GetPreviousOperator(@operator);
            calculator.ExecuteOperation(previousOperator, operand);
        }

        private char GetPreviousOperator(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    return '-';
                case '-':
                    return '+';
                case '*':
                    return '/';
                case '/':
                    return '*';
                default:
                    throw new ArgumentException("@operator");
            }
        }
    }

    public class User
    {
        private readonly Calculator calculator = new Calculator();

        private readonly List<Command> commands = new List<Command>();

        private int currentCommandIndex = 0;

        public void RedoCommand(int levelsToMoveForward)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levelsToMoveForward);

            for (int i = 0; i < levelsToMoveForward; i++)
            {
                if (currentCommandIndex < commands.Count - 1)
                {
                    Command commandToRedo = commands[currentCommandIndex++];
                    commandToRedo.Execute();
                }
            }
        }

        public void UndoCommand(int levelsToMoveBackward)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levelsToMoveBackward);

            for (int i = 0; i < levelsToMoveBackward; i++)
            {
                if (currentCommandIndex > 0)
                {
                    Command commandToUndo = commands[--currentCommandIndex];
                    commandToUndo.Undo();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            Command commandToCompute = new CalculatorCommand(calculator, @operator, operand);
            commandToCompute.Execute();

            commands.Add(commandToCompute);
            currentCommandIndex++;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            user.UndoCommand(4);

            user.RedoCommand(3);
        }
    }
}
