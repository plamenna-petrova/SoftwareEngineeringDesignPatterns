import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

class CarFlyweight {
    private final Car carSharedState;

    public CarFlyweight(Car car) {
        carSharedState = car;
    }

    public void operation(Car car) {
        System.out.println("Flyweight - displaying shared state: " + carSharedState +
                " and unique state: " + car + " state.");
    }
}

class CarFlyweightFactory {
    private final List<Map.Entry<CarFlyweight, String>> carFlyweights = new ArrayList<>();

    public CarFlyweightFactory(Car... cars) {
        for (Car car : cars) {
            carFlyweights.add(new HashMap.SimpleEntry<>(new CarFlyweight(car), getCarKey(car)));
        }
    }

    public CarFlyweight getFlyweight(Car carSharedState) {
        String carKey = getCarKey(carSharedState);

        if (carFlyweights.stream().noneMatch(entry -> entry.getValue().equals(carKey))) {
            System.out.println("FlyweightFactory: Can't find a flyweight, creating new one.");
            carFlyweights.add(new HashMap.SimpleEntry<>(new CarFlyweight(carSharedState), carKey));
        } else {
            System.out.println("FlyweightFactory: Reusing existing flyweight.");
        }

        return carFlyweights.stream()
                .filter(entry -> entry.getValue().equals(carKey))
                .map(Map.Entry::getKey)
                .findFirst()
                .orElse(null);
    }

    public void listFlyweights() {
        int carFlyweightsCount = carFlyweights.size();

        System.out.println("\nFlyweightFactory: Car flyweights count: " + carFlyweightsCount);

        carFlyweights.forEach(entry -> System.out.println(entry.getValue()));
    }

    private String getCarKey(Car car) {
        List<String> carCharacteristics = new ArrayList<>();
        carCharacteristics.add(car.model);
        carCharacteristics.add(car.color);
        carCharacteristics.add(car.company);

        if (car.owner != null && car.number != null) {
            carCharacteristics.add(car.number);
            carCharacteristics.add(car.owner);
        }

        carCharacteristics.sort(String::compareTo);

        return String.join("_", carCharacteristics);
    }
}

class Car {
    public String owner;
    public String number;
    public String company;
    public String model;
    public String color;

    public Car(String company, String model, String color, String number, String owner) {
        this.company = company;
        this.model = model;
        this.color = color;
        this.number = number;
        this.owner = owner;
    }

    @Override
    public String toString() {
        return "Car{" +
                "owner='" + owner + '\'' +
                ", number='" + number + '\'' +
                ", company='" + company + '\'' +
                ", model='" + model + '\'' +
                ", color='" + color + '\'' +
                '}';
    }
}

public class Main {
    public static void main(String[] args) {
        CarFlyweightFactory carFlyweightFactory = new CarFlyweightFactory(
                new Car("Chevrolet", "Camaro2018", "pink", null, null),
                new Car("Mercedes Benz", "C300", "black", null, null),
                new Car("Mercedes Benz", "C500", "red", null, null),
                new Car("BMW", "M5", "red", null, null),
                new Car("BMW", "X6", "white", null, null)
        );

        carFlyweightFactory.listFlyweights();

        addCarToPoliceDatabase(carFlyweightFactory, new Car("BMW", "M5", "red", "CL234IR", "James Doe"));

        addCarToPoliceDatabase(carFlyweightFactory, new Car("BMW", "X1", "red", "CL234IR", "James Doe"));

        carFlyweightFactory.listFlyweights();
    }

    private static void addCarToPoliceDatabase(CarFlyweightFactory carFlyweightFactory, Car car) {
        System.out.println("\nClient: Adding a car to the police database.");

        CarFlyweight carFlyweight = carFlyweightFactory.getFlyweight(new Car(car.company, car.model, car.color, car.number, car.owner));

        carFlyweight.operation(car);
    }
}