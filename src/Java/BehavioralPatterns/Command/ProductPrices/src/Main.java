import java.util.ArrayList;
import java.util.List;

class Product {
    private final String name;
    private double price;

    public Product(String name, double price) {
        this.name = name;
        this.price = price;
    }

    public String getName() {
        return name;
    }

    public double getPrice() {
        return price;
    }

    public void increasePrice(double amount) {
        price += amount;
        System.out.printf("The price for the %s has been increased by %.2f$.\n", name, amount);
    }

    public boolean decreasePrice(double amount) {
        if (amount < price) {
            price -= amount;
            System.out.printf("The price for the %s has been decreased by %.2f$.\n", name, amount);
            return true;
        }
        return false;
    }

    @Override
    public String toString() {
        return String.format("The current price for the %s product is %.2f$.", name, price);
    }
}

interface ICommand {
    void executeAction();
    void undoAction();
}

enum PriceAction {
    Increase,
    Decrease
}

class ProductCommand implements ICommand {
    private final Product product;
    private final PriceAction priceAction;
    private final double amount;
    private boolean isCommandExecuted;

    public ProductCommand(Product product, PriceAction priceAction, double amount) {
        this.product = product;
        this.priceAction = priceAction;
        this.amount = amount;
    }

    public boolean isCommandExecuted() {
        return isCommandExecuted;
    }

    @Override
    public void executeAction() {
        if (priceAction == PriceAction.Increase) {
            product.increasePrice(amount);
            isCommandExecuted = true;
        } else {
            isCommandExecuted = product.decreasePrice(amount);
        }
    }

    @Override
    public void undoAction() {
        if (!isCommandExecuted) {
            return;
        }

        if (priceAction == PriceAction.Increase) {
            product.decreasePrice(amount);
        } else {
            product.increasePrice(amount);
        }
    }
}

class PriceModifier {
    private final List<ICommand> commands = new ArrayList<>();

    public void setCommand(ICommand command) {
        commands.add(command);
        command.executeAction();
    }

    public void undoActions() {
        for (int i = commands.size() - 1; i >= 0; i--) {
            commands.get(i).undoAction();
        }
    }
}

public class Main {
    public static void main(String[] args) {
        PriceModifier priceModifier = new PriceModifier();

        Product product = new Product("Phone", 500);

        execute(priceModifier, new ProductCommand(product, PriceAction.Increase, 100));
        execute(priceModifier, new ProductCommand(product, PriceAction.Increase, 50));
        execute(priceModifier, new ProductCommand(product, PriceAction.Decrease, 25));

        System.out.println(product);
        System.out.println();

        priceModifier.undoActions();

        System.out.println(product);
    }

    private static void execute(PriceModifier priceModifier, ICommand productCommand) {
        priceModifier.setCommand(productCommand);
    }
}