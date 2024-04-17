
class LEDTV {
    constructor(size, price, hasUSBSupport) {
        this.size = size;
        this.price = price;
        this.hasUSBSupport = hasUSBSupport;
    }

    getDetails() {
        return `LEDTV [Size = ${this.size}, Price = ${this.price}, USBSupport = ${this.hasUSBSupport ? "Yes" : "No"}]`;
    }
}

class LEDTVMemento {
    constructor(ledTV) {
        this.ledTV = ledTV;
    }

    getDetails() {
        return `Memento [LedTV = ${this.ledTV.getDetails()}]`;
    }
}

class Caretaker {
    constructor() {
        this.ledTVs = [];
    }

    addMemento(ledTVMemento) {
        this.ledTVs.push(ledTVMemento);
        console.log("LED TV's snapshots maintained by caretaker : " + ledTVMemento.getDetails());
    }

    getLEDTVMemento(index) {
        return this.ledTVs[index];
    }
}

class Originator {
    constructor() {
        this.ledTV = null;
    }

    createLEDTVMemento() {
        return new LEDTVMemento(this.ledTV);
    }

    setMemento(ledTVMemento) {
        this.ledTV = ledTVMemento.ledTV;
    }

    getDetails() {
        return `Originator [LEDTV = ${this.ledTV.getDetails()}]`;
    }
}

const originator = new Originator();
originator.ledTV = new LEDTV("42-Inch", 60000, false);

const caretaker = new Caretaker();

let ledTVMemento = originator.createLEDTVMemento();
caretaker.addMemento(ledTVMemento);

originator.ledTV = new LEDTV("46-Inch", 80000, true);

ledTVMemento = originator.createLEDTVMemento();
caretaker.addMemento(ledTVMemento);

originator.ledTV = new LEDTV("50-Inch", 100000, true);

console.log(`Originator's current state : ${originator.getDetails()}`);

console.log("\nOriginator restoring to 42-Inch LED TV");

originator.setMemento(caretaker.getLEDTVMemento(0));

console.log(`\nOriginator current state: ${originator.getDetails()}`);