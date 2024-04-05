import java.util.ArrayList;
import java.util.List;

class Calculator {
    private int currentValue = 0;

    public void executeOperation(char operator, int operand) {
        int oldValue = currentValue;

        switch (operator) {
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
        System.out.printf("Current value = %3d %c %d = %3d\n", oldValue, operator, operand, currentValue);
    }
}

abstract class Command {
    public abstract void execute();
    public abstract void undo();
}

class CalculatorCommand extends Command {
    private char operator;
    private final int operand;
    private final Calculator calculator;

    public CalculatorCommand(Calculator calculator, char operator, int operand) {
        this.calculator = calculator;
        this.operator = operator;
        this.operand = operand;
    }

    public void setOperator(char operator) {
        this.operator = operator;
    }

    public char getOperator() {
        return operator;
    }

    public int getOperand() {
        return operand;
    }

    @Override
    public void execute() {
        calculator.executeOperation(operator, operand);
    }

    @Override
    public void undo() {
        char previousOperator = getPreviousOperator(operator);
        calculator.executeOperation(previousOperator, operand);
    }

    private char getPreviousOperator(char operator) {
        switch (operator) {
            case '+':
                return '-';
            case '-':
                return '+';
            case '*':
                return '/';
            case '/':
                return '*';
            default:
                throw new IllegalArgumentException("Invalid operator");
        }
    }
}

class User {
    private final Calculator calculator = new Calculator();
    private final List<Command> commands = new ArrayList<>();
    private int currentCommandIndex = 0;

    public void redoCommand(int levelsToMoveForward) {
        System.out.printf("\n---- Redo %d levels\n", levelsToMoveForward);

        for (int i = 0; i < levelsToMoveForward; i++) {
            if (currentCommandIndex < commands.size()) {
                Command commandToRedo = commands.get(currentCommandIndex++);
                commandToRedo.execute();
            }
        }
    }

    public void undoCommand(int levelsToMoveBackward) {
        System.out.printf("\n---- Undo %d levels\n", levelsToMoveBackward);

        for (int i = 0; i < levelsToMoveBackward; i++) {
            if (currentCommandIndex > 0) {
                Command commandToUndo = commands.get(--currentCommandIndex);
                commandToUndo.undo();
            }
        }
    }

    public void compute(char operator, int operand) {
        Command commandToCompute = new CalculatorCommand(calculator, operator, operand);
        commandToCompute.execute();
        commands.add(commandToCompute);
        currentCommandIndex++;
    }
}

public class Main {
    public static void main(String[] args) {
        User user = new User();
        user.compute('+', 100);
        user.compute('-', 50);
        user.compute('*', 10);
        user.compute('/', 2);
        user.undoCommand(4);
        user.redoCommand(3);
    }
}