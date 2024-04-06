
class Context {
    constructor(date) {
        this.date = date;
        this.expression = '';
    }
}

class IExpression {
    evaluate(context) { }
}

class DayExpression extends IExpression {
    evaluate(context) {
        context.expression = context.expression.replace("DD", context.date.getDate());
    }
}

class MonthExpression extends IExpression {
    evaluate(context) {
        context.expression = context.expression.replace("MM", context.date.getMonth() + 1);
    }
}

class YearExpression extends IExpression {
    evaluate(context) {
        context.expression = context.expression.replace("YYYY", context.date.getFullYear());
    }
}

class SeparatorExpression extends IExpression {
    evaluate(context) {
        context.expression = context.expression.replace(/\s/g, "-");
    }
}

const prompt = require('prompt-sync')();

const dateExpressions = [];
const context = new Context(new Date());

console.log("Please select the Expression: MM DD YYYY or YYYY MM DD or DD MM YYYY ");

context.expression = prompt();

const dateExpressionSplittedArray = context.expression.split(' ');

for (let expressionComponent of dateExpressionSplittedArray) {
    if (expressionComponent === "DD") {
        dateExpressions.push(new DayExpression());
    } else if (expressionComponent === "MM") {
        dateExpressions.push(new MonthExpression());
    } else if (expressionComponent === "YYYY") {
        dateExpressions.push(new YearExpression());
    }
}

dateExpressions.push(new SeparatorExpression());

for (let dateExpression of dateExpressions) {
    dateExpression.evaluate(context);
}

console.log(context.expression);