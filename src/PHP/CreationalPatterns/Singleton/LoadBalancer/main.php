<?php


class LoadBalancer
{
    private array $servers = array();
    private static LoadBalancer $loadBalancerInstance;

    private function __construct()
    {
        $this->servers[] = "ServerI";
        $this->servers[] = "ServerII";
        $this->servers[] = "ServerIII";
        $this->servers[] = "ServerIV";
        $this->servers[] = "ServerV";
    }

    public static function getLoadBalancer(): LoadBalancer
    {
        if (self::$loadBalancerInstance === null) {
            self::$loadBalancerInstance = new LoadBalancer();
        }

        return self::$loadBalancerInstance;
    }

    public function getNextServer()
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
    echo "Dispatch Request to: " . $randomServer . "\n";
}