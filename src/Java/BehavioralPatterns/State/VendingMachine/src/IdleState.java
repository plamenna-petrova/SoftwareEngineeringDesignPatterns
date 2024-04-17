import java.util.List;

public class IdleState extends State {
    public IdleState(VendingMachine vendingMachine) {
        super(vendingMachine);
        System.out.println("IDLE - Wait for product selection");
    }

    @Override
    public void insertMoney(double amount) {
        System.out.println("Please select a product before inserting any money.");
    }

    @Override
    public void selectProduct(String productCode) {
        Product selectedProduct = vendingMachine.getProducts().stream()
                .filter(p -> p.getCode().equals(productCode))
                .findFirst()
                .orElse(null);

        if (selectedProduct == null) {
            System.out.println("The product code: " + productCode + " does not exist.");
            return;
        }

        if (selectedProduct.getStock() == 0) {
            System.out.println("The product code: " + selectedProduct.getCode() + " is out of stock");
            return;
        }

        vendingMachine.setSelectedProductCode(selectedProduct.getCode());
        System.out.println("Product: " + selectedProduct.getCode() + " with price: " + selectedProduct.getPrice() + " selected.");
        vendingMachine.setState(new PaymentState(vendingMachine));
    }

    @Override
    public void dispenseProduct() {
        System.out.println("Select a product first.");
    }

    @Override
    public void cancel() {
        System.out.println("There is no selected product or payment in process to cancel.");
    }

    @Override
    public void refill(List<Product> products) {
        vendingMachine.setProducts(products);
        int totalStock = vendingMachine.getProducts().stream().mapToInt(Product::getStock).sum();
        System.out.println("Total amount of products: " + totalStock);
    }
}
