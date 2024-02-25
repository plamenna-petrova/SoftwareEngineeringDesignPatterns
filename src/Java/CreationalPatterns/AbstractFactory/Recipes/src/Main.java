import java.util.Scanner;

abstract class RecipeFactory {
    public abstract Sandwich createSandwich();
    public abstract Dessert createDessert();
}

class AdultCuisine extends RecipeFactory {
    @Override
    public Sandwich createSandwich() {
        return new BLT();
    }

    @Override
    public Dessert createDessert() {
        return new CremeBrule();
    }
}

class KidsCuisine extends RecipeFactory {
    @Override
    public Sandwich createSandwich() {
        return new GrilledCheese();
    }

    @Override
    public Dessert createDessert() {
        return new IceCreamSundae();
    }
}

abstract class Sandwich {
}

abstract class Dessert {
}

class BLT extends Sandwich {
}

class CremeBrule extends Dessert {
}

class GrilledCheese extends Sandwich {
}

class IceCreamSundae extends Dessert {
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Who are you? (A)dult or (C)hild?");
        Scanner scanner = new Scanner(System.in);
        char input = scanner.next().charAt(0);

        RecipeFactory recipeFactory;

        switch (input) {
            case 'A':
                recipeFactory = new AdultCuisine();
                break;
            case 'C':
                recipeFactory = new KidsCuisine();
                break;
            default:
                throw new UnsupportedOperationException();
        }

        Sandwich sandwich = recipeFactory.createSandwich();
        Dessert dessert = recipeFactory.createDessert();

        System.out.println("\nSandwich: " + sandwich.getClass().getSimpleName());
        System.out.println("Dessert: " + dessert.getClass().getSimpleName());
    }
}