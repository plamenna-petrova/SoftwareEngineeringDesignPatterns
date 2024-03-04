
class Employee {
    constructor(name, department, address) {
        this.name = name;
        this.department = department;
        this.address = address;
    }

    getShallowCopy() {
        return Object.assign(Object.create(Object.getPrototypeOf(this)), this);
    }

    getDeepCopy() {
        let clonedEmployee = this.getShallowCopy();
        clonedEmployee.address = this.address.getClone();
        return clonedEmployee;
    }

    getDetails() {
        console.log(`Employee Details: Name - ${this.name}, Department - ${this.department}, Address - ${this.address.name}`);
    }
}

class SoftwareDeveloper extends Employee {
    getShallowCopy() {
        return super.getShallowCopy();
    }

    getDeepCopy() {
        let clonedSoftwareDeveloper = super.getDeepCopy();
        return clonedSoftwareDeveloper;
    }
}

class Address {
    constructor(name) {
        this.name = name;
    }

    getClone() {
        return Object.assign(Object.create(Object.getPrototypeOf(this)), this);
    }
}

let firstSoftwareDeveloper = new SoftwareDeveloper("John", "IT", new Address("London, UK"));
let secondSoftwareDeveloper = firstSoftwareDeveloper.getShallowCopy();
let thirdSoftwareDeveloper = firstSoftwareDeveloper.getDeepCopy();

console.log("Original values: \r\n");

firstSoftwareDeveloper.getDetails();
secondSoftwareDeveloper.getDetails();
thirdSoftwareDeveloper.getDetails();

console.log();

secondSoftwareDeveloper.name = "James";
secondSoftwareDeveloper.address.name = "New York, USA";

thirdSoftwareDeveloper.address.name = "Barcelona, Spain";

console.log("After applying changes: \r\n");

firstSoftwareDeveloper.getDetails();
secondSoftwareDeveloper.getDetails();
thirdSoftwareDeveloper.getDetails();
