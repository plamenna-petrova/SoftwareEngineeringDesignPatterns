import java.util.HashMap;
import java.util.Map;

class Vehicle {
    private String vehicleType;
    private Map<String, String> parts = new HashMap<>();

    public Vehicle(String vehicleType) {
        this.vehicleType = vehicleType;
    }

    public String get(String key) {
        return parts.get(key);
    }

    public void set(String key, String value) {
        parts.put(key, value);
    }

    public void show() {
        System.out.println("\n" + "-".repeat(25));
        System.out.println("Vehicle Type: " + vehicleType);
        System.out.println(" Frame : " + get("frame"));
        System.out.println(" Engine : " + get("engine"));
        System.out.println(" #Wheels: " + get("wheels"));
        System.out.println(" #Doors: " + get("doors"));
    }
}

abstract class VehicleBuilder {
    protected Vehicle vehicle;

    public Vehicle getVehicle() {
        return vehicle;
    }

    public abstract void buildFrame();

    public abstract void buildEngine();

    public abstract void buildWheels();

    public abstract void buildDoors();
}

class MotorcycleBuilder extends VehicleBuilder {
    public MotorcycleBuilder() {
        vehicle = new Vehicle("MotorCycle");
    }

    @Override
    public void buildFrame() {
        vehicle.set("frame", "Motorcycle Frame");
    }

    @Override
    public void buildEngine() {
        vehicle.set("engine", "500 cc");
    }

    @Override
    public void buildWheels() {
        vehicle.set("wheels", "2");
    }

    @Override
    public void buildDoors() {
        vehicle.set("doors", "0");
    }
}

class CarBuilder extends VehicleBuilder {
    public CarBuilder() {
        vehicle = new Vehicle("Car");
    }

    @Override
    public void buildFrame() {
        vehicle.set("frame", "Car Frame");
    }

    @Override
    public void buildEngine() {
        vehicle.set("engine", "2500 cc");
    }

    @Override
    public void buildWheels() {
        vehicle.set("wheels", "4");
    }

    @Override
    public void buildDoors() {
        vehicle.set("doors", "4");
    }
}

class ScooterBuilder extends VehicleBuilder {
    public ScooterBuilder() {
        vehicle = new Vehicle("Scooter");
    }

    @Override
    public void buildFrame() {
        vehicle.set("frame", "Scooter Frame");
    }

    @Override
    public void buildEngine() {
        vehicle.set("engine", "50 cc");
    }

    @Override
    public void buildWheels() {
        vehicle.set("wheels", "2");
    }

    @Override
    public void buildDoors() {
        vehicle.set("doors", "0");
    }
}

class Shop {
    public void construct(VehicleBuilder vehicleBuilder) {
        vehicleBuilder.buildFrame();
        vehicleBuilder.buildEngine();
        vehicleBuilder.buildWheels();
        vehicleBuilder.buildDoors();
    }
}

public class Main {
    public static void main(String[] args) {
        Shop shop = new Shop();
        VehicleBuilder vehicleBuilder = new ScooterBuilder();

        shop.construct(vehicleBuilder);
        vehicleBuilder.getVehicle().show();

        vehicleBuilder = new CarBuilder();
        shop.construct(vehicleBuilder);
        vehicleBuilder.getVehicle().show();

        vehicleBuilder = new MotorcycleBuilder();
        shop.construct(vehicleBuilder);
        vehicleBuilder.getVehicle().show();
    }
}
