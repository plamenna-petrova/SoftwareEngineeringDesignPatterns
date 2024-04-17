
class Observer {
    constructor(userName) {
        this.userName = userName;
    }

    get UserName() {
        return this.userName;
    }

    set UserName(value) {
        this.userName = value;
    }

    addSubscriber(subject) {
        subject.registerObserver(this);
    }

    removeSubscriber(subject) {
        subject.removeObserver(this);
    }

    update(productAvailability) {
        console.log(`Hello ${this.userName}, Product is now ${productAvailability} on Amazon`);
    }
}

class Subject {
    constructor(productName, productPrice, productAvailability) {
        this.productName = productName;
        this.productPrice = productPrice;
        this.productAvailability = productAvailability;
        this.observers = [];
    }

    get ProductName() {
        return this.productName;
    }

    get ProductPrice() {
        return this.productPrice;
    }

    get ProductAvailability() {
        return this.productAvailability;
    }

    set ProductAvailability(value) {
        this.productAvailability = value;
        console.log(`Availability changed from Out of Stock to ${value}`);
    }

    registerObserver(observer) {
        console.log(`Observer added: ${observer.UserName}`);
        this.observers.push(observer);
    }

    removeObserver(observer) {
        console.log(`Observer removed: ${observer.UserName}`);

        const observerToRemoveIndex = this.observers.indexOf(observer);

        if (observerToRemoveIndex !== -1) {
            this.observers.splice(observerToRemoveIndex, 1);
        }
    }

    notifyObservers() {
        console.log(`Product Name: ${this.productName}, product price: ${this.productPrice}. So, notifying all registered users.`);
        console.log();

        for (const observer of this.observers) {
            observer.update(this.productAvailability);
        }
    }
}

const XiaomiRedmi = new Subject("Xiaomi Redmi Mobile", 10000, "Out Of Stock");

const firstObserver = new Observer("Axel");
firstObserver.addSubscriber(XiaomiRedmi);

const secondObserver = new Observer("Pharrell");
secondObserver.addSubscriber(XiaomiRedmi);

const thirdObserver = new Observer("Carl");
thirdObserver.addSubscriber(XiaomiRedmi);

console.log("Xiaomi Red Mi Mobile current state: " + XiaomiRedmi.ProductAvailability);
console.log();

thirdObserver.removeSubscriber(XiaomiRedmi);

XiaomiRedmi.ProductAvailability = "Available";