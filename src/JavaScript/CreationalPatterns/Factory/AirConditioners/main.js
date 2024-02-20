
class AirConditioner {
    operate() {
        throw new Error("Method 'operate' must be implemented.");
    }
}

class CoolingManager extends AirConditioner {
    constructor(temperature) {
        super();
        this.temperature = temperature;
    }

    operate() {
        console.log(`Cooling the room to the required temperature of ${this.temperature} degrees`);
    }
}

class WarmingManager extends AirConditioner {
    constructor(temperature) {
        super();
        this.temperature = temperature;
    }

    operate() {
        console.log(`Warming the room to the required temperature of ${this.temperature} degrees`);
    }
}

class AirConditionerFactory {
    createAirConditioner(temperature) {
        throw new Error("Method 'createAirConditioner' must be implemented.");
    }
}

class CoolingFactory extends AirConditionerFactory {
    createAirConditioner(temperature) {
        return new CoolingManager(temperature);
    }
}

class WarmingFactory extends AirConditionerFactory {
    createAirConditioner(temperature) {
        return new WarmingManager(temperature);
    }
}

const Action = Object.freeze({
    Cooling: "Cooling",
    Warming: "Warming",
});

const airConditionersProductClassesMapping = {
    'CoolingFactory': CoolingManager,
    'WarmingFactory': WarmingManager
};

class AirConditionersManager {
    constructor() {
        this.airConditionerFactories = {};

        for (const action in Action) {
            if (Object.prototype.hasOwnProperty.call(Action, action)) {
                const factoryName = action + "Factory";
                this.airConditionerFactories[Action[action]] = airConditionersProductClassesMapping[factoryName];
            }
        }
    }

    executeCreation(action, temperature) {
        return new this.airConditionerFactories[action](temperature);
    }
}

const airConditionersManager = new AirConditionersManager();

const coolingAirConditioner = airConditionersManager.executeCreation(Action.Cooling, 22.5);
coolingAirConditioner.operate();

const warmingAirConditioner = airConditionersManager.executeCreation(Action.Warming, 33.4);
warmingAirConditioner.operate();