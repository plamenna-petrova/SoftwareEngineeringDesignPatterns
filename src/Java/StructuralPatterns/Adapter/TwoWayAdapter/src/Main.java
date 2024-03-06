interface IAircraft {
    boolean isAirborne();

    void takeOff();

    int getHeight();
}

class Aircraft implements IAircraft {
    private int height;
    private boolean airborne;

    public Aircraft() {
        height = 0;
        airborne = false;
    }

    public boolean isAirborne() {
        return airborne;
    }

    public int getHeight() {
        return height;
    }

    public void takeOff() {
        System.out.println("Aircraft engine takeoff");
        height = 200;
        airborne = true;
    }
}

interface ISeacraft {
    int getSpeed();

    void increaseRevs();
}

class Seacraft implements ISeacraft {
    private int speed = 0;

    public void increaseRevs() {
        speed += 10;
        System.out.println("Seacraft engine increases revs to " + speed + " knots");
    }

    public int getSpeed() {
        return speed;
    }
}

class Seabird extends Seacraft implements IAircraft {
    private int height = 0;

    public int getHeight() {
        return height;
    }

    public boolean isAirborne() {
        return height > 50;
    }

    public void takeOff() {
        while (!isAirborne()) {
            increaseRevs();
        }
    }

    public void increaseRevs() {
        super.increaseRevs();

        if (getSpeed() > 40) {
            height += 100;
        }
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Experiment 1: test the aircraft's engine");
        IAircraft aircraft = new Aircraft();
        aircraft.takeOff();

        if (aircraft.isAirborne()) {
            System.out.println("The aircraft engine is fine, flying at " + aircraft.getHeight() + " meters");
        }

        System.out.println("\nExperiment 2: Use the engine in the Seabird");
        IAircraft seabird = new Seabird();
        seabird.takeOff();
        System.out.println("The Seabird took off");

        System.out.println("\nExperiment 3: Increase the speed of the Seabird:");

        ((ISeacraft) seabird).increaseRevs();
        ((ISeacraft) seabird).increaseRevs();

        if (seabird.isAirborne()) {
            System.out.println("Seabird flying at height " + seabird.getHeight() +
                    " meters and speed " + ((ISeacraft) seabird).getSpeed());
        }

        System.out.println("Experiment successful; the Seabird flies!");
    }
}