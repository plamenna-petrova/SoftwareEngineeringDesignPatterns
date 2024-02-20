
class Pizza {
    showDetails() {
        throw new Error("Method 'showDetails' must be implemented.");
    }
}

class Neapolitan extends Pizza {
    showDetails() {
        return "Neapolitan is the original pizza. This delicious pie dates all " +
            "the way back to the 18th century in Naples, Italy. ";
    }
}

class Funghi extends Pizza {
    showDetails() {
        return "A pizza funghi, or better known as a mushroom pizza is a world famous pizza. " +
            "It doesn't need many ingredients, recipe for 2 pizzas.";
    }
}

class Pepperoni extends Pizza {
    showDetails() {
        return "Pepperoni is a variety of spicy salami made from cured pork and beef seasoned " +
            "with paprika and chili peppers.";
    }
}

const PizzaType = {
    Neapolitan: 'Neapolitan',
    Pepperoni: 'Pepperoni',
    Funghi: 'Funghi'
};

class IPizzaFactory {
    createPizza(pizzaType) {
        throw new Error("Method 'createPizza' must be implemented.");
    }
}

class PizzaFactory extends IPizzaFactory {
    createPizza(pizzaType) {
        switch (pizzaType) {
            case PizzaType.Neapolitan:
                return new Neapolitan();
            case PizzaType.Pepperoni:
                return new Pepperoni();
            case PizzaType.Funghi:
                return new Funghi();
            default:
                throw new Error("Invalid pizza type");
        }
    }
}

try {
    const pizzaFactory = new PizzaFactory();
    const pepperoniPizza = pizzaFactory.createPizza(PizzaType.Pepperoni);
    console.log(pepperoniPizza.showDetails());
} catch (error) {
    console.log(error.message);
}