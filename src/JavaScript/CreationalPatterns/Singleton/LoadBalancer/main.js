
const LoadBalancer = (() => {
    const servers = ["ServerI", "ServerII", "ServerIII", "ServerIV", "ServerV"];

    let loadBalancerInstance;

    function LoadBalancerInstance() {
        if (!loadBalancerInstance) {
            loadBalancerInstance = this;
        }

        return loadBalancerInstance;
    }

    LoadBalancerInstance.prototype.getNextServer = () => {
        const randomServerIndex = Math.floor(Math.random() * servers.length);
        return servers[randomServerIndex];
    };

    return LoadBalancerInstance;
})();

const firstLoadBalancer = new LoadBalancer();
const secondLoadBalancer = new LoadBalancer();
const thirdLoadBalancer = new LoadBalancer();
const fourthLoadBalancer = new LoadBalancer();

if (firstLoadBalancer === secondLoadBalancer && secondLoadBalancer === thirdLoadBalancer &&
    thirdLoadBalancer === fourthLoadBalancer) {
    console.log("Same instance of all load balancers \n");
}

const fifthLoadBalancer = new LoadBalancer();

for (let i = 0; i < 15; i++) {
    const randomServer = fifthLoadBalancer.getNextServer();
    console.log("Dispatch Request to: " + randomServer);
}