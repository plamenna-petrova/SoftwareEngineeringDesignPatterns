import java.util.Objects;

interface IRestaurant {
    void placeOrder(String orderName);
}

class MiddleClassRestaurant implements IRestaurant {
    @Override
    public void placeOrder(String order) {
        System.out.println("Placing order for " + order + " at " + getClass().getSimpleName());
    }
}

class FancyRestaurant implements IRestaurant {
    @Override
    public void placeOrder(String order) {
        System.out.println("Placing order for " + order + " at " + getClass().getSimpleName());
    }
}

abstract class Order {
    protected IRestaurant restaurant;

    public void setRestaurant(IRestaurant restaurant) {
        this.restaurant = restaurant;
    }

    public abstract void sendOrder();
}

class DairyFreeOrder extends Order {
    @Override
    public void sendOrder() {
        if (Objects.nonNull(restaurant)) {
            restaurant.placeOrder("Dairy-Free Meal");
        }
    }
}

class GlutenFreeOrder extends Order {
    @Override
    public void sendOrder() {
        if (Objects.nonNull(restaurant)) {
            restaurant.placeOrder("Gluten-Free Meal");
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Order order = new DairyFreeOrder();
        order.setRestaurant(new MiddleClassRestaurant());
        order.sendOrder();

        order.setRestaurant(new FancyRestaurant());
        order.sendOrder();

        order = new GlutenFreeOrder();
        order.setRestaurant(new MiddleClassRestaurant());
        order.sendOrder();

        order.setRestaurant(new FancyRestaurant());
        order.sendOrder();
    }
}