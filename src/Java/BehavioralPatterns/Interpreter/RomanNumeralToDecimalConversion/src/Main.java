import java.util.ArrayList;
import java.util.List;

class Context {
    private String input;
    private int output;

    public Context(String input) {
        this.input = input;
    }

    public String getInput() {
        return input;
    }

    public void setInput(String input) {
        this.input = input;
    }

    public int getOutput() {
        return output;
    }

    public void setOutput(int output) {
        this.output = output;
    }
}

abstract class Expression {
    public void interpret(Context context) {
        if (context.getInput().isEmpty()) {
            return;
        }

        if (context.getInput().startsWith(nine())) {
            context.setOutput(context.getOutput() + (9 * multiplier()));
            context.setInput(context.getInput().substring(2));
        } else if (context.getInput().startsWith(four())) {
            context.setOutput(context.getOutput() + (4 * multiplier()));
            context.setInput(context.getInput().substring(2));
        } else if (context.getInput().startsWith(five())) {
            context.setOutput(context.getOutput() + (5 * multiplier()));
            context.setInput(context.getInput().substring(1));
        }

        while (context.getInput().startsWith(one())) {
            context.setOutput(context.getOutput() + (multiplier()));
            context.setInput(context.getInput().substring(1));
        }
    }

    public abstract String one();
    public abstract String four();
    public abstract String five();
    public abstract String nine();
    public abstract int multiplier();
}

class ThousandExpression extends Expression {
    @Override
    public String one() {
        return "M";
    }

    @Override
    public String four() {
        return " ";
    }

    @Override
    public String five() {
        return " ";
    }

    @Override
    public String nine() {
        return " ";
    }

    @Override
    public int multiplier() {
        return 1000;
    }
}

class HundredExpression extends Expression {
    @Override
    public String one() {
        return "C";
    }

    @Override
    public String four() {
        return "CD";
    }

    @Override
    public String five() {
        return "D";
    }

    @Override
    public String nine() {
        return "CM";
    }

    @Override
    public int multiplier() {
        return 100;
    }
}

class TenExpression extends Expression {
    @Override
    public String one() {
        return "X";
    }

    @Override
    public String four() {
        return "XL";
    }

    @Override
    public String five() {
        return "L";
    }

    @Override
    public String nine() {
        return "XC";
    }

    @Override
    public int multiplier() {
        return 10;
    }
}

class OneExpression extends Expression {
    @Override
    public String one() {
        return "I";
    }

    @Override
    public String four() {
        return "IV";
    }

    @Override
    public String five() {
        return "V";
    }

    @Override
    public String nine() {
        return "IX";
    }

    @Override
    public int multiplier() {
        return 1;
    }
}

class Program {
    public static void main(String[] args) {
        String romanNumber = "MCMXXVIII";
        Context context = new Context(romanNumber);
        List<Expression> expressionsTree = new ArrayList<>();
        expressionsTree.add(new ThousandExpression());
        expressionsTree.add(new HundredExpression());
        expressionsTree.add(new TenExpression());
        expressionsTree.add(new OneExpression());

        for (Expression expression : expressionsTree) {
            expression.interpret(context);
        }

        System.out.println(romanNumber + " = " + context.getOutput());
    }
}