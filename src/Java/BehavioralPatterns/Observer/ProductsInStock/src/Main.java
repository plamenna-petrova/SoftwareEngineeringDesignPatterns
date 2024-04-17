import java.util.ArrayList;
import java.util.List;

interface IObserver {
    void update(String availability);
}

class Observer implements IObserver {
    private final String userName;

    public Observer(String userName) {
        this.userName = userName;
    }

    public String getUserName() {
        return userName;
    }

    public void addSubscriber(ISubject subject) {
        subject.registerObserver(this);
    }

    public void removeSubscriber(ISubject subject) {
        subject.removeObserver(this);
    }

    public void update(String productAvailability) {
        System.out.printf("Hello %s, Product is now %s on Amazon%n", userName, productAvailability);
    }
}

interface ISubject {
    void registerObserver(IObserver observer);

    void removeObserver(IObserver observer);

    void notifyObservers();
}

class Subject implements ISubject {
    private final List<IObserver> observers = new ArrayList<>();
    private final String productName;
    private final int productPrice;
    private String productAvailability;

    public Subject(String productName, int productPrice, String productAvailability) {
        this.productName = productName;
        this.productPrice = productPrice;
        this.productAvailability = productAvailability;
    }

    public String getProductName() {
        return productName;
    }

    public int getProductPrice() {
        return productPrice;
    }

    public String getProductAvailability() {
        return productAvailability;
    }

    public void setProductAvailability(String productAvailability) {
        this.productAvailability = productAvailability;
        System.out.printf("Availability changed from Out of Stock to %s%n", productAvailability);
        notifyObservers();
    }

    public void registerObserver(IObserver observer) {
        System.out.printf("Observer added: %s%n", ((Observer) observer).getUserName());
        observers.add(observer);
    }

    public void removeObserver(IObserver observer) {
        System.out.printf("Observer removed: %s%n", ((Observer) observer).getUserName());
        observers.remove(observer);
    }

    public void notifyObservers() {
        System.out.printf("Product Name: %s, Product Price: %d. So, notifying all registered users.%n", productName, productPrice);
        System.out.println();

        for (IObserver observer : observers) {
            observer.update(productAvailability);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Subject xiaomiRedmi = new Subject("Xiaomi Redmi Mobile", 10000, "Out Of Stock");

        Observer firstObserver = new Observer("Axel");
        firstObserver.addSubscriber(xiaomiRedmi);

        Observer secondObserver = new Observer("Pharrell");
        secondObserver.addSubscriber(xiaomiRedmi);

        Observer thirdObserver = new Observer("Carl");
        thirdObserver.addSubscriber(xiaomiRedmi);

        System.out.println("Xiaomi Red Mi Mobile current state: " + xiaomiRedmi.getProductAvailability());
        System.out.println();

        thirdObserver.removeSubscriber(xiaomiRedmi);

        xiaomiRedmi.setProductAvailability("Available");
    }
}