
class Iterator {
    getFirstItem() { }

    getNextItem() { }

    isIterationDone() { }

    getCurrentItem() { }
}

class ConcreteIterator extends Iterator {
    constructor(concreteAggregate) {
        super();
        this.concreteAggregate = concreteAggregate;
        this.currentItemIndex = 0;
    }

    getFirstItem() {
        return this.concreteAggregate[0];
    }

    getNextItem() {
        let nextItem = null;

        if (this.currentItemIndex < this.concreteAggregate.length - 1) {
            nextItem = this.concreteAggregate[++this.currentItemIndex];
        }
        
        return nextItem;
    }

    getCurrentItem() {
        return this.concreteAggregate[this.currentItemIndex];
    }

    isIterationDone() {
        return this.currentItemIndex >= this.concreteAggregate.length;
    }
}

class Aggregate {
    createIterator() { }
}

class ConcreteAggregate extends Aggregate {
    constructor() {
        super();
        this.items = [];
    }

    createIterator() {
        return new ConcreteIterator(this.items);
    }

    get length() {
        return this.items.length;
    }

    getItem(index) {
        return this.items[index];
    }

    setItem(index, value) {
        this.items[index] = value;
    }
}

const concreteAggregate = new ConcreteAggregate();

concreteAggregate.setItem(0, "Item A");
concreteAggregate.setItem(1, "Item B");
concreteAggregate.setItem(2, "Item C");
concreteAggregate.setItem(3, "Item D");

const iterator = concreteAggregate.createIterator();

console.log("Iterating over collection: ");

let currentItem = iterator.getFirstItem();

while (currentItem !== null) {
    console.log(currentItem);
    currentItem = iterator.getNextItem();
}