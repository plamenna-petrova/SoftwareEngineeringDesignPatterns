
class RecipeFactory {
    createSandwich() {
        throw new Error("Method not implemented");
    }

    createDessert() {
        throw new Error("Method not implemented");
    }
}

class AdultCuisine extends RecipeFactory {
    createSandwich() {
        return new BLT();
    }

    createDessert() {
        return new CremeBrule();
    }
}

class KidsCuisine extends RecipeFactory {
    createSandwich() {
        return new GrilledCheese();
    }

    createDessert() {
        return new IceCreamSundae();
    }
}

class Sandwich {

}

class Dessert {

}

class BLT extends Sandwich {

}

class CremeBrule extends Dessert {

}

class GrilledCheese extends Sandwich {

}

class IceCreamSundae extends Dessert {

}

const prompt = require("prompt-sync")();

const input = prompt("Who are you? (A)dult or (C)hild?: ");

let recipeFactory;

switch (input.toUpperCase()) {
    case 'A':
        recipeFactory = new AdultCuisine();
        break;
    case 'C':
        recipeFactory = new KidsCuisine();
        break;
    default:
        throw new Error("Not implemented");
}

const sandwich = recipeFactory.createSandwich();
const dessert = recipeFactory.createDessert();

console.log(`\nSandwich: ${sandwich.constructor.name}`);
console.log(`Dessert: ${dessert.constructor.name}`);