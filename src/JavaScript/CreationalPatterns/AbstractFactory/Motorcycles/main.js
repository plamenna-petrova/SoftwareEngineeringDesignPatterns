
class MotorcyclesFactory {
    createScooter() { }
    createSportsBike() { }
}

class HondaFactory extends MotorcyclesFactory {
    createScooter() {
        return new MaxiScooter();
    }

    createSportsBike() {
        return new SportsTourer();
    }
}

class YamahaFactory extends MotorcyclesFactory {
    createScooter() {
        return new VintageScooter();
    }

    createSportsBike() {
        return new TrackMotorbike();
    }
}

class Scooter { }

class SportsBike {
    overrun(scooter) { }
}

class MaxiScooter extends Scooter { }

class SportsTourer extends SportsBike {
    overrun(scooter) {
        console.log(`${this.constructor.name} overruns ${scooter.constructor.name}`);
    }
}

class VintageScooter extends Scooter { }

class TrackMotorbike extends SportsBike {
    overrun(scooter) {
        console.log(`${this.constructor.name} overruns ${scooter.constructor.name}`);
    }
}

class MotorcyclesClient {
    constructor(motorcyclesFactory) {
        this.scooter = motorcyclesFactory.createScooter();
        this.sportsBike = motorcyclesFactory.createSportsBike();
    }

    setRace() {
        this.sportsBike.overrun(this.scooter);
    }
}

const hondaFactory = new HondaFactory();
const motorcyclesClient1 = new MotorcyclesClient(hondaFactory);
motorcyclesClient1.setRace();

const yamahaFactory = new YamahaFactory();
const motorcyclesClient2 = new MotorcyclesClient(yamahaFactory);
motorcyclesClient2.setRace();