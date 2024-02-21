import java.util.EnumMap;

interface IAirConditioner {
    void operate();
}

class CoolingManager implements IAirConditioner {
    private final double temperature;

    public CoolingManager(double temperature) {
        this.temperature = temperature;
    }

    public void operate() {
        System.out.println("Cooling the room to the required temperature of " + temperature + " degrees");
    }
}

class WarmingManager implements IAirConditioner {
    private final double temperature;

    public WarmingManager(double temperature) {
        this.temperature = temperature;
    }

    public void operate() {
        System.out.println("Warming the room to the required temperature of " + temperature + " degrees");
    }
}

abstract class AirConditionerFactory {
    public abstract IAirConditioner createAirConditioner(double temperature);
}

class CoolingFactory extends AirConditionerFactory {
    public IAirConditioner createAirConditioner(double temperature) {
        return new CoolingManager(temperature);
    }
}

class WarmingFactory extends AirConditionerFactory {
    public IAirConditioner createAirConditioner(double temperature) {
        return new WarmingManager(temperature);
    }
}

enum Action {
    Cooling,
    Warming
}

class AirConditionersManager {
    private final EnumMap<Action, AirConditionerFactory> airConditionerFactories;

    public AirConditionersManager() {
        airConditionerFactories = new EnumMap<>(Action.class);

        for (Action action : Action.values()) {
            try {
                Class<?> factoryClass = Class.forName(action.name() + "Factory");
                AirConditionerFactory airConditionerFactory = (AirConditionerFactory) factoryClass.getDeclaredConstructor().newInstance();
                airConditionerFactories.put(action, airConditionerFactory);
            } catch (Exception exception) {
                System.out.println(exception.getMessage());
            }
        }
    }

    public IAirConditioner executeCreation(Action action, double temperature) {
        return airConditionerFactories.get(action).createAirConditioner(temperature);
    }
}

class Program {
    public static void main(String[] args) {
        AirConditionersManager airConditionersManager = new AirConditionersManager();

        IAirConditioner coolingAirConditioner = airConditionersManager.executeCreation(Action.Cooling, 22.5);
        coolingAirConditioner.operate();

        IAirConditioner warmingAirConditioner = airConditionersManager.executeCreation(Action.Warming, 33.4);
        warmingAirConditioner.operate();
    }
}