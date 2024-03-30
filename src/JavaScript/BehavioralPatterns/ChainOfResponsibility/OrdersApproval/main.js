
class Order {
    constructor(orderId, totalAmount) {
        this.orderId = orderId;
        this.totalAmount = totalAmount;
    }
}

class IOrderHandler {
    setNextHandler(orderHandler) {
        this.nextOrderHandler = orderHandler;
    }

    distributeOrderProcessing(order) {
        throw new Error("Method 'distributeOrderProcessing' must be implemented");
    }
}

class BaseOrderHandler extends IOrderHandler {
    setNextHandler(nextOrderHandler) {
        this.nextOrderHandler = nextOrderHandler;
    }

    distributeOrderProcessing(order) {
        if (this.canProcessOrder(order)) {
            this.processOrder(order);
        } else if (this.nextOrderHandler !== null) {
            this.nextOrderHandler.distributeOrderProcessing(order);
        } else {
            console.log("Order cannot be processed");
        }
    }

    canProcessOrder(order) {
        throw new Error("Method 'canProcessOrder' must be implemented");
    }

    processOrder(order) {
        throw new Error("Method 'processOrder' must be implemented");
    }
}

class ValidationHandler extends BaseOrderHandler {
    canProcessOrder(order) {
        return true;
    }

    processOrder(order) {
        console.log("Validation completed for order: " + order.orderId);
    }
}

class InventoryCheckHandler extends BaseOrderHandler {
    canProcessOrder(order) {
        return true;
    }

    processOrder(order) {
        console.log("Inventory check completed for order: " + order.orderId);
    }
}

class PaymentVerificationHandler extends BaseOrderHandler {
    canProcessOrder(order) {
        return true;
    }

    processOrder(order) {
        console.log("Payment verification completed for order: " + order.orderId);
    }
}

class ShippingConfirmationHandler extends BaseOrderHandler {
    canProcessOrder(order) {
        return true;
    }

    processOrder(order) {
        console.log("Shipping confirmation completed for order: " + order.orderId);
    }
}

const validationHandler = new ValidationHandler();
const inventoryCheckHandler = new InventoryCheckHandler();
const paymentVerificationHandler = new PaymentVerificationHandler();
const shippingConfirmationHandler = new ShippingConfirmationHandler();

validationHandler.setNextHandler(inventoryCheckHandler);
inventoryCheckHandler.setNextHandler(paymentVerificationHandler);
paymentVerificationHandler.setNextHandler(shippingConfirmationHandler);

const order = new Order("12345", 100.0);

validationHandler.distributeOrderProcessing(order);