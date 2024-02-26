
class Hamburger {
    constructor(hamburgerName) {
        this.hamburgerName = hamburgerName;
        this.ingredients = {};
    }

    showIngredients() {
        console.log(`\n${"-".repeat(40)}`);
        console.log(`Hamburger: ${this.hamburgerName}`);
        console.log(` Bun: ${this.ingredients["bun"]}`);
        console.log(` Patty: ${this.ingredients["patty"]}`);
        console.log(` Sauce: ${this.ingredients["sauce"]}`);
        console.log(` Cheese: ${this.ingredients["cheese"]}`);
        console.log(` Veggies: ${this.ingredients["veggies"]}`);
        console.log(` Extras: ${this.ingredients["extras"]}`);
    }
}

class HamburgerBuilder {
    constructor() {
        this.hamburger = new Hamburger("");
    }

    getHamburger() {
        return this.hamburger;
    }

    addBun() { }
    addPatty() { }
    addSauce() { }
    addCheese() { }
    addVeggies() { }
    addExtras() { }
}

class ClassicHamburgerBuilder extends HamburgerBuilder {
    constructor() {
        super();
        this.hamburger = new Hamburger("Classic Burger");
    }

    addBun() {
        this.hamburger.ingredients["bun"] = "Regular sesame bun";
    }

    addPatty() {
        this.hamburger.ingredients["patty"] = "Beef patty";
    }

    addSauce() {
        this.hamburger.ingredients["sauce"] = "Ketchup and mustard";
    }

    addCheese() {
        this.hamburger.ingredients["cheese"] = "American cheese";
    }

    addVeggies() {
        this.hamburger.ingredients["veggies"] = "Lettuce, tomato, onion, pickles";
    }

    addExtras() {
        this.hamburger.ingredients["extras"] = "Bacon";
    }
}

class VeggieHamburgerBuilder extends HamburgerBuilder {
    constructor() {
        super();
        this.hamburger = new Hamburger("Veggie Burger");
    }

    addBun() {
        this.hamburger.ingredients["bun"] = "Whole wheat bun";
    }

    addPatty() {
        this.hamburger.ingredients["patty"] = "Vegetarian patty";
    }

    addSauce() {
        this.hamburger.ingredients["sauce"] = "Mayonnaise";
    }

    addCheese() {
        this.hamburger.ingredients["cheese"] = "Swiss cheese";
    }

    addVeggies() {
        this.hamburger.ingredients["veggies"] = "Lettuce, tomato, onion, avocado";
    }

    addExtras() {
        this.hamburger.ingredients["extras"] = "Grilled mushrooms";
    }
}

class BurgerKing {
    makeHamburger(hamburgerBuilder) {
        hamburgerBuilder.addBun();
        hamburgerBuilder.addPatty();
        hamburgerBuilder.addSauce();
        hamburgerBuilder.addCheese();
        hamburgerBuilder.addVeggies();
        hamburgerBuilder.addExtras();
    }
}

const burgerKing = new BurgerKing();

const classicHamburgerBuilder = new ClassicHamburgerBuilder();
burgerKing.makeHamburger(classicHamburgerBuilder);
classicHamburgerBuilder.getHamburger().showIngredients();

const veggieHamburgerBuilder = new VeggieHamburgerBuilder();
burgerKing.makeHamburger(veggieHamburgerBuilder);
veggieHamburgerBuilder.getHamburger().showIngredients();