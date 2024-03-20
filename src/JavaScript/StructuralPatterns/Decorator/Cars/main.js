
class ICar {
    manufacture() {}
}

class BMW extends ICar {
    constructor() {
        super();
        this.body = '';
        this.doors = '';
        this.wheels = '';
        this.glass = '';
        this.engine = '';
    }

    manufacture() {
        this.body = "carbon fiber material";
        this.doors = "4 car doors";
        this.wheels = "4 MRF wheels";
        this.glass = "6 car glasses";
        return this;
    }

    toString() {
        return `${this.constructor.name} [Name = ${this.constructor.name}], Body = ${this.body}, Doors = ${this.doors}, Wheels: ${this.wheels}, Glass: ${this.glass}, Engine: ${this.engine || 'n/a'}`;
    }
}

class CarDecorator extends ICar {
    constructor(car) {
        super();
        this.car = car;
    }

    manufacture() {
        return this.car.manufacture();
    }
}

class DieselCarConcreteDecorator extends CarDecorator {
    constructor(car) {
        super(car);
    }

    manufacture() {
        super.manufacture();
        this.addEngine(this.car);
        return this.car;
    }

    addEngine(car) {
        if (car instanceof BMW) {
            car.engine = "Diesel Engine";
            console.log(`Added Diesel Engine to the Car: ${car}`);
        }
    }
}

class PetrolCarConcreteDecorator extends CarDecorator {
    constructor(car) {
        super(car);
    }

    manufacture() {
        super.manufacture();
        this.addEngine(this.car);
        return this.car;
    }

    addEngine(car) {
        if (car instanceof BMW) {
            car.engine = "Petrol Engine";
            console.log(`Added Petrol Engine to the Car: ${car}`);
        }
    }
}

const bmwX7 = new BMW();
bmwX7.manufacture();
console.log(bmwX7.toString());

console.log();

const dieselCarConcreteDecorator = new DieselCarConcreteDecorator(bmwX7);
dieselCarConcreteDecorator.manufacture();

console.log();

const bmwX5 = new BMW();

const petrolCarConcreteDecorator = new PetrolCarConcreteDecorator(bmwX5);
petrolCarConcreteDecorator.manufacture();