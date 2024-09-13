
class IVisitor {
    visitRecipe(recipe) {
        throw new Error('This method must be overridden.');
    }

    visitButter(butter) {
        throw new Error('This method must be overridden.');
    }

    visitSalt(salt) {
        throw new Error('This method must be overridden.');
    }

    visitFlour(flour) {
        throw new Error('This method must be overridden.');
    }

    visitSugar(sugar) {
        throw new Error('This method must be overridden.');
    }
}

class CaloriesCalculator extends IVisitor {
    constructor() {
        super();
        this.totalCalories = 0;
    }

    visitRecipe(recipe) {
        recipe.ingredients.forEach(ingredient => {
            ingredient.accept(this);
        });
    }

    visitButter(butter) {
        let calories = butter.fatContent * butter.quantity;
        this.totalCalories += calories;
    }

    visitSalt(salt) {

    }

    visitFlour(flour) {
        let calories = 0;
        switch (flour.flourType) {
            case "All-Purpose":
                calories = 3.64 * flour.quantity;
                break;
            case "Whole Wheat":
                calories = 3.39 * flour.quantity;
                break;
        }
        this.totalCalories += calories;
    }

    visitSugar(sugar) {
        let calories = 4.0 * sugar.sweetnessLevel * sugar.quantity;
        this.totalCalories += calories;
    }
}

class Element {
    accept(visitor) {
        throw new Error('This method must be overridden.');
    }
}

class Ingredient extends Element {
    constructor(name, quantity) {
        super();
        this.name = name;
        this.quantity = quantity;
    }
}

class Butter extends Ingredient {
    constructor(quantity, fatContent) {
        super('Butter', quantity);
        this.fatContent = fatContent;
    }

    accept(visitor) {
        visitor.visitButter(this);
    }
}

class Salt extends Ingredient {
    constructor(quantity, isIodized) {
        super('Salt', quantity);
        this.isIodized = isIodized;
    }

    accept(visitor) {
        visitor.visitSalt(this);
    }
}

class Flour extends Ingredient {
    constructor(quantity, flourType) {
        super('Flour', quantity);
        this.flourType = flourType;
    }

    accept(visitor) {
        visitor.visitFlour(this);
    }
}

class Sugar extends Ingredient {
    constructor(quantity, sweetnessLevel) {
        super('Sugar', quantity);
        this.sweetnessLevel = sweetnessLevel;
    }

    accept(visitor) {
        visitor.visitSugar(this);
    }
}

class Recipe extends Element {
    constructor(ingredients) {
        super();
        this.ingredients = ingredients;
    }

    accept(visitor) {
        visitor.visitRecipe(this);
    }
}

const recipe = new Recipe([
    new Butter(100, 0.81),
    new Salt(10, true),
    new Flour(500, 'All-Purpose'),
    new Sugar(200, 0.5)
]);

const caloriesCalculator = new CaloriesCalculator();

recipe.accept(caloriesCalculator);

console.log('Total Calories:', caloriesCalculator.totalCalories);