import java.util.ArrayList;
import java.util.List;
import java.util.Random;

class Server {
    private final String name;
    private final String ipAddress;

    public Server(String name, String ipAddress) {
        this.name = name;
        this.ipAddress = ipAddress;
    }

    public String getName() {
        return name;
    }

    public String getIPAddress() {
        return ipAddress;
    }
}

class LoadBalancer {
    private final List<Server> servers;
    private final Random randomServer = new Random();
    private static final LoadBalancer loadBalancerInstance = new LoadBalancer();

    private LoadBalancer() {
        servers = new ArrayList<>();
        servers.add(new Server("ServerI", "120.14.220.18"));
        servers.add(new Server("ServerII", "120.14.220.19"));
        servers.add(new Server("ServerIII", "120.14.220.20"));
        servers.add(new Server("ServerIV", "120.14.220.21"));
        servers.add(new Server("ServerV", "120.14.220.22"));
    }

    public static LoadBalancer getLoadBalancer() {
        return loadBalancerInstance;
    }

    public Server getNextServer() {
        int randomServerIndex = randomServer.nextInt(servers.size());
        return servers.get(randomServerIndex);
    }
}

public class Main {
    public static void main(String[] args) {
        LoadBalancer firstLoadBalancer = LoadBalancer.getLoadBalancer();
        LoadBalancer secondLoadBalancer = LoadBalancer.getLoadBalancer();
        LoadBalancer thirdLoadBalancer = LoadBalancer.getLoadBalancer();
        LoadBalancer fourthLoadBalancer = LoadBalancer.getLoadBalancer();

        if (firstLoadBalancer == secondLoadBalancer && secondLoadBalancer == thirdLoadBalancer
                && thirdLoadBalancer == fourthLoadBalancer) {
            System.out.println("Same instance of all load balancers");
        }

        LoadBalancer fifthLoadBalancer = LoadBalancer.getLoadBalancer();

        for (int i = 0; i < 15; i++) {
            Server randomServer = fifthLoadBalancer.getNextServer();
            System.out.println("Dispatch Request to: " + randomServer.getName() + " at IP address: " + randomServer.getIPAddress());
        }
    }
}