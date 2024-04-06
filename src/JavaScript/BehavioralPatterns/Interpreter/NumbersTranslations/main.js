
class NumberContext {
    constructor(number) {
        this.number = number;
        this.result = '';
    }
}

class INumberExpression {
    interpret(numberContext) { }
}

class NumberExpression extends INumberExpression {
    interpret(numberContext) {
        const numberString = numberContext.number.toString();

        const numberTranslations = [
            "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
        ];

        for (let character of numberString) {
            numberContext.result += `${numberTranslations[parseInt(character)]}-`;
        }

        numberContext.result = numberContext.result.slice(0, -1);
    }
}

const numberExpression = new NumberExpression();
const numberContext = new NumberContext(3456);

numberExpression.interpret(numberContext);

const result = numberContext.result;

console.log("The string is:");
console.log(result);