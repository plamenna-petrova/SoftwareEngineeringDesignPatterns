
class Alpha {
    constructor() {
        this.Description = "";
    }
}

class Bravo {
    constructor() {
        this.Name = "";
    }
}

class FactoryBase {
    create() {
        return null;
    }
}

class AlphaFactory extends FactoryBase {
    create() {
        const alpha = new Alpha();
        alpha.Description = "Alpha Here";
        return alpha;
    }
}

class BravoFactory extends FactoryBase {
    create() {
        const bravo = new Bravo();
        bravo.Name = "Bravo";
        return bravo;
    }
}

class ServiceLocator {
    static getFactory(type) {
        if (type === Alpha) {
            return new AlphaFactory();
        }

        if (type === Bravo) {
            return new BravoFactory();
        }

        throw new Error(`No factory defined for type ${type.name}`);
    }
}

const alphaFactory = ServiceLocator.getFactory(Alpha);
const alphaObject = alphaFactory.create();
console.log(`Description: ${alphaObject.Description}`);

const bravoFactory = ServiceLocator.getFactory(Bravo);
const bravoObject = bravoFactory.create();
console.log(`Name: ${bravoObject.Name}`);