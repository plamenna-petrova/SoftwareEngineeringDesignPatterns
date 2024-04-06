
class Context {
    constructor(input) {
        this.input = input;
        this.output = 0;
    }
}

class Expression {
    interpret(context) {
        if (context.input.length === 0) {
            return;
        }

        if (this.startsWithNine(context)) {
            context.output += (9 * this.multiplier());
            context.input = context.input.substring(2);
        } else if (this.startsWithFour(context)) {
            context.output += (4 * this.multiplier());
            context.input = context.input.substring(2);
        } else if (this.startsWithFive(context)) {
            context.output += (5 * this.multiplier());
            context.input = context.input.substring(1);
        }

        while (this.startsWithOne(context)) {
            context.output += (1 * this.multiplier());
            context.input = context.input.substring(1);
        }
    }

    startsWithNine(context) {
        return context.input.startsWith(this.nine());
    }

    startsWithFour(context) {
        return context.input.startsWith(this.four());
    }

    startsWithFive(context) {
        return context.input.startsWith(this.five());
    }

    startsWithOne(context) {
        return context.input.startsWith(this.one());
    }

    one() { 

    }

    four() { 

    }

    five() {

    }

    nine() {

    }

    multiplier() { 

    }
}

class ThousandExpression extends Expression {
    one() {
        return "M";
    }

    four() {
        return " ";
    }

    five() {
        return " ";
    }

    nine() {
        return " ";
    }

    multiplier() {
        return 1000;
    }
}

class HundredExpression extends Expression {
    one() {
        return "C";
    }

    four() {
        return "CD";
    }

    five() {
        return "D";
    }

    nine() {
        return "CM";
    }

    multiplier() {
        return 100;
    }
}

class TenExpression extends Expression {
    one() {
        return "X";
    }

    four() {
        return "XL";
    }

    five() {
        return "L";
    }

    nine() {
        return "XC";
    }

    multiplier() {
        return 10;
    }
}

class OneExpression extends Expression {
    one() {
        return "I";
    }

    four() {
        return "IV";
    }

    five() {
        return "V";
    }

    nine() {
        return "IX";
    }

    multiplier() {
        return 1;
    }
}

const romanNumber = "MCMXXVIII";
const context = new Context(romanNumber);

const expressionsTree = [
    new ThousandExpression(),
    new HundredExpression(),
    new TenExpression(),
    new OneExpression()
];

for (let expression of expressionsTree) {
    expression.interpret(context);
}

console.log(`${romanNumber} = ${context.output}`);