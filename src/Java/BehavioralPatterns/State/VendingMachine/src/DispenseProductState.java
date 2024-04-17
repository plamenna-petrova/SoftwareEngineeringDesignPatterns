import java.util.List;
import java.util.concurrent.TimeUnit;

public class DispenseProductState extends State {
    public DispenseProductState(VendingMachine vendingMachine) {
        super(vendingMachine);
        System.out.println("DISPENSING");
    }

    @Override
    public void insertMoney(double amount) {
        System.out.println("Cannot insert money during the dispensing of the product");
    }

    @Override
    public void selectProduct(String productCode) {
        System.out.println("The product is already selected.");
    }

    @Override
    public void dispenseProduct() {
        if (vendingMachine.getSelectedProductCode() == null) {
            System.out.println("There is no selected product for dispensing");
            vendingMachine.setState(new IdleState(vendingMachine));
            return;
        }

        System.out.println("Dispensing product.");
        try {
            TimeUnit.SECONDS.sleep(2); // Simulating dispensing time
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        Product product = vendingMachine.getProducts().stream()
                .filter(p -> p.getCode().equals(vendingMachine.getSelectedProductCode()))
                .findFirst()
                .orElse(null);

        if (product != null) {
            product.setStock(product.getStock() - 1);
        }

        vendingMachine.setSelectedProductCode(null);

        System.out.println("The product is dispensed.");

        if (vendingMachine.getProducts().stream().allMatch(p -> p.getStock() == 0)) {
            vendingMachine.setState(new SoldOutState(vendingMachine));
        } else {
            vendingMachine.setState(new IdleState(vendingMachine));
        }
    }

    @Override
    public void cancel() {
        System.out.println("Cannot cancel the dispensing operation");
    }

    @Override
    public void refill(List<Product> products) {
        System.out.println("Cannot refill during the dispensing of the product");
    }
}
