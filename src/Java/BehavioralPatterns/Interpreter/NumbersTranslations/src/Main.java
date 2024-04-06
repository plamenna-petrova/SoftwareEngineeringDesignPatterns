class NumberContext {
    private int number;
    private String result = "";

    public NumberContext(int number) {
        this.number = number;
    }

    public int getNumber() {
        return number;
    }

    public void setNumber(int number) {
        this.number = number;
    }

    public String getResult() {
        return result;
    }

    public void setResult(String result) {
        this.result = result;
    }
}

interface INumberExpression {
    void Interpret(NumberContext context);
}

class NumberExpression implements INumberExpression {
    @Override
    public void Interpret(NumberContext numberContext) {
        String numberString = Integer.toString(numberContext.getNumber());

        String[] numberTranslations = {
                "Zero", "One", "Two", "Three", "Four",
                "Five", "Six", "Seven", "Eight", "Nine"
        };

        for (char character : numberString.toCharArray()) {
            numberContext.setResult(numberContext.getResult() + numberTranslations[Character.getNumericValue(character)] + "-");
        }

        numberContext.setResult(numberContext.getResult().substring(0, numberContext.getResult().length() - 1));
    }
}

class Main {
    public static void main(String[] args) {
        NumberExpression numberExpression = new NumberExpression();
        NumberContext numberContext = new NumberContext(3456);

        numberExpression.Interpret(numberContext);

        String result = numberContext.getResult();

        System.out.println("The string is:");
        System.out.println(result);
    }
}