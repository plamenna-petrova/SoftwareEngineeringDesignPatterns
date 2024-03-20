interface ICar {
    ICar manufacture();
}

class BMW implements ICar {
    private String body;
    private String doors;
    private String wheels;
    private String glass;
    private String engine;

    @Override
    public ICar manufacture() {
        body = "carbon fiber material";
        doors = "4 car doors";
        wheels = "4 MRF wheels";
        glass = "6 car glasses";
        return this;
    }

    public void setEngine(String engine) {
        this.engine = engine;
    }

    @Override
    public String toString() {
        return String.format("%s [Name = %s], Body = %s, Doors = %s, Wheels: %s, Glass: %s, Engine: %s",
                getClass().getSimpleName(), getClass().getSimpleName(), body, doors, wheels, glass, engine != null ? engine : "n/a");
    }
}

abstract class CarDecorator implements ICar {
    protected ICar car;

    public CarDecorator(ICar car) {
        this.car = car;
    }

    @Override
    public ICar manufacture() {
        return car.manufacture();
    }
}

class DieselCarConcreteDecorator extends CarDecorator {
    public DieselCarConcreteDecorator(ICar car) {
        super(car);
    }

    @Override
    public ICar manufacture() {
        ICar decoratedCar = super.manufacture();
        addEngine(decoratedCar);
        return decoratedCar;
    }

    private void addEngine(ICar car) {
        if (car instanceof BMW bmw) {
            bmw.setEngine("Diesel Engine");
            System.out.println("Added Diesel Engine to the Car: " + car);
        }
    }
}

class PetrolCarConcreteDecorator extends CarDecorator {
    public PetrolCarConcreteDecorator(ICar car) {
        super(car);
    }

    @Override
    public ICar manufacture() {
        ICar decoratedCar = super.manufacture();
        addEngine(decoratedCar);
        return decoratedCar;
    }

    private void addEngine(ICar car) {
        if (car instanceof BMW bmw) {
            bmw.setEngine("Petrol Engine");
            System.out.println("Added Petrol Engine to the Car: " + car);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        ICar bmwX7 = new BMW();
        bmwX7.manufacture();
        System.out.println(bmwX7);

        System.out.println();

        DieselCarConcreteDecorator dieselCarConcreteDecorator = new DieselCarConcreteDecorator(bmwX7);
        dieselCarConcreteDecorator.manufacture();

        System.out.println();

        ICar bmwX5 = new BMW();

        PetrolCarConcreteDecorator petrolCarConcreteDecorator = new PetrolCarConcreteDecorator(bmwX5);
        petrolCarConcreteDecorator.manufacture();
    }
}