
class Observer {
    constructor() {
        if (this.constructor === Observer) {
            throw new Error("Abstract class cannot be instantiated directly.");
        }
    }

    update() {
        throw new Error("Method 'update' must be implemented.");
    }
}

class ConcreteObserver extends Observer {
    constructor(concreteSubject, name) {
        super();
        this.name = name;
        this.observerState = '';
        this.concreteSubject = concreteSubject;
    }

    update() {
        this.observerState = this.concreteSubject.subjectState;
        console.log(`Observer ${this.name}'s new state is ${this.observerState}`);
    }
}

class Subject {
    constructor() {
        this.observers = [];
    }

    attach(observer) {
        this.observers.push(observer);
    }

    detach(observer) {
        const observerToDetachIndex = this.observers.indexOf(observer);

        if (observerToDetachIndex !== -1) {
            this.observers.splice(observerToDetachIndex, 1);
        }
    }

    notify() {
        this.observers.forEach(observer => observer.update());
    }
}

class ConcreteSubject extends Subject {
    constructor() {
        super();
        this.subjectState = '';
    }

    getSubjectState() {
        return this.subjectState;
    }

    setSubjectState(state) {
        this.subjectState = state;
    }
}

const concreteSubject = new ConcreteSubject();

concreteSubject.attach(new ConcreteObserver(concreteSubject, "X"));
concreteSubject.attach(new ConcreteObserver(concreteSubject, "Y"));
concreteSubject.attach(new ConcreteObserver(concreteSubject, "Z"));

concreteSubject.setSubjectState("ABC");
concreteSubject.notify();