
class Car {
    constructor(owner, number, company, model, color) {
        this.owner = owner || null;
        this.number = number || null;
        this.company = company || null;
        this.model = model || null;
        this.color = color || null;
    }
}

class CarFlyweight {
    constructor(car) {
        this.carSharedState = car;
    }

    operation(car) {
        const serializedSharedCarState = JSON.stringify(this.carSharedState, null, 4);
        const serializedUniqueCarState = JSON.stringify(car, null, 4);
        console.log(`Flyweight - displaying shared state: ${serializedSharedCarState} and unique state: ${serializedUniqueCarState} state.`);
    }
}

class CarFlyweightFactory {
    constructor(...cars) {
        this.carFlyweights = new Map();
        
        cars.forEach(car => {
            this.carFlyweights.set(this.getCarKey(car), new CarFlyweight(car));
        });
    }

    getFlyweight(carSharedState) {
        const carKey = this.getCarKey(carSharedState);

        if (!this.carFlyweights.has(carKey)) {
            console.log("FlyweightFactory: Can't find a flyweight, creating new one.");
            this.carFlyweights.set(carKey, new CarFlyweight(carSharedState));
        } else {
            console.log("FlyweightFactory: Reusing existing flyweight.");
        }

        return this.carFlyweights.get(carKey);
    }

    listFlyweights() {
        console.log(`\nFlyweightFactory: Car flyweights count: ${this.carFlyweights.size}`);
        for (const [carKey] of this.carFlyweights) {
            console.log(carKey);
        }
    }

    getCarKey(car) {
        const carCharacteristics = [car.model, car.color, car.company];
        if (car.owner !== null && car.number !== null) {
            carCharacteristics.push(car.number, car.owner);
        }
        carCharacteristics.sort();
        return carCharacteristics.join('_');
    }
}

const carFlyweightFactory = new CarFlyweightFactory(
    new Car("Chevrolet", "Camaro2018", "pink"),
    new Car("Mercedes Benz", "C300", "black"),
    new Car("Mercedes Benz", "C500", "red"),
    new Car("BMW", "M5", "red"),
    new Car("BMW", "X6", "white")
);

carFlyweightFactory.listFlyweights();

function addCarToPoliceDatabase(carFlyweightFactory, car) {
    console.log("\nClient: Adding a car to the police database.");
    const carFlyweight = carFlyweightFactory.getFlyweight(new Car(car.color, car.model, car.company));
    carFlyweight.operation(car);
}

addCarToPoliceDatabase(carFlyweightFactory, new Car("BMW", "M5", "red", "CL234IR", "James Doe"));
addCarToPoliceDatabase(carFlyweightFactory, new Car("BMW", "X1", "red", "CL234IR", "James Doe"));

carFlyweightFactory.listFlyweights();