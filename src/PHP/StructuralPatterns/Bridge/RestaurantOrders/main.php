<?php

interface IRestaurant
{
    public function placeOrder($orderName);
}

class MiddleClassRestaurant implements IRestaurant
{
    public function placeOrder($orderName): void
    {
        echo "Placing order for {$orderName} at " . get_class($this) . PHP_EOL;
    }
}

class FancyRestaurant implements IRestaurant
{
    public function placeOrder($orderName): void
    {
        echo "Placing order for {$orderName} at " . get_class($this) . PHP_EOL;
    }
}

abstract class Order
{
    public IRestaurant $restaurant;

    public abstract function sendOrder();
}

class DiaryFreeOrder extends Order
{
    public function sendOrder(): void
    {
        $this->restaurant->placeOrder("Dairy-Free Meal");
    }
}

class GlutenFreeOrder extends Order
{
    public function sendOrder(): void
    {
        $this->restaurant->placeOrder("Gluten-Free Meal");
    }
}

$order = new DiaryFreeOrder();
$order->restaurant = new MiddleClassRestaurant();
$order->sendOrder();

$order->restaurant = new FancyRestaurant();
$order->sendOrder();

$order = new GlutenFreeOrder();
$order->restaurant = new MiddleClassRestaurant();
$order->sendOrder();

$order->restaurant = new FancyRestaurant();
$order->sendOrder();