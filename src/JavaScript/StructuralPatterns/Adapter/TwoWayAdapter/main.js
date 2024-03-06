class Aircraft {
    constructor() {
        this._height = 0;
        this._airborne = false;
    }

    get airborne() {
        return this._airborne;
    }

    get height() {
        return this._height;
    }

    takeOff() {
        console.log("Aircraft engine takeoff");
        this._height = 200;
        this._airborne = true;
    }
}

class Seacraft {
    constructor() {
        this._speed = 0;
    }

    increaseRevs() {
        this._speed += 10;
        console.log("Seacraft engine increases revs to " + this._speed + " knots");
    }

    get speed() {
        return this._speed;
    }
}

class Seabird extends Seacraft {
    constructor() {
        super();
        this._height = 0;
    }

    get height() {
        return this._height;
    }

    get airborne() {
        return this._height > 50;
    }

    takeOff() {
        while (!this.airborne) {
            this.increaseRevs();
        }
    }

    increaseRevs() {
        super.increaseRevs();

        if (this.speed > 40) {
            this._height += 100;
        }
    }
}

// Client code
console.log("Experiment 1: test the aircraft's engine");
const aircraft = new Aircraft();
aircraft.takeOff();

if (aircraft.airborne) {
    console.log("The aircraft engine is fine, flying at " + aircraft.height + " meters");
}

console.log("\nExperiment 2: Use the engine in the Seabird");
const seabird = new Seabird();
seabird.takeOff();
console.log("The Seabird took off");

console.log("\nExperiment 3: Increase the speed of the Seabird:");
seabird.increaseRevs();
seabird.increaseRevs();

if (seabird.airborne) {
    console.log(`Seabird flying at height ${seabird.height} meters and speed ${seabird.speed}`);
}

console.log("Experiment successful; the Seabird flies!");