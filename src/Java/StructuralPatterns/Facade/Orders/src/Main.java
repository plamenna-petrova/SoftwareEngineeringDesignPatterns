import java.util.ArrayList;
import java.util.List;

class Order {
    private String dishName;
    private double dishPrice;
    private String user;
    private String shippingAddress;
    private double shippingPrice;

    public Order(String dishName, double dishPrice, String user, String shippingAddress) {
        this.dishName = dishName;
        this.dishPrice = dishPrice;
        this.user = user;
        this.shippingAddress = shippingAddress;
    }

    @Override
    public String toString() {
        return String.format("User %s ordered %s. The full price is %.2f dollars.", user, dishName, dishPrice + shippingPrice);
    }

    public void setShippingPrice(double shippingPrice) {
        this.shippingPrice = shippingPrice;
    }

    public String getShippingAddress() {
        return shippingAddress;
    }
}

class OnlineRestaurant {
    private List<Order> cart;

    public OnlineRestaurant() {
        cart = new ArrayList<>();
    }

    public void addOrderToCart(Order order) {
        cart.add(order);
    }

    public void completeOrders() {
        System.out.println("Orders completed. Dispatch in progress...");
    }
}

class ShippingService {
    private Order order;

    public void acceptOrder(Order order) {
        this.order = order;
    }

    public void calculateShippingExpenses() {
        order.setShippingPrice(15.5);
    }

    public void shipOrder() {
        System.out.println(order.toString());
        System.out.println("The order is being shipped to " + order.getShippingAddress());
    }
}

public class Main {
    public static void main(String[] args) {
        OnlineRestaurant restaurant = new OnlineRestaurant();
        ShippingService shippingService = new ShippingService();

        Order fishAndChipsOrder = new Order("Fish & Chips", 20, "Jane", "Random Street 1");
        Order sushiOrder = new Order("Sushi Philadelphia", 45, "Ripley", "Alien Street 321");

        restaurant.addOrderToCart(fishAndChipsOrder);
        restaurant.addOrderToCart(sushiOrder);
        restaurant.completeOrders();

        shippingService.acceptOrder(fishAndChipsOrder);
        shippingService.calculateShippingExpenses();
        shippingService.shipOrder();

        shippingService.acceptOrder(sushiOrder);
        shippingService.calculateShippingExpenses();
        shippingService.shipOrder();
    }
}