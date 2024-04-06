
class Context {
    constructor() {
        this.output = '';
    }
}

class IExpression {
    interpret(context) { }
}

class ICondiment extends IExpression { }

class IIngredient extends IExpression { }

class KetchupCondiment extends ICondiment {
    interpret(context) {
        context.output += ` Ketchup `;
    }
}

class MayonnaiseCondiment extends ICondiment {
    interpret(context) {
        context.output += ` Mayonnaise `;
    }
}

class MustardCondiment extends ICondiment {
    interpret(context) {
        context.output += ` Mustard `;
    }
}

class CondimentsList extends IExpression {
    constructor(condiments) {
        super();
        this.condiments = condiments;
    }

    interpret(context) {
        for (let condiment of this.condiments) {
            condiment.interpret(context);
        }
    }
}

class LettuceIngredient extends IIngredient {
    interpret(context) {
        context.output += ` Lettuce `;
    }
}

class ChickenIngredient extends IIngredient {
    interpret(context) {
        context.output += ` Chicken `;
    }
}

class IngredientsList extends IExpression {
    constructor(ingredients) {
        super();
        this.ingredients = ingredients;
    }

    interpret(context) {
        for (let ingredient of this.ingredients) {
            ingredient.interpret(context);
        }
    }
}

class IBread extends IExpression { }

class WheatBread extends IBread {
    interpret(context) {
        context.output += ` Wheat-Bread `;
    }
}

class WhiteBread extends IBread {
    interpret(context) {
        context.output += ` White-Bread `;
    }
}

class Sandwich extends IExpression {
    constructor(topBread, topCondiments, ingredients, bottomCondiments, bottomBread) {
        super();
        this.topBread = topBread;
        this.topCondiments = topCondiments;
        this.ingredients = ingredients;
        this.bottomCondiments = bottomCondiments;
        this.bottomBread = bottomBread;
    }

    interpret(context) {
        context.output += "|";
        this.topBread.interpret(context);
        context.output += "|";
        context.output += "<--";
        this.topCondiments.interpret(context);
        context.output += "-";
        this.ingredients.interpret(context);
        context.output += "-";
        this.bottomCondiments.interpret(context);
        context.output += "-->";
        context.output += "|";
        this.bottomBread.interpret(context);
        context.output += "|";
        console.log(context.output);
    }
}

const sandwich = new Sandwich(
    new WheatBread(),
    new CondimentsList([new MayonnaiseCondiment(), new MustardCondiment()]),
    new IngredientsList([new LettuceIngredient(), new ChickenIngredient()]),
    new CondimentsList([new KetchupCondiment()]),
    new WhiteBread()
);

sandwich.interpret(new Context());