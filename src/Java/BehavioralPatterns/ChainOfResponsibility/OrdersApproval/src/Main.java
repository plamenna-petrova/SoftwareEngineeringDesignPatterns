class Order {
    private final String orderId;
    private final double totalAmount;

    public Order(String orderId, double totalAmount) {
        this.orderId = orderId;
        this.totalAmount = totalAmount;
    }

    public String getOrderId() {
        return orderId;
    }

    public double getTotalAmount() {
        return totalAmount;
    }
}

interface OrderHandler {
    void setNextHandler(OrderHandler orderHandler);
    void distributeOrderProcessing(Order order);
}

abstract class BaseOrderHandler implements OrderHandler {
    private OrderHandler nextOrderHandler;

    public void setNextHandler(OrderHandler nextOrderHandler) {
        this.nextOrderHandler = nextOrderHandler;
    }

    public void distributeOrderProcessing(Order order) {
        if (canProcessOrder(order)) {
            processOrder(order);
        } else if (nextOrderHandler != null) {
            nextOrderHandler.distributeOrderProcessing(order);
        } else {
            System.out.println("Order cannot be processed");
        }
    }

    protected abstract boolean canProcessOrder(Order order);
    protected abstract void processOrder(Order order);
}

class ValidationHandler extends BaseOrderHandler {
    protected boolean canProcessOrder(Order order) {
        return true;
    }

    protected void processOrder(Order order) {
        System.out.println("Validation completed for order: " + order.getOrderId());
    }
}

class InventoryCheckHandler extends BaseOrderHandler {
    protected boolean canProcessOrder(Order order) {
        return true;
    }

    protected void processOrder(Order order) {
        System.out.println("Inventory check completed for order: " + order.getOrderId());
    }
}

class PaymentVerificationHandler extends BaseOrderHandler {
    protected boolean canProcessOrder(Order order) {
        return true;
    }

    protected void processOrder(Order order) {
        System.out.println("Payment verification completed for order: " + order.getOrderId());
    }
}

class ShippingConfirmationHandler extends BaseOrderHandler {
    protected boolean canProcessOrder(Order order) {
        return true;
    }

    protected void processOrder(Order order) {
        System.out.println("Shipping confirmation completed for order: " + order.getOrderId());
    }
}

public class Main {
    public static void main(String[] args) {
        ValidationHandler validationHandler = new ValidationHandler();
        InventoryCheckHandler inventoryCheckHandler = new InventoryCheckHandler();
        PaymentVerificationHandler paymentVerificationHandler = new PaymentVerificationHandler();
        ShippingConfirmationHandler shippingConfirmationHandler = new ShippingConfirmationHandler();

        validationHandler.setNextHandler(inventoryCheckHandler);
        inventoryCheckHandler.setNextHandler(paymentVerificationHandler);
        paymentVerificationHandler.setNextHandler(shippingConfirmationHandler);

        Order order = new Order("12345", 100.0);

        validationHandler.distributeOrderProcessing(order);
    }
}