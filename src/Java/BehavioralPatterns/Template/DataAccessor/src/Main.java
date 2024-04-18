import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

abstract class DataAccessor {
    public abstract void connect();

    public abstract void select();

    public abstract void process(int top);

    public abstract void disconnect();

    public void run(int top) {
        connect();
        select();
        process(top);
        disconnect();
    }
}

class Categories extends DataAccessor {
    private List<String> categories;

    @Override
    public void connect() {
        categories = new ArrayList<>();
    }

    @Override
    public void select() {
        categories.add("Red");
        categories.add("Green");
        categories.add("Blue");
        categories.add("Orange");
        categories.add("Purple");
        categories.add("White");
        categories.add("Black");
    }

    @Override
    public void process(int top) {
        System.out.println("Categories ---- ");
        categories.stream().limit(top).forEach(System.out::println);
        System.out.println();
    }

    @Override
    public void disconnect() {
        categories.clear();
    }
}

class Products extends DataAccessor {
    private List<String> products;

    @Override
    public void connect() {
        products = new ArrayList<>();
    }

    @Override
    public void select() {
        products.add("Car");
        products.add("Bike");
        products.add("Boat");
        products.add("Truck");
        products.add("Moped");
        products.add("Rollerskate");
        products.add("Stroller");
    }

    @Override
    public void process(int top) {
        System.out.println("Products ---- ");
        products.stream().limit(top).forEach(System.out::println);
        System.out.println();
    }

    @Override
    public void disconnect() {
        products.clear();
    }
}

public class Main {
    public static void main(String[] args) {
        DataAccessor categories = new Categories();
        categories.run(5);

        DataAccessor products = new Products();
        products.run(3);
    }
}