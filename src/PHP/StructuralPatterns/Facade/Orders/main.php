<?php

class Order {
    public $dishName;
    public $dishPrice;
    public $user;
    public $shippingAddress;
    public $shippingPrice;

    public function __toString() {
        return "User {$this->user} ordered {$this->dishName}. The full price is " . ($this->dishPrice + $this->shippingPrice) . " dollars.";
    }
}

class OnlineRestaurant {
    private $cart = [];

    public function addOrderToCart($order): void
    {
        $this->cart[] = $order;
    }

    public function completeOrders(): void
    {
        echo "Orders completed. Dispatch in progress...\n";
    }
}

class ShippingService {
    public Order $order;

    public function acceptOrder($order): void
    {
        $this->order = $order;
    }

    public function calculateShippingExpenses(): void
    {
        $this->order->shippingPrice = 15.5;
    }

    public function shipOrder(): void
    {
        echo $this->order . "\n";
        echo "The order is being shipped to {$this->order->shippingAddress}\n";
    }
}

$restaurant = new OnlineRestaurant();
$shippingService = new ShippingService();

$fishAndChipsOrder = new Order();
$fishAndChipsOrder->dishName = "Fish & Chips";
$fishAndChipsOrder->dishPrice = 20;
$fishAndChipsOrder->user = "Jane";
$fishAndChipsOrder->shippingAddress = "Random Street 1";

$sushiOrder = new Order();
$sushiOrder->dishName = "Sushi Philadelphia";
$sushiOrder->dishPrice = 45;
$sushiOrder->user = "Ripley";
$sushiOrder->shippingAddress = "Alien Street 321";

$restaurant->addOrderToCart($fishAndChipsOrder);
$restaurant->addOrderToCart($sushiOrder);
$restaurant->completeOrders();

$shippingService->acceptOrder($fishAndChipsOrder);
$shippingService->calculateShippingExpenses();
$shippingService->shipOrder();

$shippingService->acceptOrder($sushiOrder);
$shippingService->calculateShippingExpenses();
$shippingService->shipOrder();
