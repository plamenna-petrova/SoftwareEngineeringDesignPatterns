
class Server {
    constructor(name, ipAddress) {
        this.name = name;
        this.ipAddress = ipAddress;
    }
}

class LoadBalancer {
    constructor() {
        this.servers = [
            new Server("ServerI", "120.14.220.18"),
            new Server("ServerII", "120.14.220.19"),
            new Server("ServerIII", "120.14.220.20"),
            new Server("ServerIV", "120.14.220.21"),
            new Server("ServerV", "120.14.220.22"),
        ];
    }

    static getLoadBalancer() {
        if (!LoadBalancer.loadBalancerInstance) {
            LoadBalancer.loadBalancerInstance = new LoadBalancer();
        }

        return LoadBalancer.loadBalancerInstance;
    }

    get nextServer() {
        const randomServerIndex = Math.floor(Math.random() * this.servers.length);
        return this.servers[randomServerIndex];
    }
}

const firstLoadBalancer = LoadBalancer.getLoadBalancer();
const secondLoadBalancer = LoadBalancer.getLoadBalancer();
const thirdLoadBalancer = LoadBalancer.getLoadBalancer();
const fourthLoadBalancer = LoadBalancer.getLoadBalancer();

if (
    firstLoadBalancer === secondLoadBalancer &&
    secondLoadBalancer === thirdLoadBalancer &&
    thirdLoadBalancer === fourthLoadBalancer
) {
    console.log("Same instance of all load balancers \n");
}

const fifthLoadBalancer = LoadBalancer.getLoadBalancer();

for (let i = 0; i < 15; i++) {
    const randomServer = fifthLoadBalancer.nextServer;
    console.log(`Dispatch Request to: ${randomServer.name} at IP address: ${randomServer.ipAddress}`);
}