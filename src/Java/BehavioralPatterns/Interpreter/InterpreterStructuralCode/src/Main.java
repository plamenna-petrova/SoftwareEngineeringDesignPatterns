import java.util.ArrayList;
import java.util.List;

class Context {

}

abstract class AbstractExpression {
    public abstract void Interpret(Context context);
}

class TerminalExpression extends AbstractExpression {
    @Override
    public void Interpret(Context context) {
        System.out.println("Called TerminalExpression.Interpret()");
    }
}

class NonterminalExpression extends AbstractExpression {
    @Override
    public void Interpret(Context context) {
        System.out.println("Called NonterminalExpression.Interpret()");
    }
}

class Main {
    public static void main(String[] args) {
        Context context = new Context();

        List<AbstractExpression> listOfExpressions = new ArrayList<>();
        listOfExpressions.add(new TerminalExpression());
        listOfExpressions.add(new NonterminalExpression());
        listOfExpressions.add(new TerminalExpression());
        listOfExpressions.add(new TerminalExpression());

        for (AbstractExpression expression : listOfExpressions) {
            expression.Interpret(context);
        }
    }
}