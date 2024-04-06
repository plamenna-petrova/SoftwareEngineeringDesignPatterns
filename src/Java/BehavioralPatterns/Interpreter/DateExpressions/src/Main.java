import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class Context {
    private String expression;
    private LocalDate date;

    public Context(LocalDate date) {
        this.date = date;
    }

    public String getExpression() {
        return expression;
    }

    public void setExpression(String expression) {
        this.expression = expression;
    }

    public LocalDate getDate() {
        return date;
    }

    public void setDate(LocalDate date) {
        this.date = date;
    }
}

interface IExpression {
    void evaluate(Context context);
}

class DayExpression implements IExpression {
    @Override
    public void evaluate(Context context) {
        context.setExpression(context.getExpression().replace("DD", Integer.toString(context.getDate().getDayOfMonth())));
    }
}

class MonthExpression implements IExpression {
    @Override
    public void evaluate(Context context) {
        context.setExpression(context.getExpression().replace("MM", Integer.toString(context.getDate().getMonthValue())));
    }
}

class YearExpression implements IExpression {
    @Override
    public void evaluate(Context context) {
        context.setExpression(context.getExpression().replace("YYYY", Integer.toString(context.getDate().getYear())));
    }
}

class SeparatorExpression implements IExpression {
    @Override
    public void evaluate(Context context) {
        context.setExpression(context.getExpression().replace(" ", "-"));
    }
}

class Program {
    public static void main(String[] args) {
        List<IExpression> dateExpressions = new ArrayList<>();

        Context context = new Context(LocalDate.now());

        System.out.println("Please select the Expression: MM DD YYYY or YYYY MM DD or DD MM YYYY ");

        Scanner scanner = new Scanner(System.in);
        context.setExpression(scanner.nextLine());

        String[] dateExpressionSplitArray = context.getExpression().split(" ");

        for (String expressionComponent : dateExpressionSplitArray) {
            switch (expressionComponent) {
                case "DD":
                    dateExpressions.add(new DayExpression());
                    break;
                case "MM":
                    dateExpressions.add(new MonthExpression());
                    break;
                case "YYYY":
                    dateExpressions.add(new YearExpression());
                    break;
            }
        }

        dateExpressions.add(new SeparatorExpression());

        for (IExpression dateExpression : dateExpressions) {
            dateExpression.evaluate(context);
        }

        System.out.println(context.getExpression());
    }
}