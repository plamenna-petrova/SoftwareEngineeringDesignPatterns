import java.util.ArrayList;
import java.util.List;
import java.util.Random;

class LoadBalancer {

    private final List<String> servers = new ArrayList<>();
    private final Random randomServer = new Random();

    private static LoadBalancer loadBalancerInstance;
    private static final Object lockObject = new Object();

    private LoadBalancer() {
        servers.add("ServerI");
        servers.add("ServerII");
        servers.add("ServerIII");
        servers.add("ServerIV");
        servers.add("ServerV");
    }

    public static LoadBalancer getLoadBalancer() {
        if (loadBalancerInstance == null) {
            synchronized (lockObject) {
                if (loadBalancerInstance == null) {
                    loadBalancerInstance = new LoadBalancer();
                }
            }
        }

        return loadBalancerInstance;
    }

    public String getNextServer() {
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

        if (firstLoadBalancer == secondLoadBalancer && secondLoadBalancer == thirdLoadBalancer &&
                thirdLoadBalancer == fourthLoadBalancer) {
            System.out.println("Same instance of all load balancers");
        }

        LoadBalancer fifthLoadBalancer = LoadBalancer.getLoadBalancer();

        for (int i = 0; i < 15; i++) {
            String randomServer = fifthLoadBalancer.getNextServer();
            System.out.println("Dispatch Request to: " + randomServer);
        }
    }
}