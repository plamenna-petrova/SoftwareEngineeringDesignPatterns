import java.util.List;

public class PaymentState extends State {
    private double funds = 0;

    public PaymentState(VendingMachine vendingMachine) {
        super(vendingMachine);
        System.out.println("PAYMENT - You can insert coins.");
    }

    @Override
    public void insertMoney(double amount) {
        funds += amount;

        Product selectedProduct = vendingMachine.getProducts().stream()
                .filter(p -> p.getCode().equals(vendingMachine.getSelectedProductCode()))
                .findFirst()
                .orElse(null);

        if (selectedProduct == null) {
            System.out.println("No product is currently selected.");
            return;
        }

        if (funds < selectedProduct.getPrice()) {
            System.out.println("Remaining: " + (selectedProduct.getPrice() - funds));
        } else {
            System.out.println("Proper amount received");

            double change = funds - selectedProduct.getPrice();

            if (change > 0) {
                System.out.println("Dispensing " + change + " amount");
            }

            vendingMachine.setState(new DispenseProductState(vendingMachine));
            vendingMachine.dispenseProduct();
        }
    }

    @Override
    public void selectProduct(String productCode) {
        System.out.println("The product is already selected. Please complete or cancel the current payment.");
    }

    @Override
    public void dispenseProduct() {
        System.out.println("Cannot dispense product yet. Insufficient funds.");
    }

    @Override
    public void cancel() {
        System.out.println("Cancelling order.");

        if (funds > 0) {
            System.out.println("Returning the amount of " + funds);
        }

        vendingMachine.setSelectedProductCode(null);
        vendingMachine.setState(new IdleState(vendingMachine));
    }

    @Override
    public void refill(List<Product> products) {
        System.out.println("Cannot refill during payment operation. Please cancel or complete the payment before refill.");
    }
}
