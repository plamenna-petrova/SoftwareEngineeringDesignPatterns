
class Calculator {
    constructor() {
        this.currentValue = 0;
        this.oldValue = 0;
    }

    executeOperation(operator, operand) {
        this.oldValue = this.currentValue;

        switch (operator) {
            case '+':
                this.currentValue += operand;
                break;
            case '-':
                this.currentValue -= operand;
                break;
            case '*':
                this.currentValue *= operand;
                break;
            case '/':
                this.currentValue /= operand;
                break;
        }

        console.log(`Current value = ${this.oldValue} ${operator} ${operand} = ${this.currentValue}`);
    }
}

class Command {
    execute() {

    }

    undo() {

    }
}

class CalculatorCommand extends Command {
    constructor(calculator, operator, operand) {
        super();
        this.calculator = calculator;
        this.operator = operator;
        this.operand = operand;
    }

    execute() {
        this.calculator.executeOperation(this.operator, this.operand);
    }

    undo() {
        const previousOperator = this.getPreviousOperator(this.operator);
        this.calculator.executeOperation(previousOperator, this.operand);
    }

    getPreviousOperator(operator) {
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
                throw new Error("Invalid operator");
        }
    }
}

class User {
    constructor() {
        this.calculator = new Calculator();
        this.commands = [];
        this.currentCommandIndex = 0;
    }

    redoCommand(levelsToMoveForward) {
        console.log(`\n---- Redo ${levelsToMoveForward} levels `);

        for (let i = 0; i < levelsToMoveForward; i++) {
            if (this.currentCommandIndex < this.commands.length - 1) {
                const commandToRedo = this.commands[this.currentCommandIndex++];
                commandToRedo.execute();
            }
        }
    }

    undoCommand(levelsToMoveBackward) {
        console.log(`\n---- Undo ${levelsToMoveBackward} levels `);

        for (let i = 0; i < levelsToMoveBackward; i++) {
            if (this.currentCommandIndex > 0) {
                const commandToUndo = this.commands[--this.currentCommandIndex];
                commandToUndo.undo();
            }
        }
    }

    compute(operator, operand) {
        const commandToCompute = new CalculatorCommand(this.calculator, operator, operand);
        commandToCompute.execute();

        this.commands.push(commandToCompute);
        this.currentCommandIndex++;
    }
}

const user = new User();

user.compute('+', 100);
user.compute('-', 50);
user.compute('*', 10);
user.compute('/', 2);

user.undoCommand(4);

user.redoCommand(3);