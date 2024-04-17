import java.util.List;

public abstract class State {
    protected final VendingMachine vendingMachine;

    protected State(VendingMachine vendingMachine) {
        this.vendingMachine = vendingMachine;
    }

    public abstract void insertMoney(double amount);

    public abstract void selectProduct(String productCode);

    public abstract void dispenseProduct();

    public abstract void refill(List<Product> products);

    public abstract void cancel();
}