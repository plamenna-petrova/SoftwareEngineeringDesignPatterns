
class Context { }

class AbstractExpression {
    interpret(context) { }
}

class TerminalExpression extends AbstractExpression {
    interpret(context) {
        console.log("Called Terminal.Interpret()");
    }
}

class NonterminalExpression extends AbstractExpression {
    interpret(context) {
        console.log("Called Nonterminal.Interpret()");
    }
}

let context = new Context();

let listOfExpressions = [
    new TerminalExpression(),
    new NonterminalExpression(),
    new TerminalExpression(),
    new TerminalExpression()
];

for (let expression of listOfExpressions) {
    expression.interpret(context);
}