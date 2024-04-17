import java.util.List;

public class VendingMachine {
    private List<Product> products;
    private State currentState;
    private String selectedProductCode;

    public VendingMachine(List<Product> products) {
        this.products = products;
        this.currentState = new IdleState(this);
    }

    public List<Product> getProducts() {
        return products;
    }

    public void setProducts(List<Product> products) {
        this.products = products;
    }

    public State getCurrentState() {
        return currentState;
    }

    public void setCurrentState(State currentState) {
        this.currentState = currentState;
    }

    public String getSelectedProductCode() {
        return selectedProductCode;
    }

    public void setSelectedProductCode(String selectedProductCode) {
        this.selectedProductCode = selectedProductCode;
    }

    public void selectProduct(String productCode) {
        currentState.selectProduct(productCode);
    }

    public void insertMoney(double amount) {
        currentState.insertMoney(amount);
    }

    public void dispenseProduct() {
        currentState.dispenseProduct();
    }

    public void refill(List<Product> products) {
        currentState.refill(products);
    }

    public void setState(State state) {
        currentState = state;
    }
}