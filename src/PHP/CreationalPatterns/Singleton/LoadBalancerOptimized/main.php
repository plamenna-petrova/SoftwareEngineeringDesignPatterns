<?php

class Server {
    public $name;
    public $ipAddress;

    public function __construct($server) {
        $this->name = $server['name'];
        $this->ipAddress = $server['ipAddress'];
    }
}

class LoadBalancer {
    private array $servers;

    private static LoadBalancer $loadBalancerInstance;

    private function __construct() {
        $this->servers = array(
            new Server(array('name' => "ServerI", 'ipAddress' => "120.14.220.18")),
            new Server(array('name' => "ServerII", 'ipAddress' => "120.14.220.19")),
            new Server(array('name' => "ServerIII", 'ipAddress' => "120.14.220.20")),
            new Server(array('name' => "ServerIV", 'ipAddress' => "120.14.220.21")),
            new Server(array('name' => "ServerV", 'ipAddress' => "120.14.220.22"))
        );
    }

    public static function getLoadBalancer(): LoadBalancer
    {
        return self::$loadBalancerInstance ??= new LoadBalancer();
    }

    public function getNextServer(): Server
    {
        $randomServerIndex = rand(0, count($this->servers) - 1);
        return $this->servers[$randomServerIndex];
    }
}

$firstLoadBalancer = LoadBalancer::getLoadBalancer();
$secondLoadBalancer = LoadBalancer::getLoadBalancer();
$thirdLoadBalancer = LoadBalancer::getLoadBalancer();
$fourthLoadBalancer = LoadBalancer::getLoadBalancer();

if ($firstLoadBalancer === $secondLoadBalancer && $secondLoadBalancer === $thirdLoadBalancer &&
    $thirdLoadBalancer === $fourthLoadBalancer) {
    echo "Same instance of all load balancers \n";
}

$fifthLoadBalancer = LoadBalancer::getLoadBalancer();

for ($i = 0; $i < 15; $i++) {
    $randomServer = $fifthLoadBalancer->getNextServer();
    echo "Dispatch Request to: " . $randomServer->name . " at IP address: " . $randomServer->ipAddress . "\n";
}