
class IDInfo {
    constructor(idNumber) {
        this.idNumber = idNumber;
    }
}

class Person {
    constructor(age, birthDate, name, idInfo) {
        this.age = age;
        this.birthDate = birthDate;
        this.name = name;
        this.idInfo = idInfo;
    }

    shallowCopy() {
        return Object.assign(Object.create(Object.getPrototypeOf(this)), this);
    }

    deepCopy() {
        let clonedPerson = this.shallowCopy();
        clonedPerson.idInfo = new IDInfo(this.idInfo.idNumber);
        return clonedPerson;
    }
}

class Traveler extends Person {
    constructor(age, birthDate, name, idInfo) {
        super(age, birthDate, name, idInfo);
    }

    shallowCopy() {
        return super.shallowCopy();
    }

    DeepCopy() {
        let clonedTraveler = super.deepCopy();
        return clonedTraveler;
    }
}

const displayValues = (person) => {
    console.log(" ".repeat(10) + `Name: ${person.name}, Age: ${person.age}, BirthDate: ${person.birthDate.toLocaleDateString()}`);
    console.log(" ".repeat(10) + `ID#: ${person.idInfo.idNumber}`);
}

let firstTraveler = new Traveler(42, new Date("1977-01-01"), "Jack Daniels", new IDInfo(666));
let secondTraveler = firstTraveler.shallowCopy();
let thirdTraveler = firstTraveler.deepCopy();

console.log("Original values of the first, second, and third travelers: ");
console.log("Traveler #1 instance values: ");
displayValues(firstTraveler);
console.log("Traveler #2 instance values: ");
displayValues(secondTraveler);
console.log("Traveler #3 instance values: ");
displayValues(thirdTraveler);

firstTraveler.age = 32;
firstTraveler.birthDate = new Date("1990-05-06");
firstTraveler.name = "Frank";
firstTraveler.idInfo.idNumber = 7879;

console.log("Values of the first, second, and third travelers after applying changes to the first one: ");
console.log("Traveler #1 instance values: ");
displayValues(firstTraveler);
console.log("Traveler #2 instance values (reference values have changed - shallow copy):");
displayValues(secondTraveler);
console.log("Traveler #3 instance values (everything was kept the same - deep copy): ");
displayValues(thirdTraveler);
