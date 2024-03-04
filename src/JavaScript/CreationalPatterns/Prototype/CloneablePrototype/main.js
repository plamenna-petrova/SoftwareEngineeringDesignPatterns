
class Prototype {
    constructor(x) {
        this.x = x;
    }

    printData() {
        console.log(`with value: ${this.x}`);
    }

    clone() {
        return Object.assign(Object.create(Object.getPrototypeOf(this)), this);
    }
}

let prototype = new Prototype(10);

let clonesDictionary = {};

for (let i = 1; i < 11; i++) {
    let identifier = "Object" + i.toString();
    clonesDictionary[identifier] = prototype.clone();
    clonesDictionary[identifier].x *= i;
    process.stdout.write(`${identifier} `);
    clonesDictionary[identifier].printData();
}
