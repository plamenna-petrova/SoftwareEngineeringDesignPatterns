
class Flyweight {
    executeOperation(extrinsicState) {
        console.log(`ConcreteFlyweight: ${extrinsicState}`);
    }
}

class ConcreteFlyweight extends Flyweight {
    executeOperation(extrinsicState) {
        console.log(`ConcreteFlyweight: ${extrinsicState}`);
    }
}

class UnsharedConcreteFlyweight extends Flyweight {
    executeOperation(extrinsicState) {
        console.log(`UnsharedConcreteFlyweight: ${extrinsicState}`);
    }
}

class FlyweightFactory {
    constructor() {
        this.flyweights = {
            "X": new ConcreteFlyweight(),
            "Y": new ConcreteFlyweight(),
            "Z": new ConcreteFlyweight()
        };
    }

    getFlyweight(key) {
        return this.flyweights[key];
    }
}

let extrinsicState = 22;
const flyweightFactory = new FlyweightFactory();

let flyweightX = flyweightFactory.getFlyweight("X");
flyweightX.executeOperation(--extrinsicState);

let flyweightY = flyweightFactory.getFlyweight("Y");
flyweightY.executeOperation(--extrinsicState);

let flyweightZ = flyweightFactory.getFlyweight("Z");
flyweightZ.executeOperation(--extrinsicState);

const unsharedConcreteFlyweight = new UnsharedConcreteFlyweight();
unsharedConcreteFlyweight.executeOperation(--extrinsicState);