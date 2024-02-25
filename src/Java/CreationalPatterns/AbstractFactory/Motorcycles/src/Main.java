abstract class MotorcyclesFactory {
    public abstract Scooter createScooter();
    public abstract SportsBike createSportsBike();
}

class HondaFactory extends MotorcyclesFactory {
    @Override
    public Scooter createScooter() {
        return new MaxiScooter();
    }

    @Override
    public SportsBike createSportsBike() {
        return new SportsTourer();
    }
}

class YamahaFactory extends MotorcyclesFactory {
    @Override
    public Scooter createScooter() {
        return new VintageScooter();
    }

    @Override
    public SportsBike createSportsBike() {
        return new TrackMotorbike();
    }
}

abstract class Scooter {
}

abstract class SportsBike {
    public abstract void overrun(Scooter scooter);
}

class MaxiScooter extends Scooter {
}

class SportsTourer extends SportsBike {
    @Override
    public void overrun(Scooter scooter) {
        System.out.println(this.getClass().getSimpleName() + " overruns " + scooter.getClass().getSimpleName());
    }
}

class VintageScooter extends Scooter {
}

class TrackMotorbike extends SportsBike {
    @Override
    public void overrun(Scooter scooter) {
        System.out.println(this.getClass().getSimpleName() + " overruns " + scooter.getClass().getSimpleName());
    }
}

class MotorcyclesClient {
    private Scooter scooter;
    private SportsBike sportsBike;

    public MotorcyclesClient(MotorcyclesFactory motorcyclesFactory) {
        scooter = motorcyclesFactory.createScooter();
        sportsBike = motorcyclesFactory.createSportsBike();
    }

    public void setRace() {
        sportsBike.overrun(scooter);
    }
}

public class Main {
    public static void main(String[] args) {
        MotorcyclesFactory hondaFactory = new HondaFactory();
        MotorcyclesClient motorcyclesClient = new MotorcyclesClient(hondaFactory);
        motorcyclesClient.setRace();

        MotorcyclesFactory yamahaFactory = new YamahaFactory();
        motorcyclesClient = new MotorcyclesClient(yamahaFactory);
        motorcyclesClient.setRace();
    }
}