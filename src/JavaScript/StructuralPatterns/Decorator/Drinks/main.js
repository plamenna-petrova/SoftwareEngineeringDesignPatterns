
class IColdDrink {
    getPrice() {
        throw new Error("Abstract method getPrice must be implemented.");
    }

    getDescription() {
        throw new Error("Abstract method getDescription must be implemented.");
    }
}

class CocaCola extends IColdDrink {
    getPrice() {
        return 2;
    }

    getDescription() {
        return "simple cola";
    }
}

class ColdDrinkDecorator extends IColdDrink {
    constructor(coldDrink) {
        super();

        if (!coldDrink) {
            throw new Error("Cold drink should not be null.");
        }
        
        this.coldDrink = coldDrink;
    }

    getPrice() {
        return this.coldDrink.getPrice();
    }

    getDescription() {
        return this.coldDrink.getDescription();
    }
}

class IceCola extends ColdDrinkDecorator {
    constructor(coldDrink) {
        super(coldDrink);
    }

    getPrice() {
        return this.coldDrink.getPrice() + 1;
    }

    getDescription() {
        return `${this.coldDrink.getDescription()}, mixed up with ice cream`;
    }
}

class CubaLibreCocktail extends ColdDrinkDecorator {
    constructor(coldDrink) {
        super(coldDrink);
    }

    getPrice() {
        return this.coldDrink.getPrice() + 3;
    }

    getDescription() {
        return `${this.coldDrink.getDescription()}, mixed up with some rum, ice and lemon`;
    }
}

class ColaMilkshake extends ColdDrinkDecorator {
    constructor(coldDrink) {
        super(coldDrink);
    }

    getPrice() {
        return this.coldDrink.getPrice() + 2;
    }

    getDescription() {
        return `${this.coldDrink.getDescription()}, and milk`;
    }
}

const drinkInfo = "Print drink info =================================";

const cocaCola = new CocaCola();
console.log(drinkInfo);
console.log(`Price : $${cocaCola.getPrice().toFixed(2)}`);
console.log(`Description : ${cocaCola.getDescription()}`);
console.log("=".repeat(50));

const iceCola = new IceCola(cocaCola);
console.log(drinkInfo);
console.log(`Price : $${iceCola.getPrice().toFixed(2)}`);
console.log(`Description : ${iceCola.getDescription()}`);
console.log("=".repeat(50));

const cubaLibreCocktail = new CubaLibreCocktail(cocaCola);
console.log(drinkInfo);
console.log(`Price : $${cubaLibreCocktail.getPrice().toFixed(2)}`);
console.log(`Description : ${cubaLibreCocktail.getDescription()}`);
console.log("=".repeat(50));

const colaMilkShake = new ColaMilkshake(iceCola);
console.log(drinkInfo);
console.log(`Price : $${colaMilkShake.getPrice().toFixed(2)}`);
console.log(`Description : ${colaMilkShake.getDescription()}`);