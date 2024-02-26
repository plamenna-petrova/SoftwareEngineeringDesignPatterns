
class Vehicle {
    constructor(vehicleType) {
        this.vehicleType = vehicleType;
        this.parts = {};
    }

    getPart(key) {
        return this.parts[key];
    }

    setPart(key, value) {
        this.parts[key] = value;
    }

    show() {
        console.log("\n".padEnd(25, '-'));
        console.log(`Vehicle Type: ${this.vehicleType}`);
        console.log(` Frame : ${this.getPart("frame")}`);
        console.log(` Engine : ${this.getPart("engine")}`);
        console.log(` #Wheels: ${this.getPart("wheels")}`);
        console.log(` #Doors: ${this.getPart("doors")}`);
    }
}

class VehicleBuilder {
    constructor() {
        this.vehicle = null;
    }

    get Vehicle() {
        return this.vehicle;
    }

    set Vehicle(value) {
        this.vehicle = value;
    }

    buildFrame() {
        throw new Error("Abstract method buildFrame must be overridden");
    }

    buildEngine() {
        throw new Error("Abstract method buildEngine must be overridden");
    }

    buildWheels() {
        throw new Error("Abstract method buildWheels must be overridden");
    }

    buildDoors() {
        throw new Error("Abstract method buildDoors must be overridden");
    }
}

class MotorcycleBuilder extends VehicleBuilder {
    constructor() {
        super();
        this.Vehicle = new Vehicle("MotorCycle");
    }

    buildFrame() {
        this.Vehicle.setPart("frame", "Motorcycle Frame");
    }

    buildEngine() {
        this.Vehicle.setPart("engine", "500 cc");
    }

    buildWheels() {
        this.Vehicle.setPart("wheels", "2");
    }

    buildDoors() {
        this.Vehicle.setPart("doors", "0");
    }
}

class CarBuilder extends VehicleBuilder {
    constructor() {
        super();
        this.Vehicle = new Vehicle("Car");
    }

    buildFrame() {
        this.Vehicle.setPart("frame", "Car Frame");
    }

    buildEngine() {
        this.Vehicle.setPart("engine", "2500 cc");
    }

    buildWheels() {
        this.Vehicle.setPart("wheels", "4");
    }

    buildDoors() {
        this.Vehicle.setPart("doors", "4");
    }
}

class ScooterBuilder extends VehicleBuilder {
    constructor() {
        super();
        this.Vehicle = new Vehicle("Scooter");
    }

    buildFrame() {
        this.Vehicle.setPart("frame", "Scooter Frame");
    }

    buildEngine() {
        this.Vehicle.setPart("engine", "50 cc");
    }

    buildWheels() {
        this.Vehicle.setPart("wheels", "2");
    }

    buildDoors() {
        this.Vehicle.setPart("doors", "0");
    }
}

class Shop {
    construct(vehicleBuilder) {
        vehicleBuilder.buildFrame();
        vehicleBuilder.buildEngine();
        vehicleBuilder.buildWheels();
        vehicleBuilder.buildDoors();
    }
}

const shop = new Shop();
let vehicleBuilder = new ScooterBuilder();

shop.construct(vehicleBuilder);
vehicleBuilder.Vehicle.show();

vehicleBuilder = new CarBuilder();
shop.construct(vehicleBuilder);
vehicleBuilder.Vehicle.show();

vehicleBuilder = new MotorcycleBuilder();
shop.construct(vehicleBuilder);
vehicleBuilder.Vehicle.show();