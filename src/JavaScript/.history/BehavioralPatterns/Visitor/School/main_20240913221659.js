
class IElement {
    accept(visitor) {
        throw new Error("Method 'accept' must be implemented.");
    }
}

class Kid extends IElement {
    constructor(name) {
        super();
        this.name = name;
    }

    getName() {
        return this.name;
    }

    setName(name) {
        this.name = name;
    }

    accept(visitor) {
        visitor.visit(this);
    }
}

class IVisitor {
    visit(element) {
        throw new Error("Method 'visit' must be implemented.");
    }
}

class Doctor extends IVisitor {
    constructor(name) {
        super();
        this.name = name;
    }

    getName() {
        return this.name;
    }

    setName(name) {
        this.name = name;
    }

    visit(element) {
        if (element instanceof Kid) {
            console.log(`Doctor: ${this.name} did the health checkup of the child: ${element.getName()}`);
        }
    }
}

class Teacher extends IVisitor {
    constructor(name) {
        super();
        this.name = name;
    }

    getName() {
        return this.name;
    }

    setName(name) {
        this.name = name;
    }

    visit(element) {
        if (element instanceof Kid) {
            console.log(`Teacher: ${this.name} assessed the daily work of the child: ${element.getName()}`);
        }
    }
}

class School {
    constructor() {
        this.elements = [
            new Kid("John"),
            new Kid("Sarah"),
            new Kid("Kim")
        ];
    }

    performOperation(visitor) {
        this.elements.forEach(element => {
            element.accept(visitor);
        });
    }
}

const school = new School();

const doctor = new Doctor("James");
school.performOperation(doctor);
console.log();

const teacher = new Teacher("Mr. Smith");
school.performOperation(teacher);