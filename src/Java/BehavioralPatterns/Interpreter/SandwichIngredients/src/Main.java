import java.util.List;

class Context {
    private String output = "";

    public String getOutput() {
        return output;
    }

    public void setOutput(String output) {
        this.output = output;
    }
}

interface IExpression {
    void Interpret(Context context);
}

interface ICondiment extends IExpression {
}

interface IIngredient extends IExpression {
}

class KetchupCondiment implements ICondiment {
    public void Interpret(Context context) {
        context.setOutput(context.getOutput() + " Ketchup ");
    }
}

class MayonnaiseCondiment implements ICondiment {
    public void Interpret(Context context) {
        context.setOutput(context.getOutput() + " Mayonnaise ");
    }
}

class MustardCondiment implements ICondiment {
    public void Interpret(Context context) {
        context.setOutput(context.getOutput() + " Mustard ");
    }
}

class CondimentsList implements IExpression {
    private final List<ICondiment> condiments;

    public CondimentsList(List<ICondiment> condiments) {
        this.condiments = condiments;
    }

    public void Interpret(Context context) {
        for (ICondiment condiment : condiments) {
            condiment.Interpret(context);
        }
    }
}

class LettuceIngredient implements IIngredient {
    public void Interpret(Context context) {
        context.setOutput(context.getOutput() + " Lettuce ");
    }
}

class ChickenIngredient implements IIngredient {
    public void Interpret(Context context) {
        context.setOutput(context.getOutput() + " Chicken ");
    }
}

class IngredientsList implements IExpression {
    private final List<IIngredient> ingredients;

    public IngredientsList(List<IIngredient> ingredients) {
        this.ingredients = ingredients;
    }

    public void Interpret(Context context) {
        for (IIngredient ingredient : ingredients) {
            ingredient.Interpret(context);
        }
    }
}

interface IBread extends IExpression {
}

class WheatBread implements IBread {
    public void Interpret(Context context) {
        context.setOutput(context.getOutput() + " Wheat-Bread ");
    }
}

class WhiteBread implements IBread {
    public void Interpret(Context context) {
        context.setOutput(context.getOutput() + " White-Bread ");
    }
}

class Sandwich implements IExpression {
    private final IBread topBread;
    private final CondimentsList topCondiments;
    private final IngredientsList ingredients;
    private final CondimentsList bottomCondiments;
    private final IBread bottomBread;

    public Sandwich(
            IBread topBread,
            CondimentsList topCondiments,
            IngredientsList ingredients,
            CondimentsList bottomCondiments,
            IBread bottomBread
    ) {
        this.topBread = topBread;
        this.topCondiments = topCondiments;
        this.ingredients = ingredients;
        this.bottomCondiments = bottomCondiments;
        this.bottomBread = bottomBread;
    }

    public void Interpret(Context context) {
        context.setOutput("|");
        topBread.Interpret(context);
        context.setOutput(context.getOutput() + "|");
        context.setOutput(context.getOutput() + "<--");
        topCondiments.Interpret(context);
        context.setOutput(context.getOutput() + "-");
        ingredients.Interpret(context);
        context.setOutput(context.getOutput() + "-");
        bottomCondiments.Interpret(context);
        context.setOutput(context.getOutput() + "-->");
        context.setOutput(context.getOutput() + "|");
        bottomBread.Interpret(context);
        context.setOutput(context.getOutput() + "|");
        System.out.println(context.getOutput());
    }
}

class Program {
    public static void main(String[] args) {
        Sandwich sandwich = new Sandwich(
                new WheatBread(),
                new CondimentsList(List.of(new MayonnaiseCondiment(), new MustardCondiment())),
                new IngredientsList(List.of(new LettuceIngredient(), new ChickenIngredient())),
                new CondimentsList(List.of(new KetchupCondiment())),
                new WhiteBread()
        );

        sandwich.Interpret(new Context());
    }
}