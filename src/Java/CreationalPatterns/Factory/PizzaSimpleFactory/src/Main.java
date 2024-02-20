import java.util.HashMap;
import java.util.Map;

interface IPizza {
    String showDetails();
}

class Neapolitan implements IPizza {
    @Override
    public String showDetails() {
        return "Neapolitan is the original pizza. This delicious pie dates all the way back to the 18th century in Naples, Italy.";
    }
}

class Funghi implements IPizza {
    @Override
    public String showDetails() {
        return "A pizza funghi, or better known as a mushroom pizza is a world-famous pizza. It doesn't need many ingredients, recipe for 2 pizzas.";
    }
}

class Pepperoni implements IPizza {
    @Override
    public String showDetails() {
        return "Pepperoni is a variety of spicy salami made from cured pork and beef seasoned with paprika and chili peppers.";
    }
}

enum PizzaType {
    Neapolitan,
    Pepperoni,
    Funghi
}

interface IPizzaFactory {
    IPizza createPizza(PizzaType pizzaType);
}

class PizzaFactory implements IPizzaFactory {
    @Override
    public IPizza createPizza(PizzaType pizzaType) {
        switch (pizzaType) {
            case Neapolitan:
                return new Neapolitan();
            case Pepperoni:
                return new Pepperoni();
            case Funghi:
                return new Funghi();
            default:
                throw new IllegalArgumentException("Invalid pizza type");
        }
    }
}

class Program {
    public static void main(String[] args) {
        try {
            PizzaFactory pizzaFactory = new PizzaFactory();
            IPizza pepperoniPizza = pizzaFactory.createPizza(PizzaType.Pepperoni);
            System.out.println(pepperoniPizza.showDetails());
        } catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }
}