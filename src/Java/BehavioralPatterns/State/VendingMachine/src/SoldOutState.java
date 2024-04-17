import java.util.List;

public class SoldOutState extends State {
    public SoldOutState(VendingMachine vendingMachine) {
        super(vendingMachine);
        System.out.println("SOLDOUT");
    }

    @Override
    public void insertMoney(double amount) {
        System.out.println("There are no products in the vending machine.");
    }

    @Override
    public void selectProduct(String productCode) {
        System.out.println("There are no products in the vending machine.");
    }

    @Override
    public void dispenseProduct() {
        System.out.println("There is no selected product for dispensing");
    }

    @Override
    public void cancel() {
        System.out.println("There is no operation to be cancelled");
    }

    @Override
    public void refill(List<Product> products) {
        vendingMachine.setProducts(products);
        int totalStock = vendingMachine.getProducts().stream().mapToInt(Product::getStock).sum();
        System.out.println("Total amount of products: " + totalStock);
        vendingMachine.setState(new IdleState(vendingMachine));
    }
}
