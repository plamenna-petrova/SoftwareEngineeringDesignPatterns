<?php

class Order {
    public string $orderId;
    public float $totalAmount;
}

interface IOrderHandler {
    public function setNextHandler($orderHandler);
    public function distributeOrderProcessing($order);
}

abstract class BaseOrderHandler implements IOrderHandler {
    private IOrderHandler $nextOrderHandler;

    public function setNextHandler($nextOrderHandler): void
    {
        $this->nextOrderHandler = $nextOrderHandler;
    }

    public function distributeOrderProcessing($order): void
    {
        if ($this->canProcessOrder($order)) {
            $this->processOrder($order);
        } else if ($this->nextOrderHandler != null) {
            $this->nextOrderHandler->distributeOrderProcessing($order);
        } else {
            echo "Order cannot be processed\n";
        }
    }

    protected abstract function canProcessOrder($order);
    protected abstract function processOrder($order);
}

class ValidationHandler extends BaseOrderHandler {
    protected function canProcessOrder($order): bool
    {
        return true;
    }

    protected function processOrder($order): void
    {
        echo "Validation completed for order: " . $order->orderId . "\n";
    }
}

class InventoryCheckHandler extends BaseOrderHandler {
    protected function canProcessOrder($order): bool
    {
        return true;
    }

    protected function processOrder($order): void
    {
        echo "Inventory check completed for order: " . $order->orderId . "\n";
    }
}

class PaymentVerificationHandler extends BaseOrderHandler {
    protected function canProcessOrder($order): bool
    {
        return true;
    }

    protected function processOrder($order): void
    {
        echo "Payment verification completed for order: " . $order->orderId . "\n";
    }
}

class ShippingConfirmationHandler extends BaseOrderHandler {
    protected function canProcessOrder($order): bool
    {
        return true;
    }

    protected function processOrder($order): void
    {
        echo "Shipping confirmation completed for order: " . $order->orderId . "\n";
    }
}

$validationHandler = new ValidationHandler();
$inventoryCheckHandler = new InventoryCheckHandler();
$paymentVerificationHandler = new PaymentVerificationHandler();
$shippingConfirmationHandler = new ShippingConfirmationHandler();

$validationHandler->setNextHandler($inventoryCheckHandler);
$inventoryCheckHandler->setNextHandler($paymentVerificationHandler);
$paymentVerificationHandler->setNextHandler($shippingConfirmationHandler);

$order = new Order();
$order->orderId = "12345";
$order->totalAmount = 100.0;

$validationHandler->distributeOrderProcessing($order);
