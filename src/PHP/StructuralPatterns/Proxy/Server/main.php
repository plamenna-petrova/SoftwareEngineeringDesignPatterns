<?php

interface IServer {
    public function takeOrder($order);
    public function deliverOrder();
    public function processPayment($payment);
}

class Server implements IServer {
    private $order;

    public function takeOrder($order): void
    {
        echo "Server takes order for $order.\n";
        $this->order = $order;
    }

    public function deliverOrder() {
        return $this->order;
    }

    public function processPayment($payment): void
    {
        echo "Payment for order ($payment) processed.\n";
    }
}

class ServerProxy implements IServer {
    private string $order;
    private Server $server;

    public function __construct()
    {
        $this->server = new Server();
    }

    public function takeOrder($order): void
    {
        echo "New trainee server takes order for $order.\n";
        $this->order = $order;
    }

    public function deliverOrder(): string
    {
        return $this->order;
    }

    public function processPayment($payment): void
    {
        echo "New trainee cannot process payments yet!\n";
        $this->server->processPayment($payment);
    }
}

$serverProxy = new ServerProxy();
$serverProxy->takeOrder("Order #1");
$serverProxy->processPayment("via Credit Card");
echo $serverProxy->deliverOrder() . " delivered successfully.\n";