import java.text.NumberFormat;
import java.util.Locale;

interface IColdDrink {
    int getPrice();

    String getDescription();
}

class CocaCola implements IColdDrink {
    @Override
    public int getPrice() {
        return 2;
    }

    @Override
    public String getDescription() {
        return "simple cola";
    }
}

abstract class ColdDrinkDecorator implements IColdDrink {
    protected final IColdDrink coldDrink;

    public ColdDrinkDecorator(IColdDrink coldDrink) {
        this.coldDrink = coldDrink;
    }

    @Override
    public int getPrice() {
        return coldDrink.getPrice();
    }

    @Override
    public String getDescription() {
        return coldDrink.getDescription();
    }
}

class IceCola extends ColdDrinkDecorator {
    public IceCola(IColdDrink coldDrink) {
        super(coldDrink);
    }

    @Override
    public int getPrice() {
        return coldDrink.getPrice() + 1;
    }

    @Override
    public String getDescription() {
        return coldDrink.getDescription() + ", mixed up with ice cream";
    }
}

class CubaLibreCocktail extends ColdDrinkDecorator {
    public CubaLibreCocktail(IColdDrink coldDrink) {
        super(coldDrink);
    }

    @Override
    public int getPrice() {
        return coldDrink.getPrice() + 3;
    }

    @Override
    public String getDescription() {
        return coldDrink.getDescription() + ", mixed up with some rum, ice and lemon";
    }
}

class ColaMilkshake extends ColdDrinkDecorator {
    public ColaMilkshake(IColdDrink coldDrink) {
        super(coldDrink);
    }

    @Override
    public int getPrice() {
        return coldDrink.getPrice() + 2;
    }

    @Override
    public String getDescription() {
        return coldDrink.getDescription() + ", and milk";
    }
}

public class Main {
    public static void main(String[] args) {
        String drinkInfo = "Print drink info =================================";
        Locale locale = new Locale("en", "US");
        NumberFormat currencyFormatter = NumberFormat.getCurrencyInstance(locale);

        IColdDrink cocaCola = new CocaCola();
        System.out.println(drinkInfo);
        System.out.println("Price : " + currencyFormatter.format(cocaCola.getPrice()));
        System.out.println("Description : " + cocaCola.getDescription());
        System.out.println("=".repeat(50));

        IColdDrink iceCola = new IceCola(cocaCola);
        System.out.println(drinkInfo);
        System.out.println("Price : " + currencyFormatter.format(iceCola.getPrice()));
        System.out.println("Description : " + iceCola.getDescription());
        System.out.println("=".repeat(50));

        IColdDrink cubaLibreCocktail = new CubaLibreCocktail(cocaCola);
        System.out.println(drinkInfo);
        System.out.println("Price : " + currencyFormatter.format(cubaLibreCocktail.getPrice()));
        System.out.println("Description : " + cubaLibreCocktail.getDescription());
        System.out.println("=".repeat(50));

        IColdDrink colaMilkShake = new ColaMilkshake(iceCola);
        System.out.println(drinkInfo);
        System.out.println("Price : " + currencyFormatter.format(colaMilkShake.getPrice()));
        System.out.println("Description : " + colaMilkShake.getDescription());
    }
}