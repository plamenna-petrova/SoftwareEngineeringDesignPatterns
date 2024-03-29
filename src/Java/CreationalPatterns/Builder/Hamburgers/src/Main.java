import java.util.*;

class Hamburger {
    private String hamburgerName;
    private Map<String, String> ingredients = new HashMap<>();

    public Hamburger(String hamburgerName) {
        this.hamburgerName = hamburgerName;
    }

    public String getHamburgerName() {
        return hamburgerName;
    }

    public String getIngredient(String key) {
        return ingredients.get(key);
    }

    public void setIngredient(String key, String value) {
        ingredients.put(key, value);
    }

    public void showIngredients() {
        System.out.printf("%n%s%n", new String(new char[40]).replace('\0', '-'));
        System.out.printf("Hamburger: %s%n", hamburgerName);
        System.out.printf(" Bun: %s%n", ingredients.get("bun"));
        System.out.printf(" Patty: %s%n", ingredients.get("patty"));
        System.out.printf(" Sauce: %s%n", ingredients.get("sauce"));
        System.out.printf(" Cheese: %s%n", ingredients.get("cheese"));
        System.out.printf(" Veggies: %s%n", ingredients.get("veggies"));
        System.out.printf(" Extras: %s%n", ingredients.get("extras"));
    }
}

abstract class HamburgerBuilder {
    protected Hamburger hamburger;

    public Hamburger getHamburger() {
        return hamburger;
    }

    public abstract void addBun();

    public abstract void addPatty();

    public abstract void addSauce();

    public abstract void addCheese();

    public abstract void addVeggies();

    public abstract void addExtras();
}

class ClassicHamburgerBuilder extends HamburgerBuilder {
    public ClassicHamburgerBuilder() {
        hamburger = new Hamburger("Classic Burger");
    }

    @Override
    public void addBun() {
        hamburger.setIngredient("bun", "Regular sesame bun");
    }

    @Override
    public void addPatty() {
        hamburger.setIngredient("patty", "Beef patty");
    }

    @Override
    public void addSauce() {
        hamburger.setIngredient("sauce", "Ketchup and mustard");
    }

    @Override
    public void addCheese() {
        hamburger.setIngredient("cheese", "American cheese");
    }

    @Override
    public void addVeggies() {
        hamburger.setIngredient("veggies", "Lettuce, tomato, onion, pickles");
    }

    @Override
    public void addExtras() {
        hamburger.setIngredient("extras", "Bacon");
    }
}

class VeggieHamburgerBuilder extends HamburgerBuilder {
    public VeggieHamburgerBuilder() {
        hamburger = new Hamburger("Veggie Burger");
    }

    @Override
    public void addBun() {
        hamburger.setIngredient("bun", "Whole wheat bun");
    }

    @Override
    public void addPatty() {
        hamburger.setIngredient("patty", "Vegetarian patty");
    }

    @Override
    public void addSauce() {
        hamburger.setIngredient("sauce", "Mayonnaise");
    }

    @Override
    public void addCheese() {
        hamburger.setIngredient("cheese", "Swiss cheese");
    }

    @Override
    public void addVeggies() {
        hamburger.setIngredient("veggies", "Lettuce, tomato, onion, avocado");
    }

    @Override
    public void addExtras() {
        hamburger.setIngredient("extras", "Grilled mushrooms");
    }
}

class BurgerKing {
    public void makeHamburger(HamburgerBuilder hamburgerBuilder) {
        hamburgerBuilder.addBun();
        hamburgerBuilder.addPatty();
        hamburgerBuilder.addSauce();
        hamburgerBuilder.addCheese();
        hamburgerBuilder.addVeggies();
        hamburgerBuilder.addExtras();
    }
}

public class Main {
    public static void main(String[] args) {
        BurgerKing burgerKing = new BurgerKing();

        HamburgerBuilder classicHamburgerBuilder = new ClassicHamburgerBuilder();
        burgerKing.makeHamburger(classicHamburgerBuilder);
        classicHamburgerBuilder.getHamburger().showIngredients();

        HamburgerBuilder veggieHamburgerBuilder = new VeggieHamburgerBuilder();
        burgerKing.makeHamburger(veggieHamburgerBuilder);
        veggieHamburgerBuilder.getHamburger().showIngredients();
    }
}