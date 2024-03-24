interface IServer {
    void takeOrder(String order);

    String deliverOrder();

    void processPayment(String payment);
}

class Server implements IServer {
    private String order;

    @Override
    public void takeOrder(String order) {
        System.out.println("Server takes order for " + order + ".");
        this.order = order;
    }

    @Override
    public String deliverOrder() {
        return order;
    }

    @Override
    public void processPayment(String payment) {
        System.out.println("Payment for order (" + payment + ") processed.");
    }
}

class ServerProxy implements IServer {
    private String order;
    private final Server server = new Server();

    @Override
    public void takeOrder(String order) {
        System.out.println("New trainee server takes order for " + order + ".");
        this.order = order;
    }

    @Override
    public String deliverOrder() {
        return order;
    }

    @Override
    public void processPayment(String payment) {
        System.out.println("New trainee cannot process payments yet!");
        server.processPayment(payment);
    }
}

public class Main {
    public static void main(String[] args) {
        ServerProxy serverProxy = new ServerProxy();
        serverProxy.takeOrder("Order #1");
        serverProxy.processPayment("via Credit Card");
        System.out.println(serverProxy.deliverOrder() + " delivered successfully.");
    }
}